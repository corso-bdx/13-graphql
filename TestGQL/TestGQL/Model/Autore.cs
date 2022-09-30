using System.ComponentModel.DataAnnotations.Schema;

namespace TestGQL.Model {
    
    [Table("Autore", Schema = "Books")]
    public class Autore {
        public int AutoreID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public DateTime DataNascita { get; set; }
        public string LuogoNascita { get; set; } = string.Empty;
        public DateTime? DataMorte { get; set; }
        public string? LuogoMorte { get; set; } = string.Empty;
        public bool InAttivita { get; set; }
    }
}
