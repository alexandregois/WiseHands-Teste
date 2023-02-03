using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;
using TestWorkAPP.Model;

namespace TestWorkAPP.Interface
{
    public interface IProdutos
    {
        [Get("/api/produtos")]
        Task<List<Produto>> GetProdutos();
    }
}
