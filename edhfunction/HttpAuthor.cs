
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace edhfunction;


public class HttpAuthorExample
{
    [FunctionName("HttpAuthorExample")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log,
        [Sql(commandText: "SELECT TOP (10) [au_id],[au_lname],[au_fname],[phone],[address],[city],[state],[zip],[contract] FROM [dbo].[authors]",
        commandType:System.Data.CommandType.Text,
        connectionStringSetting: "SqlConnectionString")] IEnumerable <HttpAuthor> authors)
    {
        return new OkObjectResult(authors.AsParallel());
    }
    public class HttpAuthor
    {
        public string au_id { get; set; }
        public string au_lname { get; set; }
        public string au_fname { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string contract { get; set; }
    }
}