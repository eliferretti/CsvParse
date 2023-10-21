using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Xml.Linq;
using CsvParse.Aplication.Interfaces;

namespace CsvParse
{
    public class CsvParser
    {
        private readonly ICsvTools _csvTools;

        public CsvParser(ICsvTools csvTools)
        {
            _csvTools = csvTools;
        }

        [FunctionName("CsvParser")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CsvParser")] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string base64Csv = data?.file;
            
            return new OkObjectResult(_csvTools.ConvertToJson(base64Csv));
        }
    }
}
