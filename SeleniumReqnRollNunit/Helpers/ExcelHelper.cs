using Ganss.Excel;
using SeleniumReqnRollNunit.Models;

namespace SeleniumReqnRollNunit.Helpers
{
    public class ExcelHelper
    {
        public static IEnumerable<dynamic> GetExcelData(string filePath)
        {
            try
            {                
                var excelMapper = new ExcelMapper(filePath);
                return excelMapper.Fetch();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<T> GetExcelData<T>(string dtoName, string filePath)
        {
            try
            {
                var excelMapper = GetExcelMapper(dtoName, filePath);
                return excelMapper.Fetch<T>();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static ExcelMapper GetExcelMapper(string excelType, string fileName)
        {
            var mapper = new ExcelMapper(fileName);

            switch (excelType.ToLower())
            {
                case "exceldto":
                    mapper = AddExcelDtoColumnMapping(mapper);
                    break;
            }
            return mapper;
        }

        private static ExcelMapper AddExcelDtoColumnMapping(ExcelMapper mapper)
        {
            mapper.AddMapping<ExcelDTO>("Column1", item => item.Column1);
            mapper.AddMapping<ExcelDTO>("Column2", item => item.Column2);
            mapper.AddMapping<ExcelDTO>("Column3", item => item.Column3);
            mapper.AddMapping<ExcelDTO>("Column4", item => item.Column4);
            mapper.AddMapping<ExcelDTO>("Column5", item => item.Column5);
            mapper.AddMapping<ExcelDTO>("Column6", item => item.Column6);
            return mapper;
        }
    }
}
