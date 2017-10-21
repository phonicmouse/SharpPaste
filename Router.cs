/*
 * Created by SharpDevelop.
 * User: Phonic Mouse
 * Date: 01/08/2016
 * Time: 19:36
 */
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
                string longId = parameters.longId;
                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var result = db.GetCollection<Paste>("pastes").FindOne(Query.EQ("LongId", longId));

                    return View["paste", result];
                }
            };

            Get["/raw/{longId}"] = parameters =>
            {
                string longId = parameters.longId;

                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var result = db.GetCollection<Paste>("pastes").FindOne(Query.EQ("LongId", longId));

                    return result.Body;
                }
            };

            Post["/add"] = _ =>
            {
                var body = this.Request.Body;

                int length = (int)body.Length;
                var data = new byte[length];

                body.Read(data, 0, length);

                var decodedPaste = JsonConvert.DeserializeObject<Paste>(Encoding.Default.GetString(data));

                string longId = PasswordGenerator.Generate(Config.TOKENLENGTH);

                using (var db = new LiteDatabase(Config.DBPATH))
                {
                    var pastes = db.GetCollection<Paste>("pastes");

                    var paste = new Paste
                    {
                        LongId = longId,
                        Title = decodedPaste.Title,
                        Body = decodedPaste.Body,
                        Language = decodedPaste.Language
                    };

                    pastes.Insert(paste);
                }

                return longId;
            };
        }
    }
}
