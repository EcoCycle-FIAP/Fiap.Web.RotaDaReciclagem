namespace Fiap.Web.RotaDaReciclagem.Models
{
    public class CaminhaoModel
    {
        public int CaminhaoId { get; set; }
        public string Motorista { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int CapacidadeLitros { get; set; }

        public List<AgendamentoModel> Agendamentos { get; set; }

        public List<RotaModel> Rotas { get; set; }
    }
}
