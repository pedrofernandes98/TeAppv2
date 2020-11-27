using System;

namespace TeApp.Models.Usuario
{
    class UsuarioUpdateModel
    {
        public short IdResponsavel { get; set; }

        public string NomeResponsavel { get; set; }

        public string NovaSenha { get; set; }

        public string AntigaSenha { get; set; }


        public short IdCrianca { get; set; }

        public string NomeCrianca { get; set; }

        public DateTime? DataNascimentoCrianca { get; set; }

        public string SexoCrianca { get; set; }
    }
}
