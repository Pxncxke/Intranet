using Intranet.Application.Features.EmployeeDirectory.Commands.CreateEmployee;
using Intranet.Application.Features.EmployeeDirectory.Commands.DeleteEmployee;
using Intranet.Application.Features.EmployeeDirectory.Commands.UpdateEmployee;
using Intranet.Application.Features.EmployeeDirectory.Queries.GetAllEmployees;
using Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeBirthday;
using Intranet.Application.Features.EmployeeDirectory.Queries.GetEmployeeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intranet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeDirectory : ControllerBase
{
    private readonly IMediator mediator;

    public EmployeeDirectory(IMediator mediator)
    {
        this.mediator = mediator;
    }
    // GET: api/<EmployeeDirectory>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var employees = await mediator.Send(new GetEmployeeDirectoryQuery());

        if (employees.Count > 0)
        {
            return Ok(employees.OrderByDescending(x => x.LastName));
        }

        return NotFound();
    }

    // GET api/<EmployeeDirectory>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var employeeDetails = await mediator.Send(new GetEmployeeDirectoryDetailsQuery(id));

        if (employeeDetails is not null)
        {
            return Ok(employeeDetails);
        }

        return NotFound();
    }

    // POST api/<EmployeeDirectory>
    [HttpPost]
    public async Task<IActionResult> Post(CreateEmployeeDirectoryCommand employeeCommand)
    {
        await mediator.Send(employeeCommand);

        return Ok();
    }

    // PUT api/<EmployeeDirectory>/5
    [HttpPut("{employeeCommand}")]
    public async Task<IActionResult> Put(UpdateEmployeeDirectoryCommand employeeCommand)
    {
        await mediator.Send(employeeCommand);

        return Ok();
    }

    // DELETE api/<EmployeeDirectory>/5
    [HttpDelete("{employeeCommand}")]
    public async Task<IActionResult> Delete(DeleteEmployeeDirectoryCommand employeeCommand)
    {
        await mediator.Send(employeeCommand);

        return Ok();
    }

    // GET api/<EmployeeDirectory>/MonthlyBirtday
    [HttpGet("MonthlyBirtday")]
    public async Task<IActionResult> GetMonthlyBirtdays()
    {
        var birthdays = await mediator.Send(new GetMonthlyEmployeeBirthdayQuery());

        if (birthdays.Count > 0)
        {
            return Ok(birthdays);
        }

        return NotFound();
    }
}
