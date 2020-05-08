using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationVeiculo.Models
{
    public class Veiculo
    {
        public ObjectId Id { get; set; }
        public int veiculoId { get; set; }
        public string placa { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public string cor { get; set; }
        public int anoFabricacao { get; set; }
        public string categoria { get; set; }
        public string dataAquisicao { get; set; }

    }
}