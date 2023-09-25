using System.ComponentModel.DataAnnotations.Schema;

namespace TestGql.Model; 

[Table("CasaEditrice",Schema = "Books")]
public class CasaEditrice {
    public int CasaEditriceID { get; set; }
    public string Nome { get; set; } = string.Empty;
}
