using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Server.DataAccess.Documents;
using Server.Dtos.Document;
using Server.Models.Document;

namespace Server.Services.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        public DocumentService(IDocumentRepository documentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
        }
        public async Task CreateDocumentAsync(CreateDocumentDto dto)
        {
            var document = new DocumentModel{
                DocumentId = Guid.NewGuid().ToString(),
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

        public async Task<IEnumerable<ReadDocumentDto>> GetAllDocumentsAsync()
        {
            var documents = await _documentRepository.GetAllDocumentsAsync();
           return _mapper.Map<IEnumerable<ReadDocumentDto>>(documents);
        }

        public async Task<ReadDocumentDto> GetDocumentByIdAsync(string id)
        {
            var document = await _documentRepository.GetDocumentByIdAsync(id);
            return _mapper.Map<ReadDocumentDto>(document);
        }
    }
}