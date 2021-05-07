using MVC_Day09.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models.Repository
{
    public class TrackRepository : ITrackRepository
    {
        private readonly TraineesDB_Context context;
        public TrackRepository(TraineesDB_Context _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            var track = context.Tracks.FirstOrDefault(T => T.ID == id);
            context.Tracks.Remove(track);
            context.SaveChangesAsync();
        }

        public Track GetTrack(int id)
        {
            return context.Tracks.FirstOrDefault(T => T.ID == id);
        }

        public List<Track> GetTracks()
        {
            return context.Tracks.ToList();
        }

        public void Insert(Track track)
        {
            context.Tracks.Add(track);
            context.SaveChangesAsync();
        }

        public void Update(int id, Track track)
        {
            Track track1 = context.Tracks.FirstOrDefault(T => T.ID == id);
            track1.Name = track.Name;
            track1.Description = track.Description;

            context.SaveChangesAsync();
        }
    }
}
