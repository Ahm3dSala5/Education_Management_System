using System.Net;
using EMS.Core.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.MainControllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMediator ?_Instance;
        protected IMediator ? Mediator => _Instance ?? HttpContext.RequestServices.GetService<IMediator>();

        public ObjectResult HandlredResult<T>(Response<T>response)
        {
             return  response.StatusCode switch
             {
                 HttpStatusCode.OK => new OkObjectResult(response),
                 HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                 HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                 HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                 HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
                 HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
                 HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                 _ => new ObjectResult(response) { StatusCode = (int)response.StatusCode }
             };
        }
    }
}
