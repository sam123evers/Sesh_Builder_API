using System.Collections.Generic;
using dotnet_RPG.Models;

namespace dotnet_RPG.Services.PoseService
{
    public interface IPoseService
    {
         List<Pose> GetAllPoses();

         Pose GetPoseById(int id);

         List<Pose> AddPose(Pose newPose);
    }
}