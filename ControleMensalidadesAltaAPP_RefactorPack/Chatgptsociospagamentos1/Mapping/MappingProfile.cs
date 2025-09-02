using AutoMapper;
using Chatgptsociospagamentos.Models;
using Chatgptsociospagamentos.ViewModels;

namespace Chatgptsociospagamentos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssociadoModel, AssociadoVm>().ReverseMap();
            CreateMap<PagamentoModel, PagamentoVm>().ReverseMap();
            CreateMap<DocumentoModel, DocumentoVm>().ReverseMap();
        }
    }
}
