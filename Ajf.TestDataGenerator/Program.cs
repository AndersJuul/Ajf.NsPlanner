using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Ajf.NsPlanner.Application.Dtos;
using Ajf.NsPlanner.UI.Services;
using CsvHelper;
using CsvHelper.Configuration;

namespace Ajf.TestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var nsFolderPath = Path.Combine(folderPath, "NsPlanner");
            var fakeNamesCsvFilePath = Path.Combine(nsFolderPath, "fakenames.csv");
            var fakePartialRequestsCsvFilePath = Path.Combine(nsFolderPath, "fakepartialrequests.csv");

            Directory.CreateDirectory(nsFolderPath);

            const int numberOfRequests = 50;
            string outputCsvFilePath = Path.Combine(nsFolderPath, "fakerequests.csv");

            var random = new Random();

            var fakeNameDtos = GetFakeNames(fakeNamesCsvFilePath);
            var fakePartialRequestDtos = GetFakePartialRequestDtos(fakePartialRequestsCsvFilePath);

            var result = new List<RequestDto>();
            for (int i = 0; i < numberOfRequests; i++)
            {
                var fakeNameIndex=random.Next(fakeNameDtos.Length);
                var fakeRqIndex = random.Next(fakePartialRequestDtos.Length);

                result.Add(new RequestDto()
                {
                    TimeStamp = GetTimeStamp(i),

                    ContactEmail = fakeNameDtos[fakeNameIndex].EmailAddress,
                    ContactName = fakeNameDtos[fakeNameIndex].Name,
                    ContactPhone = "555"+random.Next(10000,99999),

                    Comments = fakePartialRequestDtos[fakeRqIndex].Comments,
                    InstitutionOrSchool = fakePartialRequestDtos[fakeRqIndex].InstitutionOrSchool,
                    DesiredEvent = fakePartialRequestDtos[fakeRqIndex].DesiredEvent,
                    DesiredWhen = fakePartialRequestDtos[fakeRqIndex].DesiredWhen,
                    DesiredDate = fakePartialRequestDtos[fakeRqIndex].DesiredDate,
                    DesiredMeetingPoint = fakePartialRequestDtos[fakeRqIndex].DesiredMeetingPoint,
                    SchoolInstituteName = fakePartialRequestDtos[fakeRqIndex].SchoolInstituteName,
                    ParticipantsAge = fakePartialRequestDtos[fakeRqIndex].ParticipantsAge,
                    ParticipantsGroup = fakePartialRequestDtos[fakeRqIndex].ParticipantsGroup,
                    ParticipantsNumber = fakePartialRequestDtos[fakeRqIndex].ParticipantsNumber
                });
            }

            using (var write = new StreamWriter(outputCsvFilePath))
            {
                var conf = new Configuration(CultureInfo.CurrentCulture)
                    { HasHeaderRecord = true, BadDataFound = null, Delimiter = "," };
                conf.RegisterClassMap<RequestDtoMap>();

                using (var helper = new CsvWriter(write, conf))
                {
                    helper.WriteRecords(result);
                }
            }
        }

        private static string GetTimeStamp(in int i)
        {
            // 23/10/2018 11.49.26
            var d = DateTime.Today.AddSeconds(i);
            return $"{string.Format("{0:dd}/{0:MM}/{0:yyyy} {0:hh.mm.ss}", d)}";
        }

        private static FakeNameDto[] GetFakeNames(string csvFilePath)
        {

            using (var reader = new StreamReader(csvFilePath, Encoding.UTF8))
            {
                var conf = new Configuration(CultureInfo.CurrentCulture)
                    { HasHeaderRecord = true, BadDataFound = null, Delimiter = "," };
                conf.RegisterClassMap<FakeNameDtoMap>();
                using (var helper = new CsvReader(reader, conf))
                {
                    return helper.GetRecords<FakeNameDto>().ToArray();
                }
            }
        }

        private static FakePartialRequestDto[] GetFakePartialRequestDtos(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath, Encoding.UTF8))
            {
                var conf = new Configuration(CultureInfo.CurrentCulture)
                    { HasHeaderRecord = true, BadDataFound = null, Delimiter = ";" };
                conf.RegisterClassMap<FakePartialRequestDtoMap>();
                using (var helper = new CsvReader(reader, conf))
                {
                    return helper.GetRecords<FakePartialRequestDto>().ToArray();
                }
            }
        }
    }
}