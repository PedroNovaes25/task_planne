using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanne.Aplicacao;
using TaskPlanne.Dominio;
using TaskPlanne.Persistencia.Interface;
using TaskPlanneAplicacao.Interface;

namespace TaskPlanneAplicacao
{
    public class QuadroDeTarefasServico : IQuadroDeTarefasServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IQuadroDeTarefasPersistencia _quadroDeTarefasPersistencia;

        public QuadroDeTarefasServico(IGeralPersistencia geralPersistencia, IQuadroDeTarefasPersistencia quadroDeTarefasPersistencia)
        {
            _geralPersistencia = geralPersistencia;
            _quadroDeTarefasPersistencia = quadroDeTarefasPersistencia;
        }

        public async Task<QuadroInfoDTO> AtualizarQuadro(int idQuadro, QuadroInfoDTO quadroInfoDTO)
        {
            var quadro = await _quadroDeTarefasPersistencia.PegarQuadroPorId(idQuadro);
            if (quadro == null) return null;
            quadroInfoDTO.IdQuadro = quadro.IdQuadro;

            var model = quadroInfoDTO.CopiaParaModel();

            if (await _geralPersistencia.SaveChangesAsync())
            {
                var eventoRetorno = await _quadroDeTarefasPersistencia.PegarQuadroPorId(model.IdQuadro);

                return new QuadroInfoDTO(model);
            }
            return null;
        }

        public async Task<QuadroInfoDTO> CriarQuadro(QuadroInfoDTO quadroInfo)
        {
            var quadroModel = quadroInfo.CopiaParaModel();
            _geralPersistencia.Add<QuadroDeTarefas>(quadroModel);
            if (!await _geralPersistencia.SaveChangesAsync())
                return null;

            return new QuadroInfoDTO(quadroModel);
        }

        public async Task<bool> DeletarQuadro(int idQuadro)
        {
            var quadro = await _quadroDeTarefasPersistencia.PegarQuadroPorId(idQuadro);
            if (quadro == null)
                if (quadro == null) throw new Exception("Quadro para deletar não encontrado.");

            _geralPersistencia.Delete<QuadroDeTarefas>(quadro);

            return await _geralPersistencia.SaveChangesAsync();
        }

        public async Task<QuadroDeTarefasDTO> PegarQuadroPorId(int idQuadro)
        {
            var quadro = await _quadroDeTarefasPersistencia.PegarQuadroPorId(idQuadro);
            if (quadro == null)
                return null;

            return new QuadroDeTarefasDTO(quadro);
        }

        public async Task<List<PlanilhaMenuDTO>> PegarQuadros()
        {
            var quadros = await _quadroDeTarefasPersistencia.PegarQuadros();
            if (quadros == null)
                return null;

            List<PlanilhaMenuDTO> quadrosDto = new List<PlanilhaMenuDTO>();

            foreach (var model in quadros)
            {
                quadrosDto.Add(new PlanilhaMenuDTO(model));
            }

            return quadrosDto;
        }
    }
}
