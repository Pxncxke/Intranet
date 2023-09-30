using Intranet.Application.Features.News.Commands.CreateNews;
using Intranet.Application.Features.News.Commands.DeleteNews;
using Intranet.Application.Features.News.Commands.UpdateNews;
using Intranet.Application.Features.News.Queries.GetAllNews;
using Intranet.Application.Features.News.Queries.GetLatestNews;
using Intranet.Application.Features.News.Queries.GetNewsDetails;
using Intranet.Application.Features.News.Queries.GetNewsWithAuthor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intranet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly IMediator mediator;
    //private readonly ILoggerManager loggerManager;

    public NewsController(IMediator mediator)
    {
        this.mediator = mediator;
        //this.loggerManager = loggerManager;
    }
    // GET: api/<NewsController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var news = await mediator.Send(new GetNewsQuery());

        if (news.Count > 0)
        {
            return Ok(news.OrderByDescending(x => x.DateUpdated));
        }

        return NotFound();
    }

    // GET api/<NewsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var newsDetails = await mediator.Send(new GetNewsDetailsQuery(id));

        if (newsDetails is not null)
        {
            return Ok(newsDetails);
        }

        return NotFound();
    }

    // POST api/<NewsController>
    [HttpPost]
    public async Task<IActionResult> Post(CreateNewsCommand newsCommand)
    {
        await mediator.Send(newsCommand);

        return Ok();
    }

    // PUT api/<NewsController>/5
    [HttpPut("{newsCommand}")]
    public async Task<IActionResult> Put(UpdateNewsCommand newsCommand)
    {
        await mediator.Send(newsCommand);

        return Ok();
    }

    // DELETE api/<NewsController>/5
    [HttpDelete("{newsCommand}")]
    public async Task<IActionResult> Delete(DeleteNewsCommand newsCommand)
    {
        await mediator.Send(newsCommand);

        return Ok();
    }

    // GET api/<NewsController>/5
    [HttpGet("Details/{id}")]
    public async Task<IActionResult> GetNewsWithAuthor(Guid id)
    {
        var newsAuthorDetails = await mediator.Send(new GetNewsWithAuthorQuery(id));

        if (newsAuthorDetails is not null)
        {
            return Ok(newsAuthorDetails);
        }

        return NotFound();
    }

    // GET: api/<NewsController>
    [HttpGet("Latest")]
    public async Task<IActionResult> GetLatestNews()
    {
        var news = await mediator.Send(new GetNewsLatestQuery());
       
        if (news.Count > 0)
        {
            return Ok(news);
        }

        return NotFound();
    }
}
