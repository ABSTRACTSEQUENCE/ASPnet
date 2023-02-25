using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//app.MapGet("/", () => "Hello World!");
app.Run(async (context) =>
{
	context.Response.ContentType = "text/html;";
	switch (context.Request.Path)
	{
		case "/registration": await context.Response.SendFileAsync("html\\registration.html"); break;
		case "/info":
			var form = context.Request.Form;
			List<string> languages = new List<string>(){ form["c#"], form["c++"] };
			string str =
			$"<h3>Info:</h3>" +
			$"<p>Name: {form["name"]}</p>" +
			$"<p>Second Name: {form["s_name"]}</p>" +
			$"<h3>Languages:</h3>";
			foreach (var i in form.Keys)
				if (form[i] == "on") str += $"<p>{i}</p>";
			await context.Response.WriteAsync(str);
			break;
		default: await context.Response.SendFileAsync("html/index.html"); break;
	}
	
});
app.Run();
