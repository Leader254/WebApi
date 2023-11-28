using Microsoft.AspNetCore.Mvc;
using WebApi_Prac.Data;
using WebApi_Prac.Models;
using WebApi_Prac.Models.Dtos;

namespace WebApi_Prac.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class VillaAPIController : ControllerBase
  {
    [HttpGet]
    [Route("villa")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<VillaDTO>> GetVillas()
    {
      return Ok(VillaStore.villaList);
    }
    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDTO> GetSingleVilla(int id)
    {
      if (id == 0)
      {
        return BadRequest();
      }
      var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);

      if (villa == null)
      {
        return NotFound();
      }

      return Ok(villa);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villaDto)
    {
      if(villaDto == null)
      {
        return BadRequest(villaDto);
      }
      if(villaDto.Id > 0)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
      VillaStore.villaList.Add(villaDto);

      return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
    }
  }
}
