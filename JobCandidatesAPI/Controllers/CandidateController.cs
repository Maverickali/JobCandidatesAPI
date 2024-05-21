using Application.Candidates.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> Post([FromBody] CreateCandidateCommandDto command)
        {
            var candidate = await _mediator.Send(command);
            return Ok(candidate);
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Candidate>>> Get()
        //{
        //    //var products = await _mediator.Send(new GetProductsQuery());
        //    //return Ok("d");
        //}
    }
}