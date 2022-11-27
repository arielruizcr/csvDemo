using System.ComponentModel.DataAnnotations;

namespace CsvDemo.Dto
{
    /// <summary>
    /// Dto to transfer CSV data.
    /// </summary>
    public class DocumentDto
    {
        [Required]
        public string Body { get; set; }
    }
}
