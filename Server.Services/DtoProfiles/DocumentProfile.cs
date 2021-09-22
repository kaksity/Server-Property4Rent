using AutoMapper;
using Server.Dtos.Document;
using Server.Models.Document;

namespace Server.Services.DtoProfiles
{
    public class DocumentProfile:Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentModel,ReadDocumentDto>();
        }
    }
}