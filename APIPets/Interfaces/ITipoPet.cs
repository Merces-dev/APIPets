using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface ITipoPet
    {
        TipoPet Cadastrar(TipoPet t);
        List<TipoPet> LerTodos();
        TipoPet BuscarPorId(int Id);
        TipoPet Alterar(int id, TipoPet r);
        void Excluir(int id);
    }
}
