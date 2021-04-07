using AutoMapper;
using FinoSabor.Application.ViewModels;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;

namespace FinoSabor.Services.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco_Fornecedor, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();
            CreateMap<ImagemViewModel, Imagem_Produto>().ReverseMap();

            CreateMap<ProdutoInsertViewModel, Produto>().ReverseMap();


            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.nome));
                //.ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.nome));


            CreateMap<Produto, ProdutoClienteViewModel>()
                .ForMember(dest => dest.SlugCategoria, opt => opt.MapFrom(src => src.Categoria.slug))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.nome));


            CreateMap<ProdutoClienteObterTodosViewModel, Produto>().ReverseMap();


        }
    }
}
