namespace CsvParse.Aplication.Dtos
{
    public class StudentResultDto : StudentInputDto
    {
        public float AveragePoints { get; set; }
        public bool IsAproved { get; set; }
    }
}
