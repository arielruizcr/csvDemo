using CsvDemo.Dto;
using CsvDemo.Services.Base;

namespace CsvDemo.Services
{
    /// <summary>
    /// Interface to manage documents.
    /// </summary>
    public interface IDocumentDemoService
    {
        /// <summary>
        /// Convert CSV text to a reformatted CSV text.
        /// </summary>
        /// <param name="documentDto">Dto model for documents</param>
        /// <returns>Returns a string formatted document.</returns>
        ServiceResult GetFormattedString(DocumentDto documentDto);
    }
}
