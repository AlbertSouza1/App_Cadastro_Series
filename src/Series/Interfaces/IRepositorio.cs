using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Interfaces
{
    interface IRepositorio<T>
    {
        List<T> Listar();

        T RetornarPorId(int id);

        void Inserir(T entidade);

        void Excluir(int id);

        void Atualizar(int id, T entidade);

        int ProximoId();
    }
}
