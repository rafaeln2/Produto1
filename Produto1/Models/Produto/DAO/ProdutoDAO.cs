using Npgsql;
using Produto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto1.Controllers.DAO
{
    internal class ProdutoDAO
    {
        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=Produto;");
        }

        public void InsertRecord(Produto produto)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "insert into public.Produto(Descricao) values('" + produto.descricao + "')";
                //string query = @"insert into public.Produto(Id,Descricao) values(1,'Produto1')";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("sucesso insert");
                    Console.WriteLine(" ");
                }

            }
        }

        public void UpdateRecord(Produto produto)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "update produto set descricao = '" + produto.descricao + "' where id = " + produto.id;
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("sucesso update");
                    Console.WriteLine(" ");
                }

            }

        }

        public void DeleteRecord(Produto produto)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "delete from public.produto where produto.id = " + produto.id;
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("sucesso delete");
                    Console.WriteLine(" ");
                }

            }
        }

        public List<Produto> GetAllRecords()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "select * from public.produto";
                List<Produto> RetornoProdutos = new List<Produto>();
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                Produto tempProduto;
                for (int i = 0; dr.Read(); i++)
                {
                    tempProduto = new Produto();

                    tempProduto.id = Convert.ToInt32(dr[0].ToString());
                    tempProduto.descricao = dr[1].ToString();
                    RetornoProdutos.Add(tempProduto);
                }

                return RetornoProdutos;
            }
        }
    }
}
