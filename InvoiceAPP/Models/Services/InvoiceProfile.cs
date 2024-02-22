using AutoMapper;
using InvoiceAPP.Models.DTO;

namespace InvoiceAPP.Models.Services
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {        
            CreateMap<InvoiceEntity, InvoiceDTO>().ReverseMap();
        }
    }
}
