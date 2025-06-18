using System;
using System.Windows.Forms;

namespace BardSongTracker
{
    public class ActiveSongInfo
    {
        public string PartyMemberName { get; private set; }
        public SongData AppliedSong { get; private set; }
        public System.Windows.Forms.Timer? SongTimer { get; set; }
        public int RemainingSeconds { get; set; }
        public System.Windows.Forms.Label? AssociatedLabel { get; set; }
        public int GroupNumber { get; private set; } // 1 or 2
        public int SongSlotInGroup { get; private set; } // 0 for A, 1 for B
        public DateTime AppliedTimestamp { get; set; } // Can be updated (e.g. when refreshing)

        // New properties for casting phase
        public bool IsCasting { get; set; } // Logic flow will set this
        public System.Windows.Forms.Timer? CastingTimer { get; set; }
        public int RemainingCastingSeconds { get; set; }

        public ActiveSongInfo(string partyMemberName, SongData appliedSong, System.Windows.Forms.Label? associatedLabel, int groupNumber, int songSlotInGroup)
        {
            this.PartyMemberName = partyMemberName;
            this.AppliedSong = appliedSong;
            this.AssociatedLabel = associatedLabel;
            this.GroupNumber = groupNumber;
            this.SongSlotInGroup = songSlotInGroup;
            this.IsCasting = false; // Default, will be set true if casting starts
            this.AppliedTimestamp = DateTime.UtcNow;
            // Timers (SongTimer, CastingTimer) are nullable and set when phases start.
            // RemainingSeconds & RemainingCastingSeconds default to 0, set when phases start.
        }
    }
}
