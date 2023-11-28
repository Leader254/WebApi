using System.ComponentModel.DataAnnotations;

namespace WebApi_Prac.Models.Dtos
{
  public class VillaDTO
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = "";
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
  }
}
