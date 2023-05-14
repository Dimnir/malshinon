using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly DataContext _context;
    public ReportsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppReport>>> GetReports()
    {
        var reports = await _context.Reports.ToListAsync();
        return reports;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppReport>> GetReport(int id)
    {
        return await _context.Reports.FindAsync(id);
    }

}
