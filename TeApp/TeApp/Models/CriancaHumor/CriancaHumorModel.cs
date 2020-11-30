using System;

namespace TeApp.Models.CriancaHumor
{
    public class CriancaHumorModel
    {
        public int idHumorCrianca { get; set; }
        public short? idCrianca { get; set; }
        public short? idHumor { get; set; }
        public DateTime data { get; set; }
        public string observacao { get; set; }

        public CriancaHumorModel()
        {

        }

        public CriancaHumorModel(int IdHumorCrianca, short? IdCrianca, short? IdHumor, DateTime Data, string Observacao)
        {
            idHumorCrianca = IdHumorCrianca;
            idCrianca = IdCrianca;
            idHumor = IdHumor;
            data = Data;
            observacao = Observacao;
        }
    }
}
