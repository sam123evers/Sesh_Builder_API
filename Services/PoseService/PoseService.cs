using System.Collections.Generic;
using System.Linq;
using dotnet_RPG.Models;

namespace dotnet_RPG.Services.PoseService
{
    public class PoseService : IPoseService
    {
        private readonly SeshBuilderDbContext _context;

        public PoseService(SeshBuilderDbContext context)
        {
            _context = context;
        }
        public List<Pose> AddPose(Pose newPose)
        {
            _context.Add(newPose);
            _context.SaveChanges();
            List<Pose> poses = _context.Poses.ToList();
            return poses;
        }

        public List<Pose> GetAllPoses()
        {
            List<Pose> poses;
            poses = _context.Poses.ToList();
            return poses;
        }

        public Pose GetPoseById(int id)
        {
            Pose pose = _context.Poses.First(p => p.PoseId == id);
            return pose;
        }
    }
}