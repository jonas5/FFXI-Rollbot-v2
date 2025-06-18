namespace BardSongTracker
{
    public class SongData
    {
        public string Name { get; set; }
        public int MinDuration { get; set; } // Will now be buff duration (e.g., 180s)
        public int MaxDuration { get; set; } // Will now be buff duration (e.g., 180s)
        public int CastingTimeMinSeconds { get; set; }
        public int CastingTimeMaxSeconds { get; set; }
    }
}
