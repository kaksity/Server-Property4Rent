using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.Document;
using Server.Models.Document;

namespace Server.Services.Document
{
    public interface IDocumentService
    {
        Task CreateDocumentAsync(RequestDocumentDto dto);
         Task<DocumentModel> GetDocumentByIdAsync(string id);
         Task<IEnumerable<DocumentModel>> GetAllDocumentsAsync();
         Task DeleteDocumentAsync(string id);
    }
}