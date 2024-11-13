using AutoMapper;
using Jornada.API.Data;
using Jornada.API.Data.Dtos;
using Jornada.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Jornada.API.Controllers;

[ApiController]
[Route("feedbacks")]
public class FeedbackController : ControllerBase
{
    private AppDbContext _context;
    public IMapper _mapper;

    public FeedbackController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddFeedback([FromBody] CreateFeedbackDto feedbackDto)
    {
        Feedback feedback = _mapper.Map<Feedback>(feedbackDto);
        _context.Feedbacks.Add(feedback);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.Id }, feedback);
    }

    [HttpGet]
    public IEnumerable<Feedback> GetFeedbacks([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Feedbacks.Skip(skip).Take(take).ToList();
    }

    [HttpGet("/feedbacks-home")]
    public IEnumerable<Feedback> GetFeedbacksHome()
    {
        return _context.Feedbacks.Take(3).ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetFeedbackById(int id)
    {
        var feedback = _context.Feedbacks.FirstOrDefault(feedback => feedback.Id == id);
        if (feedback == null) return NotFound();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFeedback(int id, [FromBody] UpdateFeedbackDto feedbackDto)
    {
        var feedback = _context.Feedbacks.FirstOrDefault(feedback => feedback.Id == id);
        if (feedback == null) return NotFound();
        _mapper.Map(feedbackDto, feedback);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFeedbackParse(int id, JsonPatchDocument<UpdateFeedbackDto> patch)
    {
        var feedback = _context.Feedbacks.FirstOrDefault(feedback => feedback.Id == id);
        if (feedback == null) return NotFound();

        var feedbackToUpdate = _mapper.Map<UpdateFeedbackDto>(feedback);
        patch.ApplyTo(feedbackToUpdate, ModelState);

        if (!TryValidateModel(feedbackToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(feedbackToUpdate, feedback);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFeedback(int id)
    {
        var feedback = _context.Feedbacks.FirstOrDefault(feedback => feedback.Id == id);
        if (feedback == null) return NotFound();

        _context.Feedbacks.Remove(feedback);
        _context.SaveChanges();
        return Ok();
    }
}

