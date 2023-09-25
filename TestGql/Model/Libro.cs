using System.ComponentModel.DataAnnotations.Schema;

namespace TestGql.Model; 

[Table("Libro", Schema = "Books")]
public class Libro {
    public int LibroID { get; set; }
    public string Titolo { get; set; } = string.Empty;
    public int AutoreID { get; set; }
    public decimal Prezzo { get; set; }
    public bool BestSeller { get; set; }
    public int CasaEditriceID { get; set; }
    public Autore? Autore { get; set; }
    public CasaEditrice? CasaEditrice { get; set; }
}
