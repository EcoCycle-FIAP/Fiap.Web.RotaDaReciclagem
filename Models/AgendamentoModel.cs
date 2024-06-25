namespace Fiap.Web.RotaDaReciclagem.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }
        public DateTime Data { get; set; }
        public string TipoResiduo { get; set; }
        public int QuantidadeLitros { get; set; }

        public int CaminhaoId { get; set; }
        public CaminhaoModel Caminhao { get; set; }

        public int MoradorId { get; set; }
        public MoradorModel Morador { get; set; }
    }
}
