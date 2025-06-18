using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EliteMMO.API;
using System.Diagnostics;

namespace BardSongTracker
{
    public partial class Form1 : Form
    {
        private List<SongData> songList = new List<SongData>();
        private List<ActiveSongInfo> activeSongs = new List<ActiveSongInfo>();
        private bool isRunning = false;
        private Random random = new Random();
        private EliteAPI? _api; // Field for EliteAPI

        public Form1()
        {
            InitializeComponent();
            InitializeSongList();
            PopulateSongComboBoxes();
            InitializeTimerLabels();
            AssignEventHandlers();
            PopulateProcessList(); // Call new method
        }

        private void PopulateProcessList()
        {
            processComboBox!.Items.Clear(); // Use null-forgiving operator
            string[] processNames = { "pol", "edenxi", "xiloader" }; // Add other common names if needed
            foreach (string name in processNames)
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process process in processes)
                {
                    // Store both name and ID, perhaps in a custom object or formatted string
                    // For simplicity now, just add a descriptive string and retrieve ID later by parsing or matching
                    processComboBox!.Items.Add($"{process.MainWindowTitle} (ID: {process.Id}) - {name}");
                }
            }
            if (processComboBox!.Items.Count > 0)
            {
                processComboBox!.SelectedIndex = 0;
            }
            else
            {
                processComboBox!.Items.Add("No game processes found");
                processComboBox!.SelectedIndex = 0;
            }
        }

        private void InitializeSongList()
        {
            songList = new List<SongData>
            {
                new SongData(name: "Valor Minuet") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Blade Madrigal") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Army's Paeon") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Knight's Minne") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Hunter's Prelude") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Victory March") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Advancing March") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Sword Madrigal") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Foe Requiem") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 },
                new SongData(name: "Mage's Ballad") { MinDuration = 180, MaxDuration = 180, CastingTimeMinSeconds = 7, CastingTimeMaxSeconds = 9 }
                // Add more songs as needed
            };
        }

        private void PopulateSongComboBoxes()
        {
            song1AComboBox!.Items.Clear(); // Assuming not null after InitializeComponent
            song1BComboBox!.Items.Clear();
            song2AComboBox!.Items.Clear();
            song2BComboBox!.Items.Clear();

            foreach (var song in songList)
            {
                song1AComboBox!.Items.Add(song.Name); // song.Name is non-null
                song1BComboBox!.Items.Add(song.Name);
                song2AComboBox!.Items.Add(song.Name);
                song2BComboBox!.Items.Add(song.Name);
            }

            if (songList.Count > 0)
            {
                song1AComboBox!.SelectedIndex = 0;
                song1BComboBox!.SelectedIndex = Math.Min(1, songList.Count - 1); // Ensure valid index
                song2AComboBox!.SelectedIndex = 0;
                song2BComboBox!.SelectedIndex = Math.Min(1, songList.Count - 1); // Ensure valid index
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
            this.selectProcessButton!.Click += new System.EventHandler(this.selectProcessButton_Click);
            this.refreshPartyButton!.Click += new System.EventHandler(this.refreshPartyButton_Click);
            this.setFollowTargetButton!.Click += new System.EventHandler(this.setFollowTargetButton_Click); // Add this
        }

        private void setFollowTargetButton_Click(object? sender, EventArgs e)
        {
            if (_api == null || _api.Player == null)
            {
                MessageBox.Show("API not connected. Please select a game process first.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? targetName = followTargetTextBox!.Text?.Trim(); // Use null-forgiving for TextBox, then null-conditional for Text

            if (string.IsNullOrEmpty(targetName))
            {
                MessageBox.Show("Please enter a target name to follow.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _api.ThirdParty.SendString($"/follow \"{targetName}\""); // Ensure quotes if target name can have spaces
                MessageBox.Show($"Sent /follow command for {targetName}.", "Follow", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting follow target: " + ex.Message, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshPartyButton_Click(object? sender, EventArgs e)
        {
            if (_api == null || _api.Player == null) // Basic check, more robust API status check might be needed
            {
                MessageBox.Show("API not connected. Please select a game process first.", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RefreshPartyListFromApi();
        }

        private void selectProcessButton_Click(object? sender, EventArgs e)
        {
            if (processComboBox!.SelectedItem == null || processComboBox!.Items.Count == 0 || processComboBox!.SelectedItem.ToString() == "No game processes found")
            {
                MessageBox.Show("No process selected or available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedProcessString = processComboBox!.SelectedItem.ToString()!;
            try
            {
                // Extract Process ID. This is a bit naive; a more robust way would be to store Process objects or IDs directly in ComboBox items.
                // Example parsing: "Some Title (ID: 12345) - pol"
                int idStartIndex = selectedProcessString.IndexOf("(ID: ") + 5;
                int idEndIndex = selectedProcessString.IndexOf(")", idStartIndex);
                if (idStartIndex == -1 + 5 || idEndIndex == -1) throw new FormatException("Could not parse Process ID from selection.");

                int processId = int.Parse(selectedProcessString.Substring(idStartIndex, idEndIndex - idStartIndex));

                _api = new EliteAPI(processId); // Initialize the API

                // Check if API connected (basic check)
                if (_api != null && _api.Player != null && _api.Player.Name != null && !string.IsNullOrEmpty(_api.Player.Name)) // More robust check might be needed
                {
                    MessageBox.Show($"Connected to process ID {processId}. Player: {_api.Player.Name}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectProcessButton!.Text = "Connected";
                    selectProcessButton!.Enabled = false; // Disable after connection
                    processComboBox!.Enabled = false;
                    refreshPartyButton!.Enabled = true;
                    followTargetTextBox!.Enabled = true;
                    setFollowTargetButton!.Enabled = true;
                    RefreshPartyListFromApi();
                }
                else
                {
                     _api = null; // Ensure _api is null if connection "failed"
                    MessageBox.Show($"Failed to properly connect to process ID {processId}. Ensure it's a valid FFXI process.", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refreshPartyButton!.Enabled = false;
                    followTargetTextBox!.Enabled = false;
                    setFollowTargetButton!.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                _api = null; // Ensure _api is null on error
                MessageBox.Show("Error selecting process or initializing API: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectProcessButton!.Text = "Connect"; // Reset button
                selectProcessButton!.Enabled = true;
                processComboBox!.Enabled = true;
                refreshPartyButton!.Enabled = false;
                followTargetTextBox!.Enabled = false;
                setFollowTargetButton!.Enabled = false;
            }
        }

        private void RefreshPartyListFromApi()
        {
            if (_api == null || _api.Player == null) // Redundant check if called from button, but good for direct calls
            {
                // Silently return or log if called internally without API ready
                return;
            }

            try
            {
                var partyMembers = _api.Party.GetPartyMembers(); // Assuming this returns a list-like collection of party members

                // Store current selections to attempt to restore them
                var selectedG1 = partyGroup1ListBox!.SelectedItems.Cast<string>().ToList();
                var selectedG2 = partyGroup2ListBox!.SelectedItems.Cast<string>().ToList();

                partyGroup1ListBox!.Items.Clear();
                partyGroup2ListBox!.Items.Clear();

                if (partyMembers != null) // EliteAPI might return null if not in party or error
                {
                    foreach (var member in partyMembers) // Adjust property names based on actual EliteAPI.PartyMember structure
                    {
                        // Assuming 'member' has a 'Name' property and we don't want to list ourselves.
                        // Also, ensure member is valid (e.g., some APIs might have an 'Active' or 'InZone' flag)
                        // For now, a simple Name check:
                        if (member != null && !string.IsNullOrEmpty(member.Name) && member.Name != _api.Player.Name)
                        {
                            partyGroup1ListBox!.Items.Add(member.Name);
                            partyGroup2ListBox!.Items.Add(member.Name);
                        }
                    }
                }

                // Attempt to restore selections
                foreach (string name in selectedG1)
                {
                    if (partyGroup1ListBox!.Items.Contains(name))
                    {
                        partyGroup1ListBox!.SelectedItems.Add(name);
                    }
                }
                foreach (string name in selectedG2)
                {
                    if (partyGroup2ListBox!.Items.Contains(name))
                    {
                        partyGroup2ListBox!.SelectedItems.Add(name);
                    }
                }

                if (partyGroup1ListBox!.Items.Count == 0)
                {
                    partyGroup1ListBox!.Items.Add("No party members found (or not in party).");
                }
                 if (partyGroup2ListBox!.Items.Count == 0)
                {
                    partyGroup2ListBox!.Items.Add("No party members found (or not in party).");
                }

                // If party members were updated while isRunning, re-evaluate songs
                if (isRunning)
                {
                    ApplySongsToSelectedMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing party list: " + ex.Message, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Optionally clear lists or add error messages
                partyGroup1ListBox!.Items.Clear();
                partyGroup1ListBox!.Items.Add("Error loading party.");
                partyGroup2ListBox!.Items.Clear();
                partyGroup2ListBox!.Items.Add("Error loading party.");
            }
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
            string result;
            if (applied != null && applied.IsCasting && applied.CastingTimer != null && applied.CastingTimer.Enabled && applied.SongTimer == null &&
                applied.RemainingCastingSeconds >= songToTest.CastingTimeMinSeconds && applied.RemainingCastingSeconds <= songToTest.CastingTimeMaxSeconds)
            {
                result = "PASS (Initial Cast)";
            }
            else
            {
                result = "FAIL (Initial Cast)";
            }
            result += $" - Song '{songToTest.Name}' on '{testMember}'. Expected casting. IsCasting: {applied?.IsCasting}, CastTimerEnabled: {applied?.CastingTimer?.Enabled}, BuffTimerNull: {applied?.SongTimer == null}. Label: {timer1ALabel.Text}";

            MessageBox.Show($"Test_ApplySingleSong: Observe if '{songToTest.Name}' on '{testMember}' shows 'Cast: ...' then changes to buff countdown. Click OK after observing casting completion (approx 7-9s).", "Manual Observation");

            // Optional: Check state after presumed casting completion
            // This is tricky because the timing is not exact. For now, we rely on manual observation for transition.
            if (applied != null && !applied.IsCasting && applied.SongTimer != null && applied.SongTimer.Enabled)
            {
                result += "\n - Post-Cast Check: PASS (Buffing)";
            } else if (applied != null) {
                result += $"\n - Post-Cast Check: FAIL (Not buffing as expected). IsCasting: {applied.IsCasting}, SongTimerEnabled: {applied.SongTimer?.Enabled}";
            }


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
            if (activeA == null || !activeA.IsCasting) { ResetTestEnvironment(); return $"FAIL - Song A ('{songA.Name}') failed to apply or start casting."; }
            MessageBox.Show($"Test_ApplyAndOverwriteSongs: Song A ('{songA.Name}') applied. Observe casting. Click OK.", "Manual Observation");
            activeA.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-30); // Make it older for overwrite logic

            // Apply Song B (Slot 1)
            song1BComboBox.SelectedItem = songB.Name;
            ApplySongsToSelectedMembers();
            var activeB = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songB.Name);
            if (activeB == null || !activeB.IsCasting) { ResetTestEnvironment(); return $"FAIL - Song B ('{songB.Name}') failed to apply or start casting."; }
            MessageBox.Show($"Test_ApplyAndOverwriteSongs: Song B ('{songB.Name}') applied. Observe casting. Click OK.", "Manual Observation");
            activeB.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-20); // Newer than A, older than C

            // Apply Song C (Slot 0, should overwrite A)
            song1AComboBox.SelectedItem = songC.Name;
            ApplySongsToSelectedMembers();
            var activeC = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songC.Name);
            if (activeC == null || !activeC.IsCasting) { ResetTestEnvironment(); return $"FAIL - Song C ('{songC.Name}') failed to apply or start casting as overwrite."; }
            MessageBox.Show($"Test_ApplyAndOverwriteSongs: Song C ('{songC.Name}') applied to Slot 0 (replacing A). Observe casting. Click OK.", "Manual Observation");

            // After all applications and observations
            bool songAFound = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songA.Name);
            // activeB should now be the one in slot 1 for the member. It might have finished casting.
            var finalActiveB = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songB.Name);
            // activeC should be in slot 0 for the member. It might have finished casting.
            var finalActiveC = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songC.Name);

            string result;
            // Expected: C is in Slot 0 (now likely buffing), B is in Slot 1 (now likely buffing). A is gone.
            if (finalActiveC != null && finalActiveB != null && !songAFound && activeSongs.Count(s => s.PartyMemberName == testMember) == 2)
            {
                result = "PASS";
            }
            else
            {
                result = "FAIL";
            }
            result += $" - Applied A, B, then C to slot of A. Expected C & B. Found A:{songAFound}, B:{finalActiveB != null}, C:{finalActiveC != null}. Count: {activeSongs.Count(s=>s.PartyMemberName==testMember)}." +
                      $" Casting C: {finalActiveC?.IsCasting}, Casting B: {finalActiveB?.IsCasting}.";

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
            if (activeG1A == null || !activeG1A.IsCasting) { ResetTestEnvironment(); return $"FAIL - Song G1A ('{songG1A.Name}') failed to apply/cast."; }
            MessageBox.Show($"Test_TwoSongsMaxPerMember: Song G1A ('{songG1A.Name}') applied. Observe casting. Click OK.", "Manual Observation");
            activeG1A.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-30); // Oldest

            // Apply Song G1B (Group 1, Slot B)
            song1BComboBox.SelectedItem = songG1B.Name;
            ApplySongsToSelectedMembers();
            var activeG1B = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1B.Name);
            if (activeG1B == null || !activeG1B.IsCasting) { ResetTestEnvironment(); return $"FAIL - Song G1B ('{songG1B.Name}') failed to apply/cast."; }
            MessageBox.Show($"Test_TwoSongsMaxPerMember: Song G1B ('{songG1B.Name}') applied. Observe casting. Click OK.", "Manual Observation");
            activeG1B.AppliedTimestamp = DateTime.UtcNow.AddSeconds(-20); // Middle

            // Now, select the member in Group 2 and apply Song G2A (Group 2, Slot A)
            // This should force the oldest song (G1A) to be removed.
            partyGroup2ListBox.SelectedItem = testMember;
            song2AComboBox.SelectedItem = songG2A.Name;
            ApplySongsToSelectedMembers();
            var activeG2A = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG2A.Name);
            if (activeG2A == null || !activeG2A.IsCasting) { ResetTestEnvironment(); return $"FAIL - Song G2A ('{songG2A.Name}') failed to apply/cast as 3rd song."; }
            MessageBox.Show($"Test_TwoSongsMaxPerMember: Song G2A ('{songG2A.Name}') applied to Group 2 (replacing G1A). Observe casting. Click OK.", "Manual Observation");

            // Check final state
            bool g1aFoundFinal = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1A.Name);
            var finalG1B = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG1B.Name);
            var finalG2A = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == songG2A.Name);
            int totalSongsOnMember = activeSongs.Count(s => s.PartyMemberName == testMember);

            string result;
            if (!g1aFoundFinal && finalG1B != null && finalG2A != null && totalSongsOnMember == 2)
            {
                result = "PASS";
            }
            else
            {
                result = "FAIL";
            }
            result += $" - Applied G1A, G1B, then G2A. Expected G1B & G2A. Found G1A:{g1aFoundFinal}, G1B:{finalG1B != null}, G2A:{finalG2A != null}. Count: {totalSongsOnMember}." +
                      $" G1B Casting: {finalG1B?.IsCasting}, G2A Casting: {finalG2A?.IsCasting}.";

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
            var tempSongForTest = new SongData(name: "QuickCastAndBuffSong") { MinDuration = 1, MaxDuration = 1, CastingTimeMinSeconds = 1, CastingTimeMaxSeconds = 1 };
            songList.Add(tempSongForTest);
            PopulateSongComboBoxes();
            song1AComboBox.SelectedItem = tempSongForTest.Name;

            isRunning = true;
            ApplySongsToSelectedMembers();
            var activeTestSong = activeSongs.FirstOrDefault(s => s.PartyMemberName == testMember && s.AppliedSong.Name == tempSongForTest.Name);

            if (activeTestSong == null || !activeTestSong.IsCasting)
            {
                ResetTestEnvironment();
                return "FAIL - QuickSong did not start casting.";
            }

            string message = $"TIMER TEST (Manual Observation):\n" +
                             $"1. Observe '{tempSongForTest.Name}' CASTING on '{testMember}' (approx 1s).\n" +
                             $"2. Observe it switch to BUFFING (approx 1s).\n" +
                             $"3. Observe BUFF expiration (label clears/resets).\n" +
                             $"Click OK after observing all stages (approx 2-3 seconds total).";
            MessageBox.Show(message, "Manual Timer Test Sequence");

            // Check after user clicks OK. The song should be completely gone.
            bool songStillFullyActive = activeSongs.Any(s => s.PartyMemberName == testMember && s.AppliedSong.Name == tempSongForTest.Name);
            string result;
            if (!songStillFullyActive)
            {
                // Further check: was it in buff state before disappearing? This is hard to guarantee timing for.
                // For this basic test, just checking it's gone is the main goal.
                result = "PASS (presumably, song removed after cast and buff)";
            }
            else
            {
                result = "FAIL (song still active or did not complete full cycle)";
            }
            result += $" - Song '{tempSongForTest.Name}' active status after delay: {!songStillFullyActive}. Label: {timer1ALabel.Text}";

            // Cleanup the temporary song
            songList.Remove(tempSongForTest); // Ensure it's removed
            PopulateSongComboBoxes();
            ResetTestEnvironment();
            return result;
        }


        private void runTestsButton_Click(object? sender, EventArgs e)
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

        private void addPartyMemberButton_Click(object? sender, EventArgs e)
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

        private void startStopButton_Click(object? sender, EventArgs e)
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
                    if (activeSong.CastingTimer != null)
                    {
                        activeSong.CastingTimer.Stop();
                        activeSong.CastingTimer.Dispose();
                    }
                    if (activeSong.SongTimer != null)
                    {
                        activeSong.SongTimer.Stop();
                        activeSong.SongTimer.Dispose();
                    }
                    // No need to call RemoveOldSong here as we are clearing the whole list
                }
                activeSongs.Clear(); // Ensure the list is empty
                InitializeTimerLabels(); // Reset labels
            }
        }

        private void SongComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (isRunning)
            {
                ApplySongsToSelectedMembers();
            }
        }

        private void PartyListBox_SelectedIndexChanged(object? sender, EventArgs e)
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

        private void ProcessGroupSongs(ListBox partyListBox, ComboBox songComboBox, System.Windows.Forms.Label? timerLabel, int groupNum, int slotNum)
        {
            string? selectedSongName = songComboBox.SelectedItem as string;
            if (selectedSongName == null) return;

            SongData? selectedSong = songList.FirstOrDefault(s => s.Name == selectedSongName);
            if (selectedSong == null) return;

            // Apply to newly selected members in the list for this specific song slot
            foreach (var item in partyListBox.SelectedItems) // Assuming partyListBox and SelectedItems are not null
            {
                string? memberName = item as string; // item could be non-string
                if (memberName != null)
                {
                    ApplySongToMember(memberName, selectedSong, timerLabel, groupNum, slotNum);
                }
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


        private void ApplySongToMember(string memberName, SongData songToApply, System.Windows.Forms.Label? displayLabel, int groupNum, int slotNum)
        {
            if (!isRunning) return;

            // Check if this exact song (identified by name) is already active OR CASTING for this member in this slot
            var existingSongInSlot = activeSongs.FirstOrDefault(s =>
                s.PartyMemberName == memberName &&
                s.GroupNumber == groupNum &&
                s.SongSlotInGroup == slotNum);

            if (existingSongInSlot != null)
            {
                if (existingSongInSlot.AppliedSong.Name == songToApply.Name)
                {
                    // Same song is being re-applied to the same slot
                    if (existingSongInSlot.IsCasting)
                    {
                        // Restart casting
                        existingSongInSlot.CastingTimer.Stop();
                        existingSongInSlot.RemainingCastingSeconds = random.Next(songToApply.CastingTimeMinSeconds, songToApply.CastingTimeMaxSeconds + 1);
                        existingSongInSlot.AppliedTimestamp = DateTime.UtcNow; // Update timestamp
                        existingSongInSlot.CastingTimer.Start();
                    }
                    else // It's an active buff
                    {
                        // Refresh buff timer
                        existingSongInSlot.SongTimer.Stop();
                        existingSongInSlot.RemainingSeconds = random.Next(songToApply.MinDuration, songToApply.MaxDuration + 1);
                        existingSongInSlot.AppliedTimestamp = DateTime.UtcNow; // Update timestamp
                        existingSongInSlot.SongTimer.Start();
                    }
                    UpdateTimerLabel(existingSongInSlot);
                    return;
                }
                else
                {
                    // Different song in this slot, so it's an overwrite
                    RemoveOldSong(existingSongInSlot, timerExpired: false, clearLabel: false);
                }
            }

            // If we're here, it's a new song for this slot (either slot was empty or an old song was removed).
            // Now, check the 2-song-per-member limit.
            var memberSongs = activeSongs.Where(s => s.PartyMemberName == memberName).ToList();
            if (memberSongs.Count >= 2)
            {
                // Find the oldest song on this member (could be casting or buffing) and remove it.
                var oldestSongOnMember = memberSongs.OrderBy(s => s.AppliedTimestamp).First();
                RemoveOldSong(oldestSongOnMember, timerExpired: false, clearLabel: true);
            }

            // Add the new song, starting with casting phase
            var newActiveSong = new ActiveSongInfo(memberName, songToApply, displayLabel, groupNum, slotNum)
            {
                IsCasting = true // Set after construction, as it's part of the application logic
            };
            // AppliedTimestamp is set in the constructor.

            newActiveSong.RemainingCastingSeconds = random.Next(songToApply.CastingTimeMinSeconds, songToApply.CastingTimeMaxSeconds + 1);
            newActiveSong.CastingTimer = new System.Windows.Forms.Timer();
            newActiveSong.CastingTimer.Interval = 1000;
            newActiveSong.CastingTimer.Tick += CastingTimer_Tick;
            newActiveSong.CastingTimer.Tag = newActiveSong;

            activeSongs.Add(newActiveSong);
            newActiveSong.CastingTimer?.Start();
            UpdateTimerLabel(newActiveSong);
        }

        private void CastingTimer_Tick(object? sender, EventArgs e)
        {
            System.Windows.Forms.Timer? timer = sender as System.Windows.Forms.Timer;
            if (timer == null) return;

            ActiveSongInfo? activeSong = timer.Tag as ActiveSongInfo; // Make activeSong nullable
            if (activeSong == null || !activeSong.IsCasting)
            {
                // Safety check, should not happen if timer is managed correctly
                timer.Stop();
                timer.Dispose();
                return;
            }

            activeSong.RemainingCastingSeconds--;
            UpdateTimerLabel(activeSong);

            if (activeSong.RemainingCastingSeconds <= 0)
            {
                activeSong.CastingTimer.Stop();
                activeSong.CastingTimer.Dispose();
                activeSong.CastingTimer = null; // Important for RemoveOldSong checks
                activeSong.IsCasting = false;

                // Start main buff timer
                activeSong.RemainingSeconds = random.Next(activeSong.AppliedSong.MinDuration, activeSong.AppliedSong.MaxDuration + 1);
                activeSong.SongTimer = new System.Windows.Forms.Timer();
                activeSong.SongTimer.Interval = 1000;
                activeSong.SongTimer.Tick += SongTimer_Tick;
                activeSong.SongTimer.Tag = activeSong;
                activeSong.SongTimer?.Start();
                UpdateTimerLabel(activeSong); // Update label to show buff started
            }
        }

        private void SongTimer_Tick(object? sender, EventArgs e)
        {
            System.Windows.Forms.Timer? timer = sender as System.Windows.Forms.Timer;
            if (timer == null) return;

            ActiveSongInfo? activeSong = timer.Tag as ActiveSongInfo; // Make activeSong nullable
            // Ensure this tick is for a buffing song, not a casting one that hasn't been switched properly.
            if (activeSong == null || activeSong.IsCasting)
            {
                // Safety check
                timer.Stop();
                timer.Dispose();
                return;
            }

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
            // For simplicity, using full names for now. Abbreviation can be added later.
            string songName = activeSong.AppliedSong.Name;
            string memberName = activeSong.PartyMemberName;
            // string slotName = activeSong.SongSlotInGroup == 0 ? "Song A" : "Song B"; // Less relevant now with member name in label

            if (activeSong.IsCasting)
            {
                activeSong.AssociatedLabel.Text = $"Cast: {songName} ({activeSong.RemainingCastingSeconds}s) on {memberName}";
            }
            else
            {
                activeSong.AssociatedLabel.Text = $"{songName} ({activeSong.RemainingSeconds}s) on {memberName}";
            }
        }


        private void RemoveOldSong(ActiveSongInfo songToRemove, bool timerExpired, bool clearLabel)
        {
            if (songToRemove == null) return;

            if (songToRemove.CastingTimer != null)
            {
                songToRemove.CastingTimer.Stop();
                songToRemove.CastingTimer.Dispose();
                songToRemove.CastingTimer = null;
            }
            if (songToRemove.SongTimer != null)
            {
                songToRemove.SongTimer.Stop();
                songToRemove.SongTimer.Dispose();
                songToRemove.SongTimer = null;
            }

            if (clearLabel && songToRemove.AssociatedLabel != null) // This check is already good
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
            System.Windows.Forms.Label? labelToUpdate = null;
            ListBox? relevantListBox = null;

            if (groupNum == 1 && slotNum == 0) { labelToUpdate = timer1ALabel; relevantListBox = partyGroup1ListBox; }
            else if (groupNum == 1 && slotNum == 1) { labelToUpdate = timer1BLabel; relevantListBox = partyGroup1ListBox; }
            else if (groupNum == 2 && slotNum == 0) { labelToUpdate = timer2ALabel; relevantListBox = partyGroup2ListBox; }
            else if (groupNum == 2 && slotNum == 1) { labelToUpdate = timer2BLabel; relevantListBox = partyGroup2ListBox; }

            if (labelToUpdate == null || relevantListBox == null) return;

            ActiveSongInfo? songToDisplay = null;
            foreach(var item in relevantListBox.SelectedItems)
            {
                string? memberName = item as string;
                if (memberName != null)
                {
                    songToDisplay = activeSongs.FirstOrDefault(s =>
                        s.PartyMemberName == memberName &&
                        s.GroupNumber == groupNum &&
                        s.SongSlotInGroup == slotNum);
                    if (songToDisplay != null) break;
                }
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
