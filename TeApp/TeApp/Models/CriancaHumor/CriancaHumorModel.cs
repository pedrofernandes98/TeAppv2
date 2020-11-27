using System;

namespace TeApp.Models.CriancaHumor
{
    public class CriancaHumorModel
    {
        public int IdHumorCrianca { get; set; }
        public short? IdCrianca { get; set; }
        public short? IdHumor { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }

        public CriancaHumorModel()
        {

        }

        public CriancaHumorModel(int idHumorCrianca, short? idCrianca, short? idHumor, DateTime data, string observacao)
        {
            IdHumorCrianca = idHumorCrianca;
            IdCrianca = idCrianca;
            IdHumor = idHumor;
            Data = data;
            Observacao = observacao;
        }
    }
}
