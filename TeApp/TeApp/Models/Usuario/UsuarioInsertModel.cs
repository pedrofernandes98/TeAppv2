using System;

namespace TeApp.Models.Usuario
{
    public class UsuarioInsertModel
    {
        public string NomeResponsavel { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string SenhaRepetida { get; set; }


        public string NomeCrianca { get; set; }

        public DateTime DataNascimentoCrianca { get; set; }

        public string SexoCrianca { get; set; }
    }
}
