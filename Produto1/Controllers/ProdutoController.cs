using Npgsql;
using Produto1.Controllers.Service;
using Produto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto1.Controllers
{
    internal class ProdutoController
    {
        public Produto produto { get; set; }
        public List<Produto> listaProdutos { get; set; }
        private ProdutoService produtoService;

        public ProdutoController()
        {
            produtoService = new ProdutoService();
            produto = new Produto();
            listaProdutos = produtoService.GetAllRecords();
        }

        public void salvaProduto()
        {
            produtoService.InsertRecord(produto);
            listaProdutos = produtoService.GetAllRecords();
            produto = new Produto();
        }

        public void atualizaProduto()
        {
            produtoService.UpdateRecord(produto);
            listaProdutos = produtoService.GetAllRecords();
            produto = new Produto();
        }

        public void deletaProduto()
        {
            produtoService.DeleteRecord(produto);
            listaProdutos = produtoService.GetAllRecords();
            produto = new Produto();
        }
    }
}
