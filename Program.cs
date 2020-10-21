using System;
using System.Linq;
using TAREFAS.Model;

namespace Tarefas
{
    class Program
    {
        public static void InserirTarefa(TarefaContext db)
        {
            string descricao ="";
             Console.WriteLine("\nInserindo uma nova tarefa: ");
             descricao = Console.ReadLine();
                 db.Add(new Tarefa { Descricao =descricao , Realizado=false});
                 db.SaveChanges();
        }

        public static void ListarTarefas(TarefaContext db)
        {
            Console.WriteLine("\n****Todas as tarefas****\n");
                 var tarefas =  db.Tarefas
                    .OrderBy(b => b.TarefaId)
                    .ToList();
                foreach(var tarefa in tarefas )
                {
                    string realizado = tarefa.Realizado ? "sim" : "não";
                    Console.WriteLine(tarefa.TarefaId+" - " + tarefa.Descricao +" | " +" Realizado: " + realizado);
                }
                
        }

        public static void RealizarTarefas(TarefaContext db)
        {
            int tarefaId = BuscaTarefaId(db);
            Console.WriteLine("\n*****Atualizando a tarefa****");
            var tarefa = db.Tarefas
                .Where(t => t.TarefaId == tarefaId)
                .FirstOrDefault();
            tarefa.Realizado = true;
            db.SaveChanges();
            Console.WriteLine("Tarefa: "+ tarefa.Descricao+ "realizada com sucesso!");

        }

        public static int BuscaTarefaId(TarefaContext db)
        {
            ListarTarefas(db);
            Console.WriteLine("\nEscolha uma tarefa pelo seu número: ");
            int id = Int32.Parse(Console.ReadLine());
            return id;
        }

        public static void DeletarTarefas(TarefaContext db)
        {
            Console.WriteLine("\n*****Deletando a tarefa*****");
            int tarefaId = BuscaTarefaId(db);
            var tarefa = db.Tarefas
                .Where(t => t.TarefaId == tarefaId)
                .FirstOrDefault();
            Console.WriteLine("Tarefa: "+ tarefa.Descricao+ "excluída com sucesso!");
            db.Remove(tarefa);
            db.SaveChanges();
            
        }
        static void Main(string[] args)
        {   

             using (var db = new TarefaContext())
             {
                 int op = -1;
                 do
                 {
                     Console.WriteLine("\n****Suas Tarefas*****\n\n"
                                         +"1 - Nova Tarefa\n"
                                         +"2 - Mostrar Tarefas\n"
                                         +"3 - Realizar Tarefa\n"
                                         +"4 - Excluir Tarefa\n"
                                         +"0 - Sair\n");
                    op = Int32.Parse(Console.ReadLine());
                     switch (op)
                     {
                         case 1:
                            InserirTarefa(db); 
                            break;
                        case 2:
                            ListarTarefas(db);
                            break;
                        case 3:
                            RealizarTarefas(db);
                            break;
                        case 4:
                            DeletarTarefas(db);
                            break;
                        case 0:
                            Console.WriteLine("Saindo....");
                            break;
                        default:
                            Console.WriteLine("Nenhuma Opção válida!");
                            break;
                     }

                 } while(op != 0);
            }
        }
    }
}
