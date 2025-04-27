using Microsoft.AspNetCore.Mvc;

namespace tpmodul10_103022300121.Controllers
{
    [ApiController]
    [Route("api/mahasiswa")]
    public class MahasiswaController : ControllerBase
    {
        private static readonly List<Mahasiswa> MahasiswaList = new()
        {
            new Mahasiswa { Nama = "Lebron James", Nim = "12345678" },
            new Mahasiswa { Nama = "Mark Ruffalo", Nim = "87654321" },
            new Mahasiswa { Nama = "Pedro Pascal", Nim = "11223344" }
        };

        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(MahasiswaList);
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= MahasiswaList.Count)
            {
                return NotFound("Mahasiswa not found at the given index.");
            }

            return Ok(MahasiswaList[index]);
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult Add([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null || string.IsNullOrEmpty(newMahasiswa.Nama) || string.IsNullOrEmpty(newMahasiswa.Nim))
            {
                return BadRequest("Invalid Mahasiswa data.");
            }

            MahasiswaList.Add(newMahasiswa);
            return CreatedAtAction(nameof(GetByIndex), new { index = MahasiswaList.Count - 1 }, newMahasiswa);
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= MahasiswaList.Count)
            {
                return NotFound("Mahasiswa not found at the given index.");
            }

            MahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
