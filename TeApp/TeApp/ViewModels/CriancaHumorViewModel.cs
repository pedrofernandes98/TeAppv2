using System;
using System.Collections.Generic;
using System.Text;

namespace TeApp.ViewModels
{
    class CriancaHumorViewModel
    {
        public int Id { get; set; }

        public int IdCrianca { get; set; }
        public string Humor { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }

        public bool HasObservacao { get; set; }

    }
}
