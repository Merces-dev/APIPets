using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca r);
        List<Raca> LerTodos();
        Raca BuscarPorId(int Id);
        Raca Alterar(int id, Raca r);
        void Excluir(int id);



    }
}
