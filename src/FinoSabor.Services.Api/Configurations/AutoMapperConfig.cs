using AutoMapper;
using FinoSabor.Application.ViewModels;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Domain.ViewModels.Cliente.Pedido;
using FinoSabor.Domain.ViewModels.Pessoa;
using System.Linq;

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

            

            CreateMap<Compra, CompraViewModel>()
                .ForMember(dest => dest.nomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.nome))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.quantidade * c.valor_unitario)));

            CreateMap<Compra, CompraDetalhadaViewModel>()
                .ForMember(dest => dest.nomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.nome))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.quantidade * c.valor_unitario)));

            CreateMap<Compra, CompraAddViewModel>().ReverseMap();
            CreateMap<Itens_Compra, Itens_CompraAddViewModel>().ReverseMap();

            CreateMap<Itens_Compra, Itens_CompraViewModel>()
                .ForMember(dest => dest.nomeProduto, opt => opt.MapFrom(src => src.Produto.nome))
                .ForMember(dest => dest.valor_item, opt => opt.MapFrom(src => src.quantidade * src.valor_unitario));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.nome));

            CreateMap<Produto, ProdutoClienteViewModel>()
                .ForMember(dest => dest.SlugCategoria, opt => opt.MapFrom(src => src.Categoria.slug))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.nome));

            // Pessoa

            CreateMap<PessoaViewModel, Pessoa>().ReverseMap();

            CreateMap<Pessoa, PessoaDetalhesViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.UserName));

            CreateMap<PessoaUpdateViewModel, Pessoa>().ReverseMap();

            // Pedido
            CreateMap<PedidoInsertViewModel, Pedido>().ReverseMap();
            CreateMap<Itens_PedidoInsertViewModel, Itens_Pedido>().ReverseMap();

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.quantidade * c.valor_unitario)));

            CreateMap<Pedido, PedidoDetalhadoViewModel>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.quantidade * c.valor_unitario)));

            CreateMap<Itens_Pedido, Itens_PedidoViewModel>()
                .ForMember(dest => dest.nomeProduto, opt => opt.MapFrom(src => src.Produto.nome))
                .ForMember(dest => dest.valor_item, opt => opt.MapFrom(src => src.quantidade * src.valor_unitario));

            CreateMap<ProdutoInsertViewModel, Produto>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.cpf, opt => opt.MapFrom(src => src.Pessoa.cpf))
                .ForMember(dest => dest.data_cadastro, opt => opt.MapFrom(src => src.Pessoa.data_cadastro))
                .ForMember(dest => dest.data_nascimento, opt => opt.MapFrom(src => src.Pessoa.data_nascimento));

            CreateMap<ProdutoClienteObterTodosViewModel, Produto>().ReverseMap();

           


        }
    }
}