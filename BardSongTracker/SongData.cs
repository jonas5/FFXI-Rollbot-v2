namespace BardSongTracker
{
    public class SongData
    {
        public string Name { get; private set; }
        public int MinDuration { get; set; } // Will now be buff duration (e.g., 180s)
        public int MaxDuration { get; set; } // Will now be buff duration (e.g., 180s)
        public int CastingTimeMinSeconds { get; set; }
        public int CastingTimeMaxSeconds { get; set; }

        public SongData(string name)
        {
            this.Name = name;
        }
    }
}
