using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restApiAnkiety.Models;
using restApiAnkiety;
using System;
using System.Linq;
using System.Threading.Tasks;
using restApiAnkiety.Models;

namespace restApiAnkiety.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnkietaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnkietaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAnkiety()
        {
            var ankiety = await _context.Forms
                .Include(f => f.Options)
                .ToListAsync();

            return Ok(ankiety);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnkieta([FromBody] Form form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.Question))
                return BadRequest("Niepoprawna ankieta.");

            form.ReleaseDate = DateTime.Now;

            _context.Forms.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnkietaById), new { id = form.Id }, form);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnkietaById(int id)
        {
            var form = await _context.Forms
                .Include(f => f.Options)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (form == null) return NotFound();

            return Ok(form);
        }

        [HttpPost("odpowiedz")]
        public async Task<IActionResult> DodajOdpowiedz([FromBody] OdpowiedzDto dto)
        {
            try
            {
                Console.WriteLine($"DANE ODEBRANE: {dto.Forma}, {string.Join(", ", dto.Czestosc)}, {string.Join(", ", dto.Tematyka)}");

                var answers = new List<Answer>();

                var formaOption = await _context.Options.FirstOrDefaultAsync(o => o.Description == dto.Forma);
                if (formaOption != null)
                {
                    formaOption.Votes++;
                    answers.Add(new Answer { FormId = formaOption.FormId, OptionId = formaOption.Id, AnswerDate = DateTime.Now });
                }

                foreach (var cz in dto.Czestosc)
                {
                    var opt = await _context.Options.FirstOrDefaultAsync(o => o.Description == cz);
                    if (opt != null)
                    {
                        opt.Votes++;
                        answers.Add(new Answer { FormId = opt.FormId, OptionId = opt.Id, AnswerDate = DateTime.Now });
                    }
                }

                foreach (var temat in dto.Tematyka)
                {
                    var opt = await _context.Options.FirstOrDefaultAsync(o => o.Description == temat);
                    if (opt != null)
                    {
                        opt.Votes++;
                        answers.Add(new Answer { FormId = opt.FormId, OptionId = opt.Id, AnswerDate = DateTime.Now });
                    }
                }

                _context.Answers.AddRange(answers);
                await _context.SaveChangesAsync();

                Console.WriteLine("ODPOWIEDZI ZAPISANE");

                return Ok(new { message = "Odpowiedź zapisana." });
            }
            catch (Exception ex)
            {
                Console.WriteLine("BŁĄD BACKENDU: " + ex.ToString()); 
                return StatusCode(500, "Wystąpił błąd wewnętrzny serwera.");
            }
        }







    }
}
