using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_RPG.Models;


namespace dotnet_RPG.Services.SessionService
{
    public interface ISessionService
    {
         List<Session> GetAllSessions();
         Session GetSessionById(int id);
         Task<List<Session>> AddSession(Session newSession);
    }
}