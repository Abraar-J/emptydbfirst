using emptydbfirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emptydbfirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly TrainingContext con;
        public StudentController(TrainingContext con)
        {
            this.con = con;
        }

        //crud
        [HttpGet]
        public async Task<ActionResult< IEnumerable<Student>>> GetStudents()

        {
            return await con.Students.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            Student st=await con.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
            return st;
        }
        [HttpPost]
        public async Task<ActionResult> PostStudent(Student st)
        {
            await con.Students.AddAsync(st);
            con.SaveChanges();
            return Ok(st);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>UpdateStudent(int id,Student st)
        {
            Student su = await con.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            su.StudentId = st.StudentId;
            su.StudentName = st.StudentName;
            su.StudentPhNumber=st.StudentPhNumber;
            su.CourseTaken = st.CourseTaken;
            con.Update(su);
            con.SaveChanges();
            return Ok(su);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            Student st=await con.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            con.Students.Remove(st);
            con.SaveChanges();
            return Ok(st);
        }
    }
}
