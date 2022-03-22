using Produto1.Controllers.DAO;
using Produto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produto1.Controllers.Service
{
    internal class ProdutoService
    {
        ProdutoDAO dao = new ProdutoDAO();

        public void InsertRecord(Produto produto)
        {
            dao.InsertRecord(produto);
        }

        public void UpdateRecord(Produto produto)
        {
            dao.UpdateRecord(produto);
        }

        public void DeleteRecord(Produto produto)
        {
            dao.DeleteRecord(produto);
        }

        public List<Produto> GetAllRecords()
        {
            return dao.GetAllRecords();
        }

    }
}
