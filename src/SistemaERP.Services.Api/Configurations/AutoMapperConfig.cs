using AutoMapper;
using SistemaERP.Application.ViewModels;
using SistemaERP.Application.ViewModels.Cliente;
using SistemaERP.Domain.Entities;

namespace SistemaERP.Services.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco_Fornecedor, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
            CreateMap<ImagemViewModel, Imagem_Produto>().ReverseMap();

            CreateMap<ProdutoInsertViewModel, Produto>().ReverseMap();



            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.nome))
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.nome));

            CreateMap<Produto, ProdutoClienteViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.nome));


        }
    }
}
