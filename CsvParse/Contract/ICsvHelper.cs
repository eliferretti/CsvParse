namespace CsvParse.Contract
{
    public interface ICsvHelper
    {
        public string ConvertToJson(string base64Csv);
    }
}
