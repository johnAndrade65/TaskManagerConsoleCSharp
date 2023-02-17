using System;

namespace TasksManager
{   
    class Program
    {   
        //Define uma lista de objetos Tarefa que será usada para armazenar as tarefas adicionadas pelos usuários.
        static List<Tarefa> tarefas = new List<Tarefa>();

        static void Main(string[] args)
        {
            //Variavel usada para controlar o loop principal do programa.
            bool running = true;

            //Enquanto running for verdadeiro o codigo dentro desse While será executado(O Programa).
            while (running)
            {   
                //Menu inicial do programa
                Console.WriteLine("Gerenciador de Tarefas");
                Console.WriteLine("1 - Adicionar tarefa");
                Console.WriteLine("2 - Exibir tarefas");
                Console.WriteLine("3 - Encerrar o programa");

                string input = Console.ReadLine();
                int choice = int.Parse(input);

                /*O metodo será chamado de acordo com o valor passado pelo usuario na váriavel 
                input que será armazenado transformado em inteiro na variavel "choice"*/
                switch (choice)
                {
                    case 1:
                        AdicionarTarefa();
                        break;
                    case 2:
                        ExibirTarefas();
                        break;
                    case 3:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Escolha inválida");
                        break;
                }
            }
        }

        //Método para adicionar tarefa
        static void AdicionarTarefa()
        {   
            //Menu da área de adicionar tarefas
            Console.Clear();
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();
            Console.Write("Digite a data de início (dd/mm/aaaa): ");
            string dataInicioString = Console.ReadLine();
            DateTime dataInicio = DateTime.Parse(dataInicioString);
            Console.Write("Digite a data de conclusão (dd/mm/aaaa): ");
            string dataConclusaoString = Console.ReadLine();
            DateTime dataConclusao = DateTime.Parse(dataConclusaoString);

            /*O método "adicionarTarefa" pede ao usuário que insira informações sobre a nova tarefa,
             cria um objeto "Tarefa" com essas informações e adiciona-o à lista tarefas.*/
            Tarefa tarefa = new Tarefa()
            {
                Descricao = descricao,
                DataInicio = dataInicio,
                DataConclusao = dataConclusao
            };

            //Armazena os valores de "tarefa" em "tarefas"
            tarefas.Add(tarefa);
        }

        //Método com função de exibir as tarefas
        static void ExibirTarefas()
        {   
            //Menu da tela de exibir tarefas
            Console.WriteLine("Tarefas:");
            //O foreach percorre cada tarefa e as exibe no console
            foreach (Tarefa tarefa in tarefas)
            {   
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Data de início: {tarefa.DataInicio.ToShortDateString()}");
                Console.WriteLine($"Data de conclusão: {tarefa.DataConclusao.ToShortDateString()}");
                Console.WriteLine("\n");
            }
        }
    }
}
