using Microsoft.EntityFrameworkCore;

namespace TAREFAS.Model 
{
    public class Tarefa 
    {
        public int TarefaId {get; set;}
        public string Descricao {get; set;}
        public bool Realizado {get; set;}
    }
}