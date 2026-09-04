using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackerApi.Data;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutLogsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkoutLogsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/WorkoutLogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkoutLog>>> GetLogs()
    {
        return await _context.WorkoutLogs
            .OrderByDescending(w => w.Date)
            .ToListAsync();
    }

    // POST: api/WorkoutLogs
    [HttpPost]
    public async Task<ActionResult<WorkoutLog>> CreateLog(WorkoutLog log)
    {
        _context.WorkoutLogs.Add(log);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLogs), new { id = log.Id }, log);
    }

    // GET: api/WorkoutLogs/pr/Bench Press
    [HttpGet("pr/{exerciseName}")]
    public async Task<ActionResult<object>> GetPersonalRecord(string exerciseName)
    {
        var maxWeight = await _context.WorkoutLogs
            .Where(w => w.ExerciseName.ToLower() == exerciseName.ToLower())
            .MaxAsync(w => (double?)w.Weight);

        if (maxWeight == null)
        {
            return NotFound($"{exerciseName} için henüz bir kayıt bulunamadı.");
        }

        return Ok(new
        {
            Exercise = exerciseName,
            MaxWeight = maxWeight
        });
    }
    // DELETE: api/WorkoutLogs/5 (Belirtilen id'ye sahip seti siler)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLog(int id)
    {
        var log = await _context.WorkoutLogs.FindAsync(id);
        if (log == null)
        {
            return NotFound($"Id {id} ile eşleşen kayıt bulunamadı.");
        }

        _context.WorkoutLogs.Remove(log);
        await _context.SaveChangesAsync();

        return NoContent(); // 204 No Content (Başarıyla silindi, dönecek içerik yok)
    }

    // PUT: api/WorkoutLogs/5 (Belirtilen id'ye sahip seti günceller)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLog(int id, WorkoutLog updatedLog)
    {
        var log = await _context.WorkoutLogs.FindAsync(id);
        if (log == null)
        {
            return NotFound($"Id {id} ile eşleşen kayıt bulunamadı.");
        }

        // Güncellenecek alanlar
        log.ExerciseName = updatedLog.ExerciseName;
        log.Weight = updatedLog.Weight;
        log.Reps = updatedLog.Reps;
        log.SetNumber = updatedLog.SetNumber;

        await _context.SaveChangesAsync();

        return Ok(log);
    }
}