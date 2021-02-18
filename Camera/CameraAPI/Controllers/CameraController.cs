using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Data;

namespace CameraAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/cameras")]
    public class CameraController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new CameraRow(){Name = "test", Longitude = "43254", Latitude = "fdsf"});
        }
    }
}