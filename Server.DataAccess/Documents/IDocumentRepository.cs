using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.Document;

namespace Server.DataAccess.Documents
{
    public interface IDocumentRepository
    {
         Task CreateDocumentAsync(DocumentModel model);
         Task<DocumentModel> GetDocumentByIdAsync(string id);
         Task<IEnumerable<DocumentModel>> GetAllDocumentsAsync();
         Task DeleteDocumentAsync(string id);
         
    }
}