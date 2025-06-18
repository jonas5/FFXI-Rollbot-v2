using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BardSongTracker
{
    public partial class Form1 : Form
    {
        private List<SongData> songList;
        private List<ActiveSongInfo> activeSongs = new List<ActiveSongInfo>();
        private bool isRunning = false;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeSongList();
            PopulateSongComboBoxes();
            InitializeTimerLabels();
            AssignEventHandlers();
        }

        private void InitializeSongList()
        {
            songList = new List<SongData>
            {
                new SongData { Name = "Valor Minuet", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Blade Madrigal", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Army's Paeon", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Knight's Minne", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Hunter's Prelude", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Victory March", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Advancing March", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Sword Madrigal", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Foe Requiem", MinDuration = 7, MaxDuration = 9 },
                new SongData { Name = "Mage's Ballad", MinDuration = 7, MaxDuration = 9 }
                // Add more songs as needed
            };
        }

        private void PopulateSongComboBoxes()
        {
            song1AComboBox.Items.Clear();
            song1BComboBox.Items.Clear();
            song2AComboBox.Items.Clear();
            song2BComboBox.Items.Clear();

            foreach (var song in songList)
            {
                song1AComboBox.Items.Add(song.Name);
                song1BComboBox.Items.Add(song.Name);
                song2AComboBox.Items.Add(song.Name);
                song2BComboBox.Items.Add(song.Name);
            }

            if (songList.Count > 0)
            {
                song1AComboBox.SelectedIndex = 0;
                song1BComboBox.SelectedIndex = Math.Min(1, songList.Count - 1); // Ensure valid index
                song2AComboBox.SelectedIndex = 0;
                song2BComboBox.SelectedIndex = Math.Min(1, songList.Count - 1); // Ensure valid index
            }
        }

        private void InitializeTimerLabels()
        {
            timer1ALabel.Text = "Song A: --";
            timer1BLabel.Text = "Song B: --";
            timer2ALabel.Text = "Song A: --";
            timer2BLabel.Text = "Song B: --";
        }

        private void AssignEventHandlers()
        {
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            this.song1AComboBox.SelectedIndexChanged += new System.EventHandler(this.SongComboBox_SelectedIndexChanged);
            this.song1BComboBox.SelectedIndexChanged += new System.EventHandler(this.SongComboBox_SelectedIndexChanged);
            this.song2AComboBox.SelectedIndexChanged += new System.EventHandler(this.SongComboBox_SelectedIndexChanged);
            this.song2BComboBox.SelectedIndexChanged += new System.EventHandler(this.SongComboBox_SelectedIndexChanged);
            this.partyGroup1ListBox.SelectedIndexChanged += new System.EventHandler(this.PartyListBox_SelectedIndexChanged);
            this.partyGroup2ListBox.SelectedIndexChanged += new System.EventHandler(this.PartyListBox_SelectedIndexChanged);
            this.addPartyMemberButton.Click += new System.EventHandler(this.addPartyMemberButton_Click);
            this.runTestsButton.Click += new System.EventHandler(this.runTestsButton_Click);
        }

        private void ResetTestEnvironment()
        {
            // Stop all timers and clear active songs
            isRunning = false; // Ensure system is in a stoppable state for active song clearing
            startStopButton.Text = "Start";
            foreach (var activeSong in activeSongs.ToList())
            {
                RemoveOldSong(activeSong, timerExpired: false, clearLabel: true);
            }
            activeSongs.Clear();

            // Clear selections
            partyGroup1ListBox.ClearSelected();
            partyGroup2ListBox.ClearSelected();
            if (songList.Count > 0)
            {
                song1AComboBox.SelectedIndex = 0;
                song1BComboBox.SelectedIndex = Math.Min(1, songList.Count - 1);
                song2AComboBox.SelectedIndex = 0;
                song2BComboBox.SelectedIndex = Math.Min(1, songList.Count - 1);
            }

            // Remove test members (specific cleanup)
            List<string> itemsToRemove = new List<string>();
            foreach (var item in partyGroup1ListBox.Items)
            {
                if (item.ToString().StartsWith("TestMember")) itemsToRemove.Add(item.ToString());
            }
            foreach (var item in itemsToRemove) partyGroup1ListBox.Items.Remove(item);

            itemsToRemove.Clear();
            foreach (var item in partyGroup2ListBox.Items)
            {
                if (item.ToString().StartsWith("TestMember")) itemsToRemove.Add(item.ToString());
            }
            foreach (var item in itemsToRemove) partyGroup2ListBox.Items.Remove(item);

            InitializeTimerLabels(); // Reset labels to default
        }

        private string Test_ApplySingleSong()
        {
            ResetTestEnvironment();
            string testMember = "TestMember1";
            partyGroup1ListBox.Items.Add(testMember);
            partyGroup1ListBox.SelectedItem = testMember;

            if (songList.Count == 0) return "FAIL - No songs available for testing.";
            song1AComboBox.SelectedIndex = 0;
            SongData songToTest = songList[0];

            // Simulate button click enabling song application
            isRunning = true;
            ApplySongsToSelectedMembers(); // This uses the UI selections

            var applied = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songToTest.Name && s.GroupNumber == 1 && s.SongSlotInGroup == 0);
            string result = applied != null ? "PASS" : "FAIL";
            result += $" - Song '{songToTest.Name}' on '{testMember}'. Expected active, Found: {applied != null}. Label: {timer1ALabel.Text}";

            ResetTestEnvironment();
            return result;
        }

        private string Test_ApplyAndOverwriteSongs()
        {
            ResetTestEnvironment();
            string testMember = "TestMemberOverwrite";
            partyGroup1ListBox.Items.Add(testMember);
            partyGroup1ListBox.SelectedItem = testMember;

            if (songList.Count < 3) return "FAIL - Need at least 3 songs for overwrite test.";

            SongData songA = songList[0];
            SongData songB = songList[1];
            SongData songC = songList[2];

            isRunning = true; // Enable song application

            // Apply Song A (Slot 0)
            song1AComboBox.SelectedItem = songA.Name;
            ApplySongsToSelectedMembers();
            var activeA = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songA.Name);
            if (activeA == null) { ResetTestEnvironment(); return $"FAIL - Song A ('{songA.Name}') failed to apply."; }
            activeA.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-30); // Make it older

            // Apply Song B (Slot 1)
            song1BComboBox.SelectedItem = songB.Name;
            ApplySongsToSelectedMembers();
            var activeB = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songB.Name);
            if (activeB == null) { ResetTestEnvironment(); return $"FAIL - Song B ('{songB.Name}') failed to apply."; }
            activeB.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-20); // Make it newer than A, older than C

            // Apply Song C (Slot 0, should overwrite A if logic is by slot + oldest, or just oldest if not slot-specific)
            // The current ApplySongToMember logic prioritizes replacing the song in the *specific slot*.
            // If we apply C to slot 0, it should replace A.
            song1AComboBox.SelectedItem = songC.Name;
            ApplySongsToSelectedMembers(); // Re-apply for slot A with song C

            bool songAFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songA.Name);
            bool songBFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songB.Name);
            bool songCFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songC.Name);

            // Expected: C is in Slot 0, B is in Slot 1. A is gone.
            string result;
            if (songCFound && songBFound && !songAFound && activeSongs.Count(s => s.PartyMemberName == testMember) == 2)
            {
                result = "PASS";
            }
            else
            {
                result = "FAIL";
            }
            result += $" - Applied A, B, then C to same slot as A. Expected C & B. Found A:{songAFound}, B:{songBFound}, C:{songCFound}. Count: {activeSongs.Count(s=>s.PartyMemberName==testMember)}";

            ResetTestEnvironment();
            return result;
        }

        private string Test_TwoSongsMaxPerMember()
        {
            ResetTestEnvironment();
            string testMember = "TestMemberMaxSongs";
            partyGroup1ListBox.Items.Add(testMember);
            partyGroup1ListBox.SelectedItem = testMember; // Select for group 1
            partyGroup2ListBox.Items.Add(testMember); // Add to group 2 as well
            // partyGroup2ListBox.SelectedItem = testMember; // Do not select for group 2 initially

            if (songList.Count < 3) return "FAIL - Need at least 3 songs for this test.";

            SongData songG1A = songList[0]; // Group 1, Slot A
            SongData songG1B = songList[1]; // Group 1, Slot B
            SongData songG2A = songList[2]; // Group 2, Slot A (the 3rd song)

            isRunning = true;

            // Apply Song G1A (Group 1, Slot A)
            song1AComboBox.SelectedItem = songG1A.Name;
            ApplySongsToSelectedMembers();
            var activeG1A = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1A.Name);
            if (activeG1A == null) { ResetTestEnvironment(); return $"FAIL - Song G1A ('{songG1A.Name}') failed to apply."; }
            activeG1A.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-30); // Oldest

            // Apply Song G1B (Group 1, Slot B)
            song1BComboBox.SelectedItem = songG1B.Name;
            ApplySongsToSelectedMembers();
            var activeG1B = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1B.Name);
            if (activeG1B == null) { ResetTestEnvironment(); return $"FAIL - Song G1B ('{songG1B.Name}') failed to apply."; }
            activeG1B.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-20); // Middle

            // Now, select the member in Group 2 and apply Song G2A (Group 2, Slot A)
            // This should force the oldest song (G1A) to be removed.
            partyGroup2ListBox.SelectedItem = testMember;
            song2AComboBox.SelectedItem = songG2A.Name;
            ApplySongsToSelectedMembers(); // This will trigger application for Group 2 selections

            bool g1aFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1A.Name);
            bool g1bFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1B.Name);
            bool g2aFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG2A.Name);
            int totalSongsOnMember = activeSongs.Count(s => s.PartyMemberName == testMember);

            string result;
            if (!g1aFound && g1bFound && g2aFound && totalSongsOnMember == 2)
            {
                result = "PASS";
            }
            else
            {
                result = "FAIL";
            }
            result += $" - Applied G1A, G1B, then G2A. Expected G1B & G2A. Found G1A:{g1aFound}, G1B:{g1bFound}, G2A:{g2aFound}. Count: {totalSongsOnMember}";

            ResetTestEnvironment();
            return result;
        }

        private string Test_SongTimerExpiration()
        {
            ResetTestEnvironment();
            // This test is manual due to timer complexities in a synchronous test environment.
            // For a real test framework, you'd use async/await capabilities or timer mocking.

            string testMember = "TestMemberTimer";
            partyGroup1ListBox.Items.Add(testMember);
            partyGroup1ListBox.SelectedItem = testMember;

            if (songList.Count == 0) return "FAIL - No songs available for testing.";

            // Temporarily modify a song for short duration for this test
            SongData originalSong = songList[0];
            SongData testSong = new SongData { Name = originalSong.Name, MinDuration = 1, MaxDuration = 1 };
            // To make ApplySongToMember pick this up, we'd need to modify songList or how it's retrieved.
            // Easiest for now: add a temporary song.
            var tempSongForTest = new SongData { Name = "QuickSong", MinDuration = 1, MaxDuration = 1};
            songList.Add(tempSongForTest);
            PopulateSongComboBoxes(); // Refresh comboboxes with the new song
            song1AComboBox.SelectedItem = tempSongForTest.Name;

            isRunning = true;
            ApplySongsToSelectedMembers();

            string message = $"TIMER TEST (Manual Observation):\nSong '{tempSongForTest.Name}' applied to '{testMember}' on Group 1, Slot A.\n" +
                             $"It should disappear from the label '{timer1ALabel.Name}' (and activeSongs list) after ~1 second.\n" +
                             "Click OK when ready to check (or after a few seconds).";
            MessageBox.Show(message, "Manual Timer Test");

            // Check after user clicks OK.
            bool songStillActive = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == tempSongForTest.Name);
            string result = !songStillActive ? "PASS (presumably)" : "FAIL (potentially, or timer too long/short)";
            result += $" - Song '{tempSongForTest.Name}' active status after delay: {!songStillActive}. Label: {timer1ALabel.Text}";

            // Cleanup the temporary song
            songList.Remove(tempSongForTest);
            PopulateSongComboBoxes(); // Refresh again
            ResetTestEnvironment();
            return result;
        }


        private void runTestsButton_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Please stop active song tracking before running tests.", "Tests Paused", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Text.StringBuilder results = new System.Text.StringBuilder();
            results.AppendLine("Basic Test Suite Results:");
            results.AppendLine("---------------------------------");

            try
            {
                results.AppendLine("Test_ApplySingleSong: " + Test_ApplySingleSong());
                results.AppendLine("---------------------------------");
                results.AppendLine("Test_ApplyAndOverwriteSongs: " + Test_ApplyAndOverwriteSongs());
                results.AppendLine("---------------------------------");
                results.AppendLine("Test_TwoSongsMaxPerMember: " + Test_TwoSongsMaxPerMember());
                results.AppendLine("---------------------------------");
                results.AppendLine("Test_SongTimerExpiration (Manual): " + Test_SongTimerExpiration());
                results.AppendLine("---------------------------------");
            }
            catch (Exception ex)
            {
                results.AppendLine("AN ERROR OCCURRED DURING TESTING: " + ex.Message);
                results.AppendLine(ex.StackTrace);
            }

            MessageBox.Show(results.ToString(), "Test Results");
        }

        private void addPartyMemberButton_Click(object sender, EventArgs e)
        {
            string newMemberName = partyMemberNameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(newMemberName))
            {
                // Check if member already exists (case-insensitive for simplicity)
                bool alreadyExistsG1 = partyGroup1ListBox.Items.Cast<string>().Any(item => item.Equals(newMemberName, StringComparison.OrdinalIgnoreCase));
                bool alreadyExistsG2 = partyGroup2ListBox.Items.Cast<string>().Any(item => item.Equals(newMemberName, StringComparison.OrdinalIgnoreCase));

                if (!alreadyExistsG1)
                {
                    partyGroup1ListBox.Items.Add(newMemberName);
                }
                if (!alreadyExistsG2) // Could be the same list, but good practice if they could diverge
                {
                    partyGroup2ListBox.Items.Add(newMemberName);
                }
                partyMemberNameTextBox.Clear();
            }
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            if (isRunning)
            {
                startStopButton.Text = "Stop";
                ApplySongsToSelectedMembers();
            }
            else
            {
                startStopButton.Text = "Start";
                // Stop all timers - Full stop, not pause
                foreach (var activeSong in activeSongs.ToList()) // ToList() for safe removal
                {
                    RemoveOldSong(activeSong, timerExpired: false, clearLabel: true);
                }
                activeSongs.Clear(); // Ensure the list is empty
                InitializeTimerLabels(); // Reset labels
            }
        }

        private void SongComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRunning)
            {
                ApplySongsToSelectedMembers();
            }
        }

        private void PartyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRunning)
            {
                // Potentially more granular updates could be done here,
                // but for now, re-applying all is simpler.
                ApplySongsToSelectedMembers();
            }
        }

        private void ApplySongsToSelectedMembers()
        {
            if (!isRunning) return;

            // Group 1
            ProcessGroupSongs(partyGroup1ListBox, song1AComboBox, timer1ALabel, 1, 0);
            ProcessGroupSongs(partyGroup1ListBox, song1BComboBox, timer1BLabel, 1, 1);

            // Group 2
            ProcessGroupSongs(partyGroup2ListBox, song2AComboBox, timer2ALabel, 2, 0);
            ProcessGroupSongs(partyGroup2ListBox, song2BComboBox, timer2BLabel, 2, 1);
        }

        private void ProcessGroupSongs(ListBox partyListBox, ComboBox songComboBox, Label timerLabel, int groupNum, int slotNum)
        {
            if (songComboBox.SelectedItem == null) return;
            SongData selectedSong = songList.FirstOrDefault(s => s.Name == songComboBox.SelectedItem.ToString());
            if (selectedSong == null) return;

            // Apply to newly selected members in the list for this specific song slot
            foreach (var item in partyListBox.SelectedItems)
            {
                string memberName = item.ToString();
                ApplySongToMember(memberName, selectedSong, timerLabel, groupNum, slotNum);
            }

            // Remove from members who are no longer selected for this song slot for this group
            var currentlyAppliedForSlot = activeSongs
                .Where(s => s.GroupNumber == groupNum && s.SongSlotInGroup == slotNum)
                .ToList();

            foreach (var activeSong in currentlyAppliedForSlot)
            {
                bool stillSelected = false;
                foreach (var selectedItem in partyListBox.SelectedItems)
                {
                    if (selectedItem.ToString() == activeSong.PartyMemberName)
                    {
                        stillSelected = true;
                        break;
                    }
                }
                if (!stillSelected)
                {
                    RemoveOldSong(activeSong, timerExpired: false, clearLabel: true);
                }
            }
        }


        private void ApplySongToMember(string memberName, SongData songToApply, Label displayLabel, int groupNum, int slotNum)
        {
            if (!isRunning) return;

            // Check if this exact song is already active on the member in the correct slot
            var existingSpecificSong = activeSongs.FirstOrDefault(s =>
                s.PartyMemberName == memberName &&
                s.AppliedSong.Name == songToApply.Name &&
                s.GroupNumber == groupNum &&
                s.SongSlotInGroup == slotNum);

            if (existingSpecificSong != null)
            {
                // Refresh existing song timer
                existingSpecificSong.SongTimer.Stop();
                existingSpecificSong.RemainingSeconds = random.Next(songToApply.MinDuration, songToApply.MaxDuration + 1);
                existingSpecificSong.SongTimer.Interval = 1000; // Tick every second
                existingSpecificSong.AppliedTimestamp = DateTime.UtcNow;
                existingSpecificSong.SongTimer.Start();
                UpdateTimerLabel(existingSpecificSong); // Update label immediately
                return;
            }

            // Get all songs currently on the member
            var memberSongs = activeSongs.Where(s => s.PartyMemberName == memberName).ToList();

            // If member has 2 songs already, and this is a new one for a slot that's occupied by a *different* song.
            // Or if this song is for a slot that's currently free but the member has 2 other songs.
            // The key is to identify which song to *replace* based on the slot.
            var songInThisSlot = memberSongs.FirstOrDefault(s => s.GroupNumber == groupNum && s.SongSlotInGroup == slotNum);

            if (songInThisSlot != null && songInThisSlot.AppliedSong.Name != songToApply.Name)
            {
                RemoveOldSong(songInThisSlot, timerExpired: false, clearLabel: false); // Don't clear label yet, new song will overwrite
            }
            else if (songInThisSlot == null && memberSongs.Count >= 2)
            {
                // This case is tricky: member has 2 songs, but *this* slot is free.
                // This implies the two songs are in different groups or different slots.
                // This situation should ideally be handled by UI preventing selection, or we pick the globally oldest.
                // For now, if this slot is free, we add. If it means a 3rd song overall for the member, that's an issue.
                // The current logic: if the *target slot* is free, we try to add.
                // Let's refine: A member can only have two songs. If this slot is free, but they have two songs elsewhere,
                // we must remove the oldest of those two.
                if (memberSongs.Count >=2) {
                    var oldestSong = memberSongs.OrderBy(s => s.AppliedTimestamp).First();
                    RemoveOldSong(oldestSong, timerExpired: false, clearLabel: true);
                }
            }


            // Add the new song
            var newActiveSong = new ActiveSongInfo
            {
                PartyMemberName = memberName,
                AppliedSong = songToApply,
                AssociatedLabel = displayLabel, // This needs to be specific to the member, not the group timer label
                GroupNumber = groupNum,
                SongSlotInGroup = slotNum,
                AppliedTimestamp = DateTime.UtcNow
            };

            newActiveSong.RemainingSeconds = random.Next(songToApply.MinDuration, songToApply.MaxDuration + 1);
            newActiveSong.SongTimer = new Timer();
            newActiveSong.SongTimer.Interval = 1000; // Tick every second to update RemainingSeconds
            newActiveSong.SongTimer.Tick += SongTimer_Tick;
            newActiveSong.SongTimer.Tag = newActiveSong; // Store a reference to ActiveSongInfo

            activeSongs.Add(newActiveSong);
            newActiveSong.SongTimer.Start();
            UpdateTimerLabel(newActiveSong); // Update label with new song info
        }

        private void SongTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            if (timer == null) return;

            ActiveSongInfo activeSong = timer.Tag as ActiveSongInfo;
            if (activeSong == null) return;

            activeSong.RemainingSeconds--;

            if (activeSong.RemainingSeconds <= 0)
            {
                RemoveOldSong(activeSong, timerExpired: true, clearLabel: true);
            }
            else
            {
                UpdateTimerLabel(activeSong);
            }
        }

        private void UpdateTimerLabel(ActiveSongInfo activeSong)
        {
            if (activeSong.AssociatedLabel == null) return; // Should not happen if assigned

            // This logic is flawed: AssociatedLabel is the group-level label.
            // We need per-member display or a different UI strategy for individual timers.
            // For now, the group label will show the latest updated song for that slot.
            // This part of the requirement (individual timer display per member per song)
            // is not fully met by the current UI design (single label per song slot in a group).
            // The current implementation will make the group label reflect one of the songs.
            string slotName = activeSong.SongSlotInGroup == 0 ? "Song A" : "Song B";
            activeSong.AssociatedLabel.Text = $"{slotName} ({activeSong.PartyMemberName.Substring(0, Math.Min(3, activeSong.PartyMemberName.Length))}...): {activeSong.AppliedSong.Name.Substring(0, Math.Min(5, activeSong.AppliedSong.Name.Length))}... {activeSong.RemainingSeconds}s";
        }


        private void RemoveOldSong(ActiveSongInfo songToRemove, bool timerExpired, bool clearLabel)
        {
            if (songToRemove == null) return;

            songToRemove.SongTimer.Stop();
            songToRemove.SongTimer.Dispose();

            if (clearLabel && songToRemove.AssociatedLabel != null)
            {
                // Only clear if this was the song defining the label, or if no other song for that member/slot.
                // This is complex with shared labels. If another song is active for this member in this slot,
                // the label would be updated by it.
                // For now, a simpler clear:
                string slotName = songToRemove.SongSlotInGroup == 0 ? "Song A" : "Song B";

                // Check if any OTHER song is currently using this label for this member.
                // This is still difficult because the label is for the whole group slot.
                // The best we can do is reset to default if NO song is active for this specific *PartyMemberName* in this *Group+Slot*
                bool anotherSongForThisMemberAndSlot = activeSongs.Any(s =>
                    s != songToRemove && // Exclude the one being removed
                    s.PartyMemberName == songToRemove.PartyMemberName &&
                    s.GroupNumber == songToRemove.GroupNumber &&
                    s.SongSlotInGroup == songToRemove.SongSlotInGroup);

                if (!anotherSongForThisMemberAndSlot) {
                     // If we are truly clearing the slot for this member, what should the group label show?
                     // It should show information for another member if one is selected and has this song,
                     // or default if no one selected for this song has it.
                     // This indicates a need to refresh the label based on current activeSongs for that slot.
                     RefreshSpecificTimerLabel(songToRemove.GroupNumber, songToRemove.SongSlotInGroup);
                }
            }
            activeSongs.Remove(songToRemove);
        }

        private void RefreshSpecificTimerLabel(int groupNum, int slotNum)
        {
            Label labelToUpdate = null;
            ListBox relevantListBox = null;
            if (groupNum == 1 && slotNum == 0) { labelToUpdate = timer1ALabel; relevantListBox = partyGroup1ListBox; }
            else if (groupNum == 1 && slotNum == 1) { labelToUpdate = timer1BLabel; relevantListBox = partyGroup1ListBox; }
            else if (groupNum == 2 && slotNum == 0) { labelToUpdate = timer2ALabel; relevantListBox = partyGroup2ListBox; }
            else if (groupNum == 2 && slotNum == 1) { labelToUpdate = timer2BLabel; relevantListBox = partyGroup2ListBox; }

            if (labelToUpdate == null || relevantListBox == null) return;

            // Find an active song for any selected member in this slot
            ActiveSongInfo songToDisplay = null;
            foreach(var item in relevantListBox.SelectedItems)
            {
                string memberName = item.ToString();
                songToDisplay = activeSongs.FirstOrDefault(s =>
                    s.PartyMemberName == memberName &&
                    s.GroupNumber == groupNum &&
                    s.SongSlotInGroup == slotNum);
                if (songToDisplay != null) break;
            }

            if (songToDisplay != null)
            {
                UpdateTimerLabel(songToDisplay);
            }
            else
            {
                string slotName = slotNum == 0 ? "Song A" : "Song B";
                labelToUpdate.Text = $"{slotName}: --";
            }
        }
    }
}
