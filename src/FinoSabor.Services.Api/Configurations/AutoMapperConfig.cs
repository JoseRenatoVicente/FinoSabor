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
            CreateMap<EnderecoFornecedor, EnderecoViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
            CreateMap<CategoriaViewModel, Categoria>().ReverseMap();

            
            CreateMap<ImagemViewModel, ImagemProduto>().ReverseMap();

            

            CreateMap<Compra, CompraViewModel>()
                .ForMember(dest => dest.nomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.Quantidade * c.ValorUnitario)));

            CreateMap<Compra, CompraDetalhadaViewModel>()
                .ForMember(dest => dest.nomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.Quantidade * c.ValorUnitario)));

            CreateMap<Compra, CompraAddViewModel>().ReverseMap();
            CreateMap<ItensCompra, Itens_CompraAddViewModel>().ReverseMap();

            CreateMap<ItensCompra, Itens_CompraViewModel>()
                .ForMember(dest => dest.nomeProduto, opt => opt.MapFrom(src => src.Produto.Nome))
                .ForMember(dest => dest.valor_item, opt => opt.MapFrom(src => src.Quantidade * src.ValorUnitario));

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Nome));

            CreateMap<Produto, ProdutoClienteViewModel>()
                .ForMember(dest => dest.SlugCategoria, opt => opt.MapFrom(src => src.Categoria.Slug))
                .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Nome));

            // Pessoa

            CreateMap<PessoaViewModel, Pessoa>().ReverseMap();

            CreateMap<Pessoa, PessoaDetalhesViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.UserName));

            CreateMap<PessoaUpdateViewModel, Pessoa>().ReverseMap();

            // Pedido
            CreateMap<PedidoInsertViewModel, Pedido>().ReverseMap();
            CreateMap<Itens_PedidoInsertViewModel, ItensPedido>().ReverseMap();

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.Quantidade * c.ValorUnitario)));

            CreateMap<Pedido, PedidoDetalhadoViewModel>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Itens.Sum(c => c.Quantidade * c.ValorUnitario)));

            CreateMap<ItensPedido, Itens_PedidoViewModel>()
                .ForMember(dest => dest.nomeProduto, opt => opt.MapFrom(src => src.Produto.Nome))
                .ForMember(dest => dest.valor_item, opt => opt.MapFrom(src => src.Quantidade * src.ValorUnitario));

            CreateMap<ProdutoInsertViewModel, Produto>().ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(dest => dest.cpf, opt => opt.MapFrom(src => src.Pessoa.Cpf))
                .ForMember(dest => dest.data_cadastro, opt => opt.MapFrom(src => src.Pessoa.DataCadastro))
                .ForMember(dest => dest.data_nascimento, opt => opt.MapFrom(src => src.Pessoa.DataNascimento));

            CreateMap<ProdutoClienteObterTodosViewModel, Produto>().ReverseMap();

           


        }
    }
}