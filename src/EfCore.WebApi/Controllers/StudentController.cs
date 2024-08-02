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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
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
