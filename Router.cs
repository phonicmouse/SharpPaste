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
            Get["/"] = _ => View["index"];

            Get["/{longId}"] = parameters =>
            {
                return View["paste"];
                //string longId = parameters.longId;
                //using (var db = new LiteDatabase(Config.DBPATH))
                //{
                //    var result = db.GetCollection<Paste>("pastes").FindOne(Query.EQ("LongId", longId));
                //    //check if paste exists (todo)
                //}
            };

            Get["/json/{longId}"] = parameters =>
            {
                string longId = parameters.longId;
                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var result = db.GetCollection<Paste>("pastes").FindOne(Query.EQ("LongId", longId));
                    return JsonConvert.SerializeObject(result);
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

            Post["/add"] = _ =>
            {
                var body = this.Request.Body;

                int length = (int)body.Length;
                var data = new byte[length];

                body.Read(data, 0, length);

                var decodedPaste = JsonConvert.DeserializeObject<Paste>(Encoding.Default.GetString(data));

                if (Checker.isHex(decodedPaste.Title) && Checker.isHex(decodedPaste.Body) && Checker.isHex(decodedPaste.Language))
                {
                    string longId = PasswordGenerator.Generate(Config.TOKENLENGTH);

                    using (var db = new LiteDatabase(Config.DBPATH))
                    {
                        var pastes = db.GetCollection<Paste>("pastes");

                        var newPaste = new Paste
                        {
                            LongId = longId,
                            Title = decodedPaste.Title,
                            Body = decodedPaste.Body,
                            Language = decodedPaste.Language
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
                } else
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
