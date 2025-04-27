using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        // Static list untuk menyimpan data mahasiswa
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa("Muhammad Salman Al Farizy", "103022300113"),
            new Mahasiswa("LeBron James", "1302000001"),
            new Mahasiswa("Stephen Curry", "1302000002"),
            new Mahasiswa("Kevin De Bruyne", "1302000003")

        };



        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return Ok(mahasiswaList);
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }
            return Ok(mahasiswaList[index]);
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(GetByIndex), new { index = mahasiswaList.Count - 1 }, mahasiswa);
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound();
            }
            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
