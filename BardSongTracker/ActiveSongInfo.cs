using System;
using System.Windows.Forms;

namespace BardSongTracker
{
    public class ActiveSongInfo
    {
        public string PartyMemberName { get; set; }
        public SongData AppliedSong { get; set; }
        public Timer SongTimer { get; set; }
        public int RemainingSeconds { get; set; }
        public Label AssociatedLabel { get; set; }
        public int GroupNumber { get; set; } // 1 or 2
        public int SongSlotInGroup { get; set; } // 0 for A, 1 for B
        public DateTime AppliedTimestamp { get; set; }

        // New properties for casting phase
        public bool IsCasting { get; set; }
        public Timer CastingTimer { get; set; }
        public int RemainingCastingSeconds { get; set; }
    }
}
