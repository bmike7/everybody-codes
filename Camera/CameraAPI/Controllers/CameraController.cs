using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Data;

namespace CameraAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/cameras")]
    public class CameraController: ControllerBase
    {
        private ICamaraData _cameraData;
        public CameraController(ICamaraData camaraData)
        {
            _cameraData = camaraData;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var data = _cameraData.GetData();
            return Ok(data);
        }
    }
}