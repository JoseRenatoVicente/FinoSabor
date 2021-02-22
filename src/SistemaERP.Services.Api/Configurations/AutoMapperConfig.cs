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
            CreateMap<FornecedorEndereco, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
            CreateMap<ImagemViewModel, ProdutoImagem>().ReverseMap();

            CreateMap<ProdutoInsertViewModel, Produto>().ReverseMap();



            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Nome))
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));

            CreateMap<Produto, ProdutoClienteViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Nome));


        }
    }
}
