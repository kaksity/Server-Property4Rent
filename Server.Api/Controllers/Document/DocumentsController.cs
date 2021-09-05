using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos.Document;
using Server.Models.Document;
using Server.Models.General;
using Server.Services.Document;

namespace Server.Api.Controllers.Document
{
    [ApiController]
    [Route("api/v1/documents")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }        

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] RequestDocumentDto dto) 
        {
            if (ModelState.IsValid ==false)
            {
                return BadRequest();
            }

            await _documentService.CreateDocumentAsync(dto);
            
            return Ok(new ServiceResponseWithoutData{
                StatusCode = 200,
                Success = true,
                Message = "Document record was created successfully"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(string id)
        {
            
            var document = await _documentService.GetDocumentByIdAsync(id);
            
            if (document == null)
            {
                return NotFound(new ServiceResponseWithoutData{
                    StatusCode = 404,
                    Success = false,
                    Message = "Document record does not exist"
                });
            }

            await _documentService.DeleteDocumentAsync(id);
            
            return Ok(new ServiceResponseWithoutData{
                StatusCode = 200,
                Success = true,
                Message = "Document record was deleted successfully"
            });

        }
        [HttpGet]
        public async Task<ActionResult<ServiceReponse<IEnumerable<DocumentModel>>>> GetAllDocument()
        {
            return Ok(new ServiceReponse<IEnumerable<DocumentModel>>{
                StatusCode = 200,
                Success = true,
                Message = "Retrived document record",
                Data = await _documentService.GetAllDocumentsAsync()
            });
        }
    }
}