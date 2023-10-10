using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System;
using Newtonsoft.Json;

namespace CsvParse
{
    public class CsvHelper : ICsvHelper
    {
        public string ConvertToJson(string base64Csv)
        {
            byte[] csvBytes = Convert.FromBase64String(base64Csv);

            using (var memoryStream = new MemoryStream(csvBytes))
            using (var reader = new StreamReader(memoryStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var students = csv.GetRecords<Student>();

                List<StudentFinal> studentsFinal = new();

                foreach (var student in students)
                {
                    var studentFinal = new StudentFinal
                    {
                        Registration = student.Registration,
                        Name = student.Name,
                        Class = student.Class,
                        Exam01 = student.Exam01,
                        Exam02 = student.Exam02,
                        IsAproved = false
                    };
                    studentFinal.AveragePoints = (student.Exam01 + student.Exam02) / 2;
                    if (studentFinal.AveragePoints >= 50) studentFinal.IsAproved = true;

                    studentsFinal.Add(studentFinal);
                }

                return Newtonsoft.Json.JsonConvert.SerializeObject(studentsFinal, Formatting.Indented);
            }
        }
    }
}
