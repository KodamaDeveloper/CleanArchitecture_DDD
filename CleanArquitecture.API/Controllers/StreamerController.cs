using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArquitecture.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController
    {
        private readonly IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost(Name = "CreateStreamer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStremaer([FromBody] CreateStreamerCommand command)
        {

            return await _mediator.Send(command);
  
        }
    }
}
