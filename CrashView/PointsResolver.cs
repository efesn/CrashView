using AutoMapper;
using CrashView.Dto.Request;
using CrashView.Entities;

namespace CrashView
{
    public class PointsResolver : IValueResolver<RaceResultRequestDto, RaceResult, int>
    {
        public int Resolve(RaceResultRequestDto source, RaceResult destination, int destMember, ResolutionContext context)
        {
            return source.Position switch
            {
                1 => 25,
                2 => 18,
                3 => 15,
                4 => 12,
                5 => 10,
                6 => 8,
                7 => 6,
                8 => 4,
                9 => 2,
                10 => 1,
                _ => 0 // pozisyon 1-10 arası değilse 0 ver
            };
        }
    }
}
