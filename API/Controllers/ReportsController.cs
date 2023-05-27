using System.Data;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ReportsController : BaseApiController
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

    [HttpPost("postreport")] // POST: api/reports/postreport
    public async Task<ActionResult<AppReport>> PostReport(ReportDto reportDto)
    {
        var report = new AppReport
        {
            Type = reportDto.Type,
            Description = reportDto.Description,
            Place = reportDto.Place,
            Date = DateTime.Now,
            Score = 0 // when creating new report -- init score
        };
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();

        return report;
    }

    [HttpPut("{id}")] // api/reports/:id
    public async Task<ActionResult<AppReport>> UpdateReport(IDReportDto report)
    {
        var reportToUpdate = await _context.Reports.SingleOrDefaultAsync(x =>
        x.Id == report.Id
        );

        if (reportToUpdate == null)
            return NotFound("Report not found");

        reportToUpdate.Score = report.Score; // adding 1 when user thumbs up the report in client

        await _context.SaveChangesAsync();
        return reportToUpdate;
    }




    // DELETE FROM Reports;
    // DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Reports';

}
