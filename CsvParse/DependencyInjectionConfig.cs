using CsvParse.Contract;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(CsvParse.DependencyInjectionConfig))]

namespace CsvParse
{
    public class DependencyInjectionConfig : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ICsvHelper, CsvHelper>();
        }
    }
}
