namespace Fiap.Web.RotaDaReciclagem.Models
{
    public class RotaModel
    {
        public int RotaId { get; set; }
        public string PontosDeColeta { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }

        public int CaminhaoId { get; set; }
        public CaminhaoModel Caminhao { get; set; }
    }
}
