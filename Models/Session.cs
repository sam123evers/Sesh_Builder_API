using System.Collections.Generic;

namespace dotnet_RPG.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public IList<SeshPose> PoseList { get; set; }
    }

    public class Pose
    {
        public int PoseId { get; set; }
        public string PoseName { get; set; }

        public IList<SeshPose> Sessions { get; set; }
    }

    public class SeshPose
    {
        public int PoseId { get; set; }
        public Pose Pose { get; set; }

        
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}

// the Pose and Session entities now include a collection navigation property of SeshPose type. 
// The SeshPose entity already includes the foreign key property and navigation property for both, 
// Pose and Session. This makes it a fully defined one-to-many relationship between Pose & SeshPose 
// and Session & SeshPose.