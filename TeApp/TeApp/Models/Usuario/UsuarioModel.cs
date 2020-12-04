using System;

namespace TeApp.Models.Usuario
{
    public class UsuarioModel
    {
        public short idResponsavel { get; set; }

        public string nomeResponsavel { get; set; }

        public string email { get; set; }


        public short idCrianca { get; set; }

        public string nomeCrianca { get; set; }

        public DateTime dataNascimentoCrianca { get; set; }

        public string sexoCrianca { get; set; }
    }
}
