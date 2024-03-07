using Microsoft.AspNetCore.Mvc;
using MediatR;
using mTech.App;

namespace mTech.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Create(NewEmployee.Execute data)
        {
           return await _mediator.Send(data);
        }

        [HttpGet]

        public async Task<ActionResult<List<EmployeeInfo>>> Get()
        {
            return await _mediator.Send(new Consult.Execute());    
        }
    }
}
