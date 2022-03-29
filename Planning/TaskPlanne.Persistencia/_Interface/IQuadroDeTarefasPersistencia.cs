﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanne.Dominio;

namespace TaskPlanne.Persistencia.Interface
{
    public interface IQuadroDeTarefasPersistencia
    {
        Task<List<QuadroDeTarefas>> PegarQuadros();

        Task<QuadroDeTarefas> PegarQuadroPorId(int idQuadro);
    }
}
