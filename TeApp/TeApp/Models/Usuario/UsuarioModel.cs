using System;

namespace TeApp.Models.Usuario
{
    public class UsuarioModel
    {
        public short IdResponsavel { get; set; }

        public string NomeResponsavel { get; set; }

        public string Email { get; set; }


        public short IdCrianca { get; set; }

        public string NomeCrianca { get; set; }

        public DateTime DataNascimentoCrianca { get; set; }

        public string SexoCrianca { get; set; }
    }
}
