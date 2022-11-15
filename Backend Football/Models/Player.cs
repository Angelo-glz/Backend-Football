using System.ComponentModel.DataAnnotations;

namespace Backend_Football.Models
{
  public class Player
  {

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Position { get; set; }
    [Required]
    public string Status { get; set; }

    public int Number { get; set; }
    [Required]
    public decimal Rating { get; set; }

  }
}
