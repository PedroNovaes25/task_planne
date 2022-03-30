using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Aplicacao;
using TaskPlanner.Dominio;
using TaskPlanner.Persistencia.Interface;
using TaskPlanner.Aplicacao.Interface;

namespace TaskPlanner.Aplicacao
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

            _geralPersistencia.Update<QuadroDeTarefas>(model);
            if (await _geralPersistencia.SaveChangesAsync())
            {
                var eventoRetorno = await _quadroDeTarefasPersistencia.PegarQuadroPorId(model.IdQuadro);

                return new QuadroInfoDTO(model);
            }
            return null;
        }

        public async Task<QuadroInfoDTO> CriarQuadro(QuadroInfoDTO quadroInfo)
        {
            var quadro = quadroInfo.CopiaParaModel();
            _geralPersistencia.Add<QuadroDeTarefas>(quadro);

            if (await _geralPersistencia.SaveChangesAsync()) 
            {
                var quadroModel = await _quadroDeTarefasPersistencia.PegarQuadroPorId(quadro.IdQuadro);
                return new QuadroInfoDTO(quadroModel);
            }

            return null;
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
