using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanne.Aplicacao._Interfaces;
using TaskPlanne.Persistencia.Interface;
using TaskPlanner.Dominio;

namespace TaskPlanne.Aplicacao
{
    public class TarefaServico : ITarefaServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly ITarefaPersistencia _tarefaPersistencia;

        public TarefaServico(IGeralPersistencia geralPersistencia, ITarefaPersistencia tarefaPersistencia)
        {
            _geralPersistencia = geralPersistencia;
            _tarefaPersistencia = tarefaPersistencia;
        }

        public async Task<TarefaDTO> CriarTarefa(TarefaDTO tarefaDTO)
        {
            var model = tarefaDTO.CopiaParaModel();

            _geralPersistencia.Add<Tarefa>(model);
            if (!await _geralPersistencia.SaveChangesAsync())
                return null;

            return new TarefaDTO(model);
        }

        public async Task<TarefaDTO> AtualizarTarefa(int idTarefa, TarefaDTO tarefaDTO)
        {
            var tarefa = await _tarefaPersistencia.PegarTarefaPorId(idTarefa);
            if (tarefa == null) return null;
            tarefaDTO.IdTarefa = tarefa.IdTarefa;

            var model = tarefaDTO.CopiaParaModel();

            if (await _geralPersistencia.SaveChangesAsync())
            {
                var eventoRetorno = await _tarefaPersistencia.PegarTarefaPorId(model.IdTarefa);

                return new TarefaDTO(model);
            }
            return null;
        }

        public async Task<bool> DeletarTarefa(int idTarefa)
        {
            var tarefa = await _tarefaPersistencia.PegarTarefaPorId(idTarefa);
            if (tarefa == null) throw new Exception("Tarefa para deletar não encontrado.");

            _geralPersistencia.Delete<Tarefa>(tarefa);

            return await _geralPersistencia.SaveChangesAsync();
        }

        public async Task<TarefaDTO> PegarTarefaPorId(int idTarefa)
        {
            var tarefa = await _tarefaPersistencia.PegarTarefaPorId(idTarefa);
            if (tarefa == null) return null;

            var tarefaDto = new TarefaDTO(tarefa);

            return tarefaDto;
        }
    }
}
