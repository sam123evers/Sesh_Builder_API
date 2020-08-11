using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_RPG.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_RPG.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private static SeshBuilderDbContext _context;
        public SessionService(SeshBuilderDbContext context)
        {
            _context = context;
        }
        public async Task<List<Session>> AddSession(Session newSession)
        {
            // Create New Session

            //  -store poseList from newSession in temp variable
            IList<SeshPose> poseListTemp = newSession.PoseList;

            //  -clear pose list from newSession and save newSession
            newSession.PoseList.Clear();
            _context.Sessions.Add(newSession);
            _context.SaveChanges();
            
            newSession = _context.Sessions.First(s => s.SessionName == newSession.SessionName);
            //  -add the id from newSession to poseListTemp
            newSession.PoseList = poseListTemp;
            _context.Sessions.Update(newSession);
            _context.SaveChanges();
            
            //  -save list of Sesh Poses
            List<Session> sessions = _context.Sessions.ToList();
            return sessions;
        }

        public Session UpdateSession(Session updatedSession)
        {
            Session session = updatedSession;
            return session;
        }

        public List<Session> GetAllSessions()
        {
            List<Session> sessions = _context.Sessions.ToList();
            return sessions;
        }

        public Session GetSessionById(int id)
        {
            var sessionIncludingPoses = _context.Sessions.Include(session => session.PoseList).ThenInclude(row => row.Pose).First(session => session.SessionId == id);
            return sessionIncludingPoses;
        }
    }
}