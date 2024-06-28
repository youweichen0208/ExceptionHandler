using exceptionhandlers.handlers;
using Microsoft.AspNetCore.Mvc;

namespace exceptionhandlers.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
  [HttpGet("notfound")]
  public IActionResult GetNotFound()
  {
    throw new BaseException("Resource not found", System.Net.HttpStatusCode.NotFound);
  }

  [HttpGet("error")]
  public IActionResult GetError()
  {
    throw new Exception("Something went wrong!");
  }
}