using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.DataAccess.Documents;
using Server.Dtos.Document;
using Server.Models.Document;

namespace Server.Services.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        public async Task CreateDocumentAsync(RequestDocumentDto dto)
        {
            var document = new DocumentModel{
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name.ToUpper(),
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _documentRepository.CreateDocumentAsync(document);
        }

        public async Task DeleteDocumentAsync(string id)
        {
            await _documentRepository.DeleteDocumentAsync(id);
        }

        public async Task<IEnumerable<DocumentModel>> GetAllDocumentsAsync()
        {
           return await _documentRepository.GetAllDocumentsAsync();
        }

        public async Task<DocumentModel> GetDocumentByIdAsync(string id)
        {
            return await _documentRepository.GetDocumentByIdAsync(id);
        }
    }
}