using Application.Features.Ponds.Commands.CreatePondCommand;
using Application.Features.Ponds.Commands.Delete;
using Application.Features.Ponds.Commands.Import;
using Application.Features.Ponds.Queries.Export;
using Application.Features.Ponds.Queries.Get;
using Application.Features.Ponds.Queries.GetByEmail;
using Application.Features.Ponds.Queries.GetPondDataQuery;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PondsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PondsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetPondsQuery(), cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("{email}")]
    public async Task<ActionResult> Get(string email, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetPondsByEmailQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreatePondCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("/data")]
    public async Task<ActionResult> GetData(GetPondDataQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("export")]
    public async Task<ActionResult> Export(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ExportPondsQuery(), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost("import")]
    public async Task<ActionResult> Import([FromBody] ImportPondsCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] Guid pondId, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeletePondCommand(pondId), cancellationToken);
        return Ok();
    }
}