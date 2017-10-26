using System;
using System.Text;
using LiteDB;
using MlkPwgen;
using Nancy;
using Newtonsoft.Json;

namespace SharpPaste
{
    public class Router : NancyModule
    {
        public Router()
        {
            Get["/"] = parameters => View["index"];

            Get["/{longId}"] = parameters =>
            {
                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var collection = db.GetCollection<Paste>("pastes");
                    var paste = collection.FindOne(Query.EQ("LongId", parameters.longId.ToString()));
                    if (paste == null) return View["404"];
                    paste.WebViews += 1;
                    collection.Update(paste);
                    return View["paste", paste];
                }
            };

            Get["/json/{longId}"] = parameters =>
            {
                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var collection = db.GetCollection<Paste>("pastes");
                    var paste = collection.FindOne(Query.EQ("LongId", parameters.longId.ToString()));
                    if (paste == null) return JsonConvert.SerializeObject((dynamic) null);
                    paste.JsonHits += 1;
                    collection.Update(paste);
                    return JsonConvert.SerializeObject(paste);
                }
            };

            //Get["/raw/{longId}"] = parameters =>
            //{
            //    string longId = parameters.longId;
            //
            //    using (var db = new LiteDatabase(Config.DBPATH))
            //    {
            //        var result = db.GetCollection<Paste>("pastes").FindOne(Query.EQ("LongId", longId));
            //
            //        return result.Body;
            //    }
            //};

            Post["/add"] = parameters =>
            {
                var body = Request.Body;

                var length = (int) body.Length;
                var data = new byte[length];

                body.Read(data, 0, length);

                var jsonPaste = JsonConvert.DeserializeObject<Paste>(Encoding.Default.GetString(data));

                if (Checker.isHex(jsonPaste.Title) && Checker.isHex(jsonPaste.Body))
                {
                    var longId = PasswordGenerator.Generate(Config.TOKENLENGTH);

                    using (var db = new LiteDatabase(Config.DBPATH))
                    {
                        var pastes = db.GetCollection<Paste>("pastes");

                        var newPaste = new Paste
                        {
                            LongId = longId,
                            Date = DateTime.Now,
                            Title = jsonPaste.Title,
                            Body = jsonPaste.Body,
                            Language = jsonPaste.Language,
                            UploadedBy = jsonPaste.UploadedBy
                        };

                        pastes.Insert(newPaste);
                    }
                    var res = new AddRes
                    {
                        Status = "success",
                        Token = longId,
                        ErrMsg = null
                    };
                    return JsonConvert.SerializeObject(res);
                }
                else
                {
                    var res = new AddRes
                    {
                        Status = "error",
                        Token = null,
                        ErrMsg = "Error: the paste is not encrypted with AES-256."
                    };
                    return JsonConvert.SerializeObject(res);
                }
            };
        }
    }
}