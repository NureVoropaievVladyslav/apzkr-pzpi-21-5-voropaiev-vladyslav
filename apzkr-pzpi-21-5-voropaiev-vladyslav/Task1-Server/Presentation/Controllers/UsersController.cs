using Application.Features.Users.Commands.DeleteUserCommand;
using Application.Features.Users.Commands.ImportUsersCommand;
using Application.Features.Users.Commands.MakeAdminCommand;
using Application.Features.Users.Commands.RegisterWorkerCommand;
using Application.Features.Users.Commands.UpdateUserCommand;
using Application.Features.Users.Queries.ExportUsersDataQuery;
using Application.Features.Users.Queries.GetAllUsersQuery;
using Application.Features.Users.Queries.LoginQuery;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult> Create(RegisterWorkerCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
        return Ok(response);
    }
    
    [Authorize(Roles = nameof(Role.Admin))]
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] Guid userId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteUserCommand(userId), cancellationToken);
        return Ok(response);
    }

    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost("make-admin")]
    public async Task<ActionResult> MakeAdmin([FromQuery] Guid userId, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new MakeAdminCommand(userId), cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    
    [Authorize(Roles = nameof(Role.Admin))]
    [HttpGet("export")]
    public async Task<ActionResult> Export(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new ExportUsersDataQuery(), cancellationToken);
        return Ok(response);
    }
    
    [Authorize(Roles = nameof(Role.Admin))]
    [HttpPost("import")]
    public async Task<ActionResult> Import(ImportUsersCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return Ok();
    }
}