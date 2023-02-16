using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
     

        public Guid CategoriaId { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Categoria Categoria{ get; private set; }

        public Produto( string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem,Guid categoriaId )
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
           
        }

        public void AtivarProduto() => Ativo = true;
        public void DesativarProduto() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }


        public void AlterarDescricaoProduto(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            quantidade += quantidade;
        }
        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {

        }
    }


    public class Categoria:Entity
    {
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public string Nome { get; set; }
        public int Codigo { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}"; 
        }


    }
}
