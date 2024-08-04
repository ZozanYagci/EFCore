using EfCore.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        private async Task EagerLoadings()
        {
            var student = await applicationDbContext.Students
                //.Include(i=>i.Books).ThenInclude(i=>i.Courses)
                .Include(i => i.Books)
                .FirstOrDefaultAsync(i => i.Id == 5);
        }
        private async Task LazyLoadings() // If lazy loading is to be used, entities must be defined as virtual.
        {
            var students = await applicationDbContext.Students.ToListAsync();
            foreach(var student in students)
            {
                foreach(var book in student.Books)
                {
                    Console.WriteLine(book.Name);
                }
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await EagerLoadings();
            return null;

            StudentFilter filter = new StudentFilter() { FirstName = "Zozan"};
            var students = applicationDbContext.Students.AsQueryable();

            if (!string.IsNullOrEmpty(filter.FirstName))
                students = students.Where(i => i.FirstName == filter.FirstName);

            if (!string.IsNullOrEmpty(filter.LastName))
                students = students.Where(i => i.LastName == filter.LastName);

            if (filter.Number.HasValue)
                students = students.Where(i=>i.Number==filter.Number);

            var list=await students.ToListAsync();

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }
    }
}
