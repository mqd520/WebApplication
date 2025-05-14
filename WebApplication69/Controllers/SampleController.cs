using MediatR;

using Microsoft.AspNetCore.Mvc;

using WebApplication69.Notifications;

namespace WebApplication69.Controllers
{
    public class SampleController : Controller
    {
        private readonly IMediator _mediator;

        public SampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sample()
        {
            var notification = new MyNotification();
            _mediator.Publish(notification);
            return Content("Ok");
        }
    }
}
