using WebApi_Prac.Models.Dtos;

namespace WebApi_Prac.Data
{
  public static class VillaStore
  {
    public static List<VillaDTO> villaList = new List<VillaDTO>()
      {
        new VillaDTO{Id = 1, Name = "Humming Bird"},
        new VillaDTO{Id = 2, Name = "Nyama Villa" }
      };
  }
}
