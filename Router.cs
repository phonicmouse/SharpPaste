/*
 * Created by SharpDevelop.
 * User: Phonic Mouse
 * Date: 01/08/2016
 * Time: 19:36
 */
using System;
using System.Linq;
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
			Get["/"] = _ => {
				return View["index"];
			};
			
			Get["/paste/{longId}"] = parameters => {
				string longId = parameters.longId;
				return View["paste", longId];
			};
			
			Get["/paste/{longId}/raw"] = parameters => {
				string longId = parameters.longId;
				
				using(var db = new LiteDatabase(Config.DBPATH))
				{
					var result = db.GetCollection<Paste>("pastes").FindOne(Query.EQ("LongId", longId));
					
					return result.Body;
				}
			};
			
			Get["/paste/list"] = _ => {
				using(var db = new LiteDatabase(Config.DBPATH))
				{
					var list = db.GetCollection<Paste>("pastes").FindAll().ToArray();
					var jsonList = JsonConvert.SerializeObject(list);
					return jsonList;
				}
			};
			
			Post["/paste/add/"] = _ => {
				var body = this.Request.Body;
				
				int length = (int) body.Length;
				var data = new byte[length];
				
				body.Read(data, 0, length);
				
				Paste decodedPaste = JsonConvert.DeserializeObject<Paste>(Encoding.Default.GetString(data));
				
				using(var db = new LiteDatabase(Config.DBPATH))
				{
					var pastes = db.GetCollection<Paste>("pastes");
					
					var paste = new Paste
					{
						LongId = PasswordGenerator.Generate(23),
						Title = decodedPaste.Title,
						Body = decodedPaste.Body,
						Highlighting = decodedPaste.Highlighting
					};
					
					pastes.Insert(paste);
				}
				
				return HttpStatusCode.OK;
			};
		}
	}
}
