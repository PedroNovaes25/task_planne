﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Aplicacao;

namespace TaskPlanner.Aplicacao.Interface
{
    public interface IQuadroDeTarefasServico
    {
        Task<QuadroInfoDTO> CriarQuadro(QuadroInfoDTO quadroInfo);
        Task<List<PlanilhaMenuDTO>> PegarQuadros();
        Task<QuadroDeTarefasDTO> PegarQuadroPorId(int idQuadro);
        Task<bool> DeletarQuadro(int idQuadro);
        Task<QuadroInfoDTO> AtualizarQuadro(int idQuadro, QuadroInfoDTO quadroInfoDTO);

    }
}
