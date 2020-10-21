using Microsoft.EntityFrameworkCore;
using TAREFAS.Model;

public class TarefaContext : DbContext
    {
        public DbSet<Tarefa> Tarefas {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("Data source=tarefa.db");
    }