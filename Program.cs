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
                int choice;

                /*
                1- O método será chamado de acordo com o valor passado pelo usuário na variável `input`,
                que será transformado em inteiro e armazenado na variável `choice` pela função `int.TryParse()`.
                
                2- A função `int.TryParse()` tenta realizar a conversão da string em um número inteiro e retorna
                um valor booleano indicando se a conversão foi bem-sucedida ou não.
                
                3- Se a conversão for bem-sucedida (true), o valor convertido será armazenado na variável `choice`
                por meio do parâmetro `out`. Caso contrário, se a conversão falhar (false), o valor de `choice` permanecerá inalterado.
                */
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AdicionarTarefa();
                            break;
                        case 2:
                            ExibirTarefas();
                            break;
                        case 3:
                            Console.WriteLine("Encerrando..");
                            running = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\nEscolha inválida\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nEscolha inválida\n");
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

            DateTime dataInicio;
            DateTime dataConclusao;

            try
            {
                Console.Write("Digite a data de início (dd/mm/aaaa): ");
                string dataInicioString = Console.ReadLine();
                dataInicio = DateTime.Parse(dataInicioString);

                Console.Write("Digite a data de conclusão (dd/mm/aaaa): ");
                string dataConclusaoString = Console.ReadLine();
                dataConclusao = DateTime.Parse(dataConclusaoString);

                // Resto do código aqui, caso necessário
            }
            catch (FormatException e)
            {
                Console.WriteLine(
                    "\nErro de formato ao converter a data. Certifique-se de digitar a data no formato correto ou válida e tente novamente, Exemplo: 10/07/2021\n"
                );
                return; // Encerra o método em caso de exceção
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "\nOcorreu um erro ao processar as datas. Verifique se as datas estão corretas e tente novamente.\n"
                );
                return; // Encerra o método em caso de exceção
            }

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

            //Se não tiver nenhuma tarefa cadastrada a condicional irá ixibir "Nenhuma tarefa encontrada"
            if (tarefas.Count == 0)
            {
                Console.WriteLine("\nNenhuma tarefa encontrada.\n");
            }
            else
            {
                Console.Clear();
                // O foreach percorre cada tarefa e as exibe no console
                foreach (Tarefa tarefa in tarefas)
                {
                    Console.WriteLine($"\nDescrição: {tarefa.Descricao}");
                    Console.WriteLine($"Data de início: {tarefa.DataInicio.ToShortDateString()}");
                    Console.WriteLine(
                        $"Data de conclusão: {tarefa.DataConclusao.ToShortDateString()}\n"
                    );
                }
            }
        }
    }
}
