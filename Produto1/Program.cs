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
            Produto produto;

            ProdutoController produtoController = new ProdutoController();
            while (true) 
            {
                List<Produto> listaProdutos = produtoController.GetAllRecords();


                foreach (Produto produtos in listaProdutos)
                {
                    Console.Write(produtos.id + " ");
                    Console.WriteLine(produtos.descricao);
                       
                }
                Console.WriteLine(" ");

                produto = new Produto();
                Console.WriteLine("Qual operação deseja fazer? ");
                Console.WriteLine("0 - Criar produto | 1 - Atualizar Produto | 2 - Deletar Produto");

                operacaoDesejada = Convert.ToInt32(Console.ReadLine());

                if (operacaoDesejada == 0)
                {
                    Console.Write("Insira a Descricao do Produto: ");
                    produto.descricao = Console.ReadLine();

                    try
                    {
                        produtoController.InsertRecord(produto);
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
                    produto.id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Insira a Descricao voce quer inserir: ");
                    produto.descricao = Console.ReadLine();

                    try
                    {
                        produtoController.UpdateRecord(produto);
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
                    produto.id = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        produtoController.DeleteRecord(produto); ;
                        Console.WriteLine("Inserido com sucesso");
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
        //private static void TestConnection()
        //{
        //    using (NpgsqlConnection con = GetConnection())
        //    {
        //        con.Open();
        //        if (con.State == System.Data.ConnectionState.Open)
        //        {
        //            Console.WriteLine("Conectado");
        //        }
        //    }
        //}

        //private static void InsertRecord()
        //{
        //    using (NpgsqlConnection con = GetConnection())
        //    {
        //        //string query = @"insert into public.Produto(Descricao) values('" + Produto.Descricao + "')";
        //        string query = @"insert into public.Produto(Id,Descricao) values(1,'Produto1')";
        //        NpgsqlCommand cmd = new NpgsqlCommand(query, con);
        //        con.Open();
        //        int n = cmd.ExecuteNonQuery();
        //        if (n == 1)
        //        {
        //            Console.WriteLine("sucesso insert");
        //        }
        //    }
        //}
        //private static NpgsqlConnection GetConnection()
        //{
        //    return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=Produto;");
        //}
    }
}
