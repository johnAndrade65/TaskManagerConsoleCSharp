using System;

namespace TasksManager
{   
    /*A class Tarefa, possui três propriedades: Descricao(string), 
    DataInicio(DateTime) e DataConclusao(DateTime). 
    Essas propriedades podem ser acessadas e definidas usando os métodos get e set.*/
    class Tarefa
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
