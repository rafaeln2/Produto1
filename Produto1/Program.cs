using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Produto1.Controllers;
using Produto1.Models;

namespace Produto1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operacaoDesejada;
            
            ProdutoController produtoController = new ProdutoController();
            while (true) 
            {
                
                foreach (Produto produtos in produtoController.listaProdutos)
                {
                    Console.Write(produtos.id + " ");
                    Console.WriteLine(produtos.descricao);
                       
                }
                Console.WriteLine(" ");
                
                Console.WriteLine("Qual operação deseja fazer? ");
                Console.WriteLine("0 - Criar produto | 1 - Atualizar Produto | 2 - Deletar Produto");

                operacaoDesejada = Convert.ToInt32(Console.ReadLine());

                if (operacaoDesejada == 0)
                {
                    Console.Write("Insira a Descricao do Produto: ");
                    produtoController.produto.descricao = Console.ReadLine();

                    try
                    {
                        produtoController.salvaProduto();
                        Console.WriteLine("Inserido com sucesso");
                        Console.WriteLine(" ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
                else if (operacaoDesejada == 1)
                {
                    Console.WriteLine("Insira o Id do produto para ser alterado: ");
                    produtoController.produto.id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Insira a Descricao voce quer inserir: ");
                    produtoController.produto.descricao = Console.ReadLine();

                    try
                    {
                        produtoController.atualizaProduto();
                        Console.WriteLine("Atualizado com sucesso");
                        Console.WriteLine(" ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
                else if (operacaoDesejada == 2)
                {
                    Console.Write("Insira Id do produto para ser exluido: ");
                    produtoController.produto.id = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        produtoController.deletaProduto(); ;
                        Console.WriteLine("Deletado com sucesso");
                        Console.WriteLine(" ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
                
            }
        }
    }
}
