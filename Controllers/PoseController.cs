using dotnet_RPG.Models;
using dotnet_RPG.Services.PoseService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoseController : ControllerBase
    {
        private readonly IPoseService _poseService;
        public PoseController(IPoseService poseService)
        {
            _poseService = poseService;
        }
        public IActionResult Get()
        {
            return Ok(_poseService.GetAllPoses());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            Pose pose = _poseService.GetPoseById(id);
            return Ok(pose);
        }

        [HttpPost]
        public IActionResult AddPose(Pose newPose)
        {
            _poseService.AddPose(newPose);
            return Ok(_poseService.GetAllPoses());
        }
    }
}