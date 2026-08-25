using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Data;
using StudentAPI.Models;



namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        AppDbContext db;
        public StudentAPIController(AppDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public async Task<ActionResult<List<TblStudent>>> GetStudents()
        {
            var students = await db.Tbl_student.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudents(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var student = await db.Tbl_student.FindAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> PostStudents(TblStudent std)
        {
            db.Tbl_student.AddAsync(std);
            await db.SaveChangesAsync();
            return Ok(std);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id,TblStudent std)
        {
            db.Tbl_student.Update(std);
            await db.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> UpdateStudent(int id)
        {
            var DelId = await db.Tbl_student.FindAsync(id);
            db.Tbl_student.Remove(DelId);
            await db.SaveChangesAsync();
            return Ok();
        }

    }
}