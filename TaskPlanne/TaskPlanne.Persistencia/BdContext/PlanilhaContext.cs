using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskPlanner.Dominio;

namespace TaskPlanne.Persistencia.BdContext
{
    public class PlanilhaContext : DbContext
    {
        public PlanilhaContext(DbContextOptions<PlanilhaContext> opcoes) : base (opcoes) { }

        public DbSet<Tarefa> Tarefas { get; set; } 
        public DbSet<QuadroDeTarefas> QuadroDeTarefas{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuadroDeTarefas>().HasData
            (
                new QuadroDeTarefas
                {
                    IdQuadro = 1,
                    Titulo = $"Tarefas {1}° semana"
                },
                new QuadroDeTarefas
                {
                    IdQuadro = 2,
                    Titulo = $"Tarefas {2}° semana"
                }
                ,
                new QuadroDeTarefas
                {
                    IdQuadro = 3,
                    Titulo = $"Tarefas {3}° semana"
                }
            );

            modelBuilder.Entity<Tarefa>().HasData
            (
                new Tarefa { IdTarefa = 1, QuadroId = 1, Titulo = "1° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(1), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7" },
                new Tarefa { IdTarefa = 2, QuadroId = 1, Titulo = "1° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(2), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6" },
                new Tarefa { IdTarefa = 3, QuadroId = 1, Titulo = "1° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(3), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6" },
                new Tarefa { IdTarefa = 4, QuadroId = 1, Titulo = "1° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(4), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7" },
                new Tarefa { IdTarefa = 5, QuadroId = 1, Titulo = "1° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(5), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7" },
                new Tarefa { IdTarefa = 6, QuadroId = 1, Titulo = "1° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(6), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8" },
                new Tarefa { IdTarefa = 7, QuadroId = 1, Titulo = "1° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(7), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9" },

                new Tarefa { IdTarefa = 8, QuadroId = 2, Titulo = "2° Segunda-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(8), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7" },
                new Tarefa { IdTarefa = 9, QuadroId = 2, Titulo = "2° Terça-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(9), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6" },
                new Tarefa { IdTarefa = 10, QuadroId = 2, Titulo = "2° Quarta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(10), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 6" },
                new Tarefa { IdTarefa = 11, QuadroId = 2, Titulo = "2° Quinta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(11), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7" },
                new Tarefa { IdTarefa = 12, QuadroId = 2, Titulo = "2° Sexta-Feira", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(12), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 7" },
                new Tarefa { IdTarefa = 13, QuadroId = 2, Titulo = "2° Sábado", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(13), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 8" },
                new Tarefa { IdTarefa = 14, QuadroId = 2, Titulo = "2° Domingo", DataCriacao = DateTime.Today, DataInicializacao = DateTime.Today.AddDays(14), IsAtivo = false, IsConcluido = false, Descricao = "Acordar às 9" }
            );
        }
    }
}
