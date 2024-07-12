using AutoMapper;
using CrashView.Dto.Response;
using CrashView.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrashView
{
    public class TeamPointsResolver : IValueResolver<Team, TeamResponseDto, int>
    {
        private readonly DataContext _context;

        public TeamPointsResolver(DataContext context)
        {
            _context = context;
        }

        public int Resolve(Team source, TeamResponseDto destination, int destMember, ResolutionContext context)
        {
            var totalPoints = _context.RaceResults
                .Join(_context.Persons,
                      raceResult => raceResult.Person_ID,
                      person => person.Person_Id,
                      (raceResult, person) => new { raceResult, person })
                .Where(joined => joined.person.Team_ID == source.Team_ID)
                .Sum(joined => joined.raceResult.PointsEarned);

            return totalPoints;
        }
    }
}
