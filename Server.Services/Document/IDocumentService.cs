using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.Document;
using Server.Models.Document;

namespace Server.Services.Document
{
    public interface IDocumentService
    {
        Task CreateDocumentAsync(CreateDocumentDto dto);
         Task<ReadDocumentDto> GetDocumentByIdAsync(string id);
         Task<IEnumerable<ReadDocumentDto>> GetAllDocumentsAsync();
         Task DeleteDocumentAsync(string id);
    }
}