using System;
using System.Text;
using LiteDB;
using EasyEncryption;
using Multiformats.Base;
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
                    var collection = db.GetCollection<Paste>("Pastes");
                    var paste = collection.FindOne(Query.EQ("LongId", parameters.longId.ToString()));
                    if (paste == null) return HttpStatusCode.NotFound;
                    return View["paste", paste];
                }
            };

            Get["/json/{longId}"] = parameters =>
            {
                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var collection = db.GetCollection<Paste>("Pastes");
                    var paste = collection.FindOne(Query.EQ("LongId", parameters.longId.ToString()));
                    if (paste == null) return HttpStatusCode.NotFound;
                    return JsonConvert.SerializeObject(paste);
                }
            };

            Get["/raw/{longId}"] = parameters =>
            {
                string longId = parameters.longId;
            
                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var result = db.GetCollection<Paste>("Pastes").FindOne(Query.EQ("LongId", longId));
            
                    return result.Body;
                }
            };

            Post["/upload"] = parameters =>
            {
                var body = Request.Body;
                var length = (int) body.Length;
                var data = new byte[length];

                body.Read(data, 0, length);

                var jsonPaste = JsonConvert.DeserializeObject<Paste>(Encoding.Default.GetString(data));

                if (HexUtils.isHex(jsonPaste.Title) && HexUtils.isHex(jsonPaste.Body))
                {
                    using (var db = new LiteDatabase(Config.DBPATH))
                    {
                        var pastes = db.GetCollection<Paste>("Pastes");

                        string hashSeed = pastes.Count().ToString() + jsonPaste.Date.ToString() + jsonPaste.Title + jsonPaste.Body + jsonPaste.Language;
                        string longId = Multibase.Base64.Encode(HexUtils.toByteArray(SHA.ComputeSHA256Hash(hashSeed)), false, true);

                        var newPaste = new Paste
                        {
                            LongId = longId,
                            Date = DateTime.Now,
                            Title = jsonPaste.Title,
                            Body = jsonPaste.Body,
                            Language = jsonPaste.Language
                        };

                        pastes.Insert(newPaste);

                        var res = new UploadResponse
                        {
                            Status = "success",
                            LongId = longId
                        };
                        return JsonConvert.SerializeObject(res);
                    }
                }
                else
                {
                    var res = new UploadResponse
                    {
                        Status = "error",
                        ErrMsg = "Error: the paste is not encrypted with AES-256."
                    };
                    return JsonConvert.SerializeObject(res);
                }
            };

            Post["/event"] = parameters => 
            {
                var body = Request.Body;
                var length = (int)body.Length;
                var data = new byte[length];

                body.Read(data, 0, length);

                var jsonEvent = JsonConvert.DeserializeObject<Event>(Encoding.Default.GetString(data));

                using (var db = new LiteDatabase(Config.ANALYTICSDBPATH))
                {
                    var events = db.GetCollection<Event>("Events");

                    string hashSeed = events.Count().ToString() + jsonEvent.Timestamp.ToString() + jsonEvent.Name + jsonEvent.Data;
                    string longId = Multibase.Base64.Encode(HexUtils.toByteArray(SHA.ComputeSHA256Hash(hashSeed)), false, true);

                    var newEvent = new Event
                    {
                        LongId = longId,
                        Timestamp = DateTime.Now,
                        Name = jsonEvent.Name,
                        Data = jsonEvent.Data
                    };
                }

                return "SUCCESS";
            };
        }
    }
}