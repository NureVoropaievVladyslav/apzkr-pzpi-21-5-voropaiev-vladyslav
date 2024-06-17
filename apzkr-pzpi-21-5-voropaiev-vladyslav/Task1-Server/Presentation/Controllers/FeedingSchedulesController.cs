using Application.Features.FeedingSchedules.Commands.CreateFeedingScheduleCommand;
using Application.Features.FeedingSchedules.Commands.DeleteFeedingScheduleCommand;
using Application.Features.FeedingSchedules.Commands.UpdateFeedingScheduleCommand;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FeedingSchedulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedingSchedulesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update(UpdateFeedingScheduleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }    
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteFeedingScheduleCommand(id), cancellationToken);
        return Ok(response);
    }
}