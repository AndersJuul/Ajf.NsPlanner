using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Ajf.NsPlanner.Application.Dtos;
using Ajf.NsPlanner.UI.Abstractions;
using CsvHelper;
using CsvHelper.Configuration;

namespace Ajf.NsPlanner.UI.Services
{
    public class RawRequestRepository : IRawRequestRepository
    {
        public IEnumerable<RequestDto> List(string fileName)
        {
            var csvFilePath = Path.Combine(fileName);

            using (var reader = new StreamReader(csvFilePath, Encoding.UTF8))
            {
                var conf = new CsvConfiguration(CultureInfo.CurrentCulture)
                    {HasHeaderRecord = true, BadDataFound = null, Delimiter = ","};
                conf.RegisterClassMap<RequestDtoMap>();
                using (var helper = new CsvReader(reader, conf))
                {
                    return helper.GetRecords<RequestDto>().ToArray();
                }
            }
        }
    }
}