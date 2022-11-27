using CsvDemo.Configurations;
using CsvDemo.Dto;
using CsvDemo.Services.Base;
using Microsoft.Extensions.Options;
using System.Text;

namespace CsvDemo.Services
{
    /// <summary>
    /// Implements logic for CSV convertion.
    /// </summary>
    public class DocumentDemoService : IDocumentDemoService
    {
        /// <summary>
        /// Represents a csv configuration file.
        /// </summary>
        private readonly CsvDocumentConfiguration _csvDocumentConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDemoService"/> class.
        /// </summary>
        /// <param name="emailConfig">Email configuration.</param>
        public DocumentDemoService(IOptions<CsvDocumentConfiguration> csvDocConfigutation)
        {
            _csvDocumentConfiguration = csvDocConfigutation.Value;
        }

        /// <inheritdoc />
        public ServiceResult GetFormattedString(DocumentDto documentDto)
        {
            var result = new ServiceResult<string>();

            string columns = _csvDocumentConfiguration.Columns!;
            List<string> columnsList = columns.Split(',').Select(s => s.Trim()).ToList();
            List<string> csvList = documentDto.Body.Split('"').Select(s => s.Trim()).ToList();
            List<string> cleanedCsv = csvList.Where(l => l != string.Empty && l != ",").ToList();
            List<string> csvWithoutColumns = cleanedCsv.Where(x => !columnsList.Contains(x)).ToList();

            if (!IsValidData(columnsList.Count, csvWithoutColumns.Count))
            {
                result.Message = "Format error!";
                return result;
            }

            string csvString = GetFormattedData(columnsList, csvWithoutColumns);

            result.Data = csvString;
            result.Status = true;
            result.Message = "Sucessfully process!";

            return result;
        }

        /// <summary>
        /// check if the number of rows are according to the columns.
        /// </summary>
        /// <param name="numColumns">Number of columns</param>
        /// <param name="numRows">Number of rows</param>
        /// <returns>Boolean result.</returns>
        private bool IsValidData(int numColumns, int numRows)
        {
            return (numRows % numColumns) == 0;
        }

        /// <summary>
        /// Implements the logic of converting one CSV format to another
        /// </summary>
        /// <param name="columnsList"></param>
        /// <param name="csvWithoutColumns"></param>
        /// <returns>Return formatted string result.</returns>
        private string GetFormattedData(List<string> columnsList, List<string> csvWithoutColumns)
        {
            int counter = 0;
            int numbColumns = columnsList.Count;
            List<string> formattedColumns = columnsList.Select(x => $"[{x}]").ToList();
            List<string> formattedRows = csvWithoutColumns.Select(x => $"[{x}] ").ToList();
            string columnsText = string.Join(" ", formattedColumns);

            StringBuilder result = new();
            result.AppendLine(columnsText);

            foreach (string row in formattedRows)
            {
                counter++;
                if ((counter % numbColumns) == 0)
                    result.AppendLine(row);
                else
                    result.Append(row);
            }

            return result.ToString();
        }
    }
}
