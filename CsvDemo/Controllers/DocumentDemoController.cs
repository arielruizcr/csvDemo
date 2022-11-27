using CsvDemo.Dto;
using CsvDemo.Services;
using CsvDemo.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace CsvDemo.Controllers
{
    /// <summary>
    /// Documents controller service demo.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DocumentDemoController : ControllerBase
    {
        /// <summary>
        /// Represents an instance of document service interface.
        /// </summary>
        private readonly IDocumentDemoService _documentDemoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentDemoController"/> class.
        /// </summary>
        /// <param name="documentDemoService">Interface for document service.</param>
        public DocumentDemoController(IDocumentDemoService documentDemoService)
        {
            _documentDemoService = documentDemoService;
        }

        /// <summary>
        /// Allows to convert CSV format to another.
        /// </summary>
        /// <param name="documentDto">Dto with csv information.</param>
        /// <returns>ServiceResult response.</returns>
        [HttpPost]
        public ActionResult<ServiceResult<string>> Post([FromBody] DocumentDto documentDto)
        {
            ServiceResult result = _documentDemoService.GetFormattedString(documentDto);
            if (result.Status)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
