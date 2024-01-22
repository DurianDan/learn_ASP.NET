using learn.Data;
using learn.Models;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace learn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController: ControllerBase
    {
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) => _context = context;

        // [HttpGet]
        // public async Task<IEnumerable<Issue>> GetNotNullTitleMeo()
        // {
        //     return await _context
        //         .Issues
        //         .Where(
        //             issue => issue.Title != null
        //             && issue.Title.Contains("meo")
        //             )
        //         .ToListAsync();
        // }
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
        {   // `IEnumerable` is for iterable responses (like an array)
            // `Task` is for an Async returned type
            return await _context.Issues.ToListAsync();
        }

        [HttpGet("{id}")] // add property to the request url
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound(): Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = issue.Id}, issue);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Issue issue, int id)
        {
            if (id!= issue.Id) return BadRequest();
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);
            if (issueToDelete == null) return NotFound();

            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}