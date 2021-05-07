using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models.Repository
{
    public interface ITrackRepository
    {
        public List<Track> GetTracks();
        public Track GetTrack(int id);
        public void Insert(Track track);
        public void Update(int id, Track track);
        public void Delete(int id);
    }
}
