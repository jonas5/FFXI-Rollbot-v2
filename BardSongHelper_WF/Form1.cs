using EliteMMO.API;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BardSongHelper_WF
{
    public partial class Form1 : MetroForm

    {
        #region "CUSTOM CLASS: SongData" // Renamed

        public class SongData // Replaced RollData, does not inherit List<SongData>
        {
            public string SongName { get; set; }
            public int BuffId { get; set; }
            public int DurationSeconds { get; set; }
            public int CastTimeSeconds { get; set; }
            public int AreaOfEffectYalms { get; set; }
            public int Position { get; set; }
        }

        #endregion

        #region "CUSTOM CLASS: PartyRequirements"

        public class PartyRequirements
        {
            public string CharacterName { get; set; }
            public bool Checked { get; set; }
        }

        #endregion

        #region "CUSTOM CLASS: ActiveSongEffect" // Added
        public class ActiveSongEffect
        {
            public string SongName { get; set; }
            public string TargetName { get; set; }
            public int RemainingDurationSeconds { get; set; }
            public System.Windows.Forms.Timer AssociatedTimer { get; set; }
            public int AppliedByGroup { get; set; }
            public System.Windows.Forms.Label SongUITimerLabel { get; set; }
            public DateTime StartTime { get; set; }
            public bool IsFromRotationToggle { get; set; } = false; // New property
        }
        #endregion

        #region "CUSTOM CLASS: BadgeValue"
        public class ViewModel : INotifyPropertyChanged
        {
            private int _badgeValue;
            public int BadgeValue
            {
                get => _badgeValue;
                set { _badgeValue = value; NotifyPropertyChanged(); }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region "PUBLIC METHODS"

        public List<PartyRequirements> Member_List_Group1 = new List<PartyRequirements>(); // Renamed
        public List<PartyRequirements> Member_List_Group2 = new List<PartyRequirements>(); // Added

        // For tracking active songs per target
        private Dictionary<string, List<ActiveSongEffect>> activeSongEffectsByTarget = new Dictionary<string, List<ActiveSongEffect>>();
        // Flat list of all active songs for easier global management if needed
        private List<ActiveSongEffect> allActiveSongEffects = new List<ActiveSongEffect>();

        public ListBox processids = new ListBox();

        public static EliteAPI _api;

        public List<SongData> Songs = new List<SongData>(); // Changed from RollData rolls

        private bool botRunning = false;

        private bool firstSelect = false;

        public int lastCommand = 0;

        public bool timerBusy = false;

        public bool followBusy = false;

        public bool isMoving = false;

        // public bool Blocked = false; // Removed
        public bool AllInRange = false;


        public List<int> knownCities = new List<int> { 50, 80, 94, 87, 222, 223, 224, 225, 226, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239,
                                                                240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 256, 257 };

        // public int SongProcessActiveForGroup = 0; // Removed
        private int currentFollowTargetGroup = 1; // Added for Group 2 Follow Target
        private bool manualFollowActive = false;
        private string manualFollowTargetName = "";

        private bool isBardRotationActive = false;
        private CancellationTokenSource bardRotationCancellationTokenSource;
        private bool hasShownPartyWarningForProcessSongGroup = false;

        #endregion

        public Form1()
        {
            InitializeComponent();

#if DEBUG
            DEBUG.Visible = true;
#endif

            // Populate comboBoxSongDelay
            for (int i = 5; i <= 11; i++)
            {
                this.comboBoxSongDelay.Items.Add(i.ToString());
            }
            this.comboBoxSongDelay.SelectedItem = "10";

            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;

            // Removed: RollOne_ComboBox.SelectedIndex = 3;
            // Removed: RollTwo_ComboBox.SelectedIndex = 10;

            #region "ADD ALL THE SONGS TO THE CUSTOM CLASS" // Renamed region

            Songs.Add(new SongData { SongName = "Advancing March", BuffId = 108, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 0 });
            Songs.Add(new SongData { SongName = "Army's Paeon", BuffId = 103, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 1 });
            Songs.Add(new SongData { SongName = "Army's Paeon II", BuffId = 114, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 2 });
            Songs.Add(new SongData { SongName = "Army's Paeon III", BuffId = 121, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 3 });
            Songs.Add(new SongData { SongName = "Army's Paeon IV", BuffId = 122, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 4 });
            Songs.Add(new SongData { SongName = "Army's Paeon V", BuffId = 123, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 5 });
            Songs.Add(new SongData { SongName = "Army's Paeon VI", BuffId = 124, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 6 });
            Songs.Add(new SongData { SongName = "Blade Madrigal", BuffId = 102, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 7 });
            Songs.Add(new SongData { SongName = "Earth Carol", BuffId = 118, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 8 });
            Songs.Add(new SongData { SongName = "Fire Carol", BuffId = 116, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 9 });
            Songs.Add(new SongData { SongName = "Foe Requiem VII", BuffId = 109, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 10 });
            Songs.Add(new SongData { SongName = "Horde Lullaby II", BuffId = 110, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 11 });
            Songs.Add(new SongData { SongName = "Hunter's Prelude", BuffId = 105, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 12 });
            Songs.Add(new SongData { SongName = "Ice Carol", BuffId = 115, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 13 });
            Songs.Add(new SongData { SongName = "Knight's Minne", BuffId = 104, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 14 });
            Songs.Add(new SongData { SongName = "Knight's Minne II", BuffId = 112, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 15 });
            Songs.Add(new SongData { SongName = "Knight's Minne III", BuffId = 125, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 16 });
            Songs.Add(new SongData { SongName = "Knight's Minne IV", BuffId = 126, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 17 });
            Songs.Add(new SongData { SongName = "Knight's Minne V", BuffId = 127, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 18 });
            Songs.Add(new SongData { SongName = "Lightning Carol", BuffId = 117, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 19 });
            Songs.Add(new SongData { SongName = "Mage's Ballad", BuffId = 111, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 20 });
            Songs.Add(new SongData { SongName = "Mage's Ballad II", BuffId = 128, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 21 });
            Songs.Add(new SongData { SongName = "Mage's Ballad III", BuffId = 129, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 22 });
            Songs.Add(new SongData { SongName = "Shepherd's Etude", BuffId = 106, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 23 });
            Songs.Add(new SongData { SongName = "Valor Minuet", BuffId = 101, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 24 });
            Songs.Add(new SongData { SongName = "Valor Minuet II", BuffId = 113, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 25 });
            Songs.Add(new SongData { SongName = "Valor Minuet III", BuffId = 130, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 26 });
            Songs.Add(new SongData { SongName = "Valor Minuet IV", BuffId = 131, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 27 });
            Songs.Add(new SongData { SongName = "Valor Minuet V", BuffId = 132, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 28 });
            Songs.Add(new SongData { SongName = "Victory March", BuffId = 107, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 29 });
            Songs.Add(new SongData { SongName = "Water Carol", BuffId = 120, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 30 });
            Songs.Add(new SongData { SongName = "Wind Carol", BuffId = 119, DurationSeconds = 150, CastTimeSeconds = 8, AreaOfEffectYalms = 7, Position = 31 });

            #endregion

            PopulateSongComboBoxes(); // Added call

            // Populate custom call ComboBoxes
            List<string> customCalls = new List<string>();
            for (int i = 1; i <= 29; i++)
            {
                customCalls.Add($"<call{i}>"); // Placeholder calls
            }

            comboBoxLeavePartyCall.DataSource = new List<string>(customCalls); // Use a new list instance
            comboBoxLeavePartyCall.SelectedIndex = -1; // No default selection

            comboBoxRotationStartCall.DataSource = new List<string>(customCalls); // Use a new list instance
            comboBoxRotationStartCall.SelectedIndex = -1; // No default selection

            #region "Check for the Elite API and POL instances"

            if (File.Exists("eliteapi.dll") && File.Exists("elitemmo.api.dll"))
            {
                Process[] pol = Process.GetProcessesByName("pol");
                //MessageBox.Show("Found " + pol.Length + " POL instances.", "POL Instances Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (pol.Length < 1)
                {
                    MetroMessageBox.Show(this, "No POL instances were able to be located." + "\n\n" +
                        "Please note: If you use a private server make sure the program used to access it has been renamed to POL " +
                        "otherwise this bot will not be able to locate it.", "Notice:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (int i = 0; i < pol.Length; i++)
                    {
                        POLID.Items.Add(pol[i].MainWindowTitle);
                        processids.Items.Add(pol[i].Id);
                    }
                    POLID.SelectedIndex = 0;
                    processids.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("This program can not function without EliteMMO.API.dll and EliteAPI.dll");
                // this.Close();
            }

            #endregion

            this.Text = "Pocket Bard v1.0"; // Changed
            // Set initial state of Group 2 controls based on the toggle's default value
            toggleGroup2Switch_CheckedChanged(toggleGroup2Switch, EventArgs.Empty);
            UpdatePolidButtonText(); // Call UpdatePolidButtonText as the last line
        }

        private void toggleGroup2Switch_CheckedChanged(object sender, EventArgs e)
        {
            bool isGroup2Enabled = toggleGroup2Switch.Checked;

            // Handle controls within groupBoxSongGroup2
            // Iterate over all controls in groupBoxSongGroup2 and enable/disable them,
            // except for the toggleGroup2Switch itself.
            foreach (Control ctrl in groupBoxSongGroup2.Controls)
            {
                if (ctrl.Name == toggleGroup2Switch.Name) // Check by Name property for robustness
                {
                    // Ensure the toggle itself always remains enabled
                    ctrl.Enabled = true;
                }
                else
                {
                    ctrl.Enabled = isGroup2Enabled;
                }
            }

            // The toggleGroup2Switch should always be enabled.
            // If it was somehow disabled by its parent being targeted by another piece of code (not the case here),
            // this explicit re-enablement would be a safeguard.
            // Given the loop above, this specific line might be redundant but doesn't hurt.
            toggleGroup2Switch.Enabled = true;

            // Handle other Group 2 related group boxes which do NOT contain the toggle.
            // These can be enabled/disabled wholesale.
            groupBoxPartyGroup2.Enabled = isGroup2Enabled;
            groupBoxBardOptionsGroup2.Enabled = isGroup2Enabled;
        }

        // New public method to update POLID button text
        public void UpdatePolidButtonText()
        {
            if (Select_POLID.Text == "SELECTED")
            {
                // If an instance is already selected and API is loaded,
                // the button should remain "SELECTED" and green.
                return;
            }
            if (POLID.Items.Count == 0)
            {
                Select_POLID.Text = "Refresh";
                Select_POLID.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                Select_POLID.Text = "Select";
                Select_POLID.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void ActivityButton_Click(object sender, EventArgs e)
        {

            if (botRunning == false)
            {
                if (ActivityButton.InvokeRequired)
                {
                    ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!"; }));
                }
                else
                {
                    ActivityButton.BackColor = Color.Green; ActivityButton.Text = "RUNNING!";
                }

                botRunning = true;
            }
            else
            {
                if (ActivityButton.InvokeRequired)
                {
                    ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!"; }));
                }
                else
                {
                    ActivityButton.BackColor = Color.Red; ActivityButton.Text = "PAUSED!";
                }

                botRunning = false;
            }
        }

        #region "A POLID was selected so create an API instance and run the Addon"

        private void Select_POLID_Click(object sender, EventArgs e)
        {
            if (Select_POLID.Text == "Refresh")
            {
                // Clear POLID and processids lists
                POLID.Items.Clear();
                processids.Items.Clear();

                // Logic to find POL processes (copied from constructor)
                Process[] pol = Process.GetProcessesByName("pol");
                if (pol.Length < 1)
                {
                    // Show MetroMessageBox (copied from constructor)
                    MetroMessageBox.Show(this, "No POL instances were able to be located." + "\n\n" +
                        "Please note: If you use a private server make sure the program used to access it has been renamed to POL " +
                        "otherwise this bot will not be able to locate it.", "Notice:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (int i = 0; i < pol.Length; i++)
                    {
                        POLID.Items.Add(pol[i].MainWindowTitle);
                        processids.Items.Add(pol[i].Id);
                    }
                    if (pol.Length > 0) // Ensure items were actually added before setting index
                    {
                        POLID.SelectedIndex = 0;
                        processids.SelectedIndex = 0;
                    }
                }
                UpdatePolidButtonText(); // Update button based on new scan
                return;
            }

            // This part only runs if button was "Select"
            if (POLID.SelectedItem == null)
            {
                MetroMessageBox.Show(this, "Please select a POL instance from the list.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            processids.SelectedIndex = POLID.SelectedIndex;
            try
            {
                _api = new EliteAPI((int)processids.SelectedItem);
                Select_POLID.Text = "SELECTED";
                Select_POLID.BackColor = Color.Green;

                if (firstSelect == false)
                {
                    EliteAPI.ChatEntry cl = _api.Chat.GetNextChatLine();
                    while (cl != null)
                    {
                        cl = _api.Chat.GetNextChatLine();
                    }
                    GrabParty();
                    firstSelect = true;
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Failed to connect to POL instance: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reset button state if API init fails
                // Select_POLID.Text = "Select"; // UpdatePolidButtonText will handle this
                // Select_POLID.BackColor = System.Drawing.SystemColors.Control; // UpdatePolidButtonText will handle this
                _api = null; // Ensure API is null if connection failed
                UpdatePolidButtonText(); // Re-evaluate button state
            }
        }

        #endregion "A POLID was selected so create an API instance and run the Addon"






        private async void Song_Timer_TickAsync(object sender, EventArgs e)
        {
            if (_api == null)
            {
                return;
            }

            if (_api.Player.LoginStatus != (int)LoginStatus.LoggedIn || _api.Player.LoginStatus == (int)LoginStatus.Loading)
            {
                await Task.Delay(TimeSpan.FromSeconds(17));
                return;
            }

            if (timerBusy == true)
            {
                return;
            }

            try
            {
                timerBusy = true;

                // --- Auto-join logic ---
                // Now governed by the toggleAutoJoinSwitch
                if (toggleAutoJoinSwitch.Checked && _api != null && _api.Player.LoginStatus == (int)LoginStatus.LoggedIn)
                {
                    EliteAPI.ChatEntry chatLine = _api.Chat.GetNextChatLine();
                    while (chatLine != null)
                    {
                        // Use Regex to match "invites you to join" (case-insensitive, allowing for possible formatting tags)

                        if (Regex.IsMatch(chatLine.Text, @"invites you to join", RegexOptions.IgnoreCase))
                        {

                            //List<EliteAPI.PartyMember> PartyMembers = _api.Party.GetPartyMembers();
                            var partyMembers = _api.Party.GetPartyMembers();


                            int memberscount = 0; // Reset member count for each invite
                            if (partyMembers.Count() > 1)
                            {

                                foreach (EliteAPI.PartyMember PT_Data in partyMembers)
                                {



                                    if (!string.IsNullOrWhiteSpace(PT_Data.Name)
                                        && PT_Data.Name != _api.Player.Name
                                        && PT_Data.Active >= 1
                                        && !PartyMembersGroup1_ListBox.Items.Contains(PT_Data.Name)
                                        && !PartyMembersGroup2_ListBox.Items.Contains(PT_Data.Name))
                                    {
                                        memberscount += 1; // Increment member count
                                    }

                                }
                            }





                            //  MessageBox.Show("partyMembers.Count: " + memberscount, "Party Members Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (partyMembers == null || memberscount <= 1)
                            {
                                //MessageBox.Show(this, "You have been invited to a party. Joining automatically.", "Party Invite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                _api.ThirdParty.SendString("/join");
                                await Task.Delay(2000); // Wait a moment for join to process
                                GrabParty(); // Refresh party UI elements
                            }
                            break;
                        }
                        chatLine = _api.Chat.GetNextChatLine();
                    }
                }

                if (botRunning == true && !isBardRotationActive && !knownCities.Contains(_api.Player.ZoneId) && isMoving == false && manualFollowActive == false)
                {
                    // Determine which follow target to use for automated song cycle following
                    if (currentFollowTargetGroup == 1)
                    {
                        await FollowTargetAsync(FollowerTarget.Text);
                    }
                    else // currentFollowTargetGroup == 2
                    {
                        await FollowTargetAsync(FollowerTargetGroup2.Text);
                    }

                    // Process corresponding song group and then switch target group for next cycle
                    if (currentFollowTargetGroup == 1)
                    {
                        await ProcessSongGroup(
                            new List<SongData> {
                                Songs.FirstOrDefault(s => s.Position == SongGroup1_Song1_ComboBox.SelectedIndex),
                                Songs.FirstOrDefault(s => s.Position == SongGroup1_Song2_ComboBox.SelectedIndex)
                            },
                            Member_List_Group1,
                            new List<Label> { SongGroup1_Timer1_Label, SongGroup1_Timer2_Label },
                            1 // Group Number
                        );
                        currentFollowTargetGroup = 2; // Switch to Group 2 for next follow/song cycle
                    }
                    else // currentFollowTargetGroup == 2
                    {
                        await ProcessSongGroup(
                            new List<SongData> {
                                Songs.FirstOrDefault(s => s.Position == SongGroup2_Song1_ComboBox.SelectedIndex),
                                Songs.FirstOrDefault(s => s.Position == SongGroup2_Song2_ComboBox.SelectedIndex)
                            },
                            Member_List_Group2,
                            new List<Label> { SongGroup2_Timer1_Label, SongGroup2_Timer2_Label },
                            2 // Group Number
                        );
                        currentFollowTargetGroup = 1; // Switch back to Group 1 for next follow/song cycle
                    }
                }
                await Task.Delay(TimeSpan.FromMilliseconds(500)); // Main timer tick delay
            }
            finally
            {
                timerBusy = false;
            }
        }


        private uint GetTargetIdByName(string name)
        {
            for (int x = 0; x < 2048; x++)
            {
                EliteAPI.XiEntity ID = _api.Entity.GetEntity(x);

                if (ID.Name != null && ID.Name.ToLower() == name.ToLower())
                {
                    return ID.TargetID;
                }
            }
            return 0;
        }

        private async Task FollowTargetAsync(string targetName)
        {
            // Check if you have the required Buffs active, if not then run them.
            if (_api == null || _api.Player.LoginStatus != (int)LoginStatus.LoggedIn || _api.Player.LoginStatus == (int)LoginStatus.Loading)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(targetName) || targetName == "Follower target name." || targetName == "Follower target G2 name.")
            {
                return;
            }

            uint followID = GetTargetIdByName(targetName);

            if (followID == 0)
            {
                // Don't show a message here, as this is part of the automated loop
                return;
            }

            EliteAPI.XiEntity FollowedCharacter = _api.Entity.GetEntity(Convert.ToInt32(followID));
            EliteAPI.PlayerTools PlayerCharacter = _api.Player;

            isMoving = true;
            while (Math.Truncate(FollowedCharacter.Distance) >= (float)6)
            {
                if (manualFollowActive) break; // Stop if manual follow took over

                _api.AutoFollow.SetAutoFollowCoords(FollowedCharacter.X - PlayerCharacter.X,
                                                   FollowedCharacter.Y - PlayerCharacter.Y,
                                                   FollowedCharacter.Z - PlayerCharacter.Z);

                _api.AutoFollow.IsAutoFollowing = true;

                await Task.Delay(TimeSpan.FromSeconds(0.1));
                if (manualFollowActive) break;
            }
            if (!manualFollowActive) // Only turn off if this wasn't interrupted by manual follow
            {
                _api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;

            // Stop and Dispose timers
            if (Song_Timer != null)
            {
                Song_Timer.Stop();
                Song_Timer.Dispose();
            }
            if (PauseTimersChecks != null)
            {
                PauseTimersChecks.Stop();
                PauseTimersChecks.Dispose();
            }

            // API cleanup
            if (_api != null)
            {
                if (_api is IDisposable disposableApi)
                {
                    disposableApi.Dispose();
                }
                _api = null;
            }

            // Force the application to exit if it hasn't already.
            // This should be one of the very last things.
            Application.Exit();
        }

        #region "DISTANCE CHECKER"

        public bool DistanceChecker(string MemberName, uint maxDistance = 8) // Default to 8 if not specified
        {
            string CharName = MemberName.ToLower();
            for (int x = 0; x < 2048; x++)
            {
                EliteAPI.XiEntity entity2 = _api.Entity.GetEntity(x);
                if (entity2.Name != null && entity2.Name.ToLower() == CharName && (int)entity2.Distance < maxDistance)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region "FUNCTION TO CHECK IF AVAILABLE BUFF IS ACTIVE - BuffChecker(int ID)"

        public bool BuffChecker(int buffID)
        {
            if (_api.Player.GetPlayerInfo().Buffs.Any(b => b == buffID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region "CHECK IF PLAYER IS IN PARTY"

        private bool IsPlayerInParty()
        {
            if (_api == null || _api.Player == null)
            {
                return false; // Or handle appropriately
            }

            var partyMembers = _api.Party.GetPartyMembers();
            int otherActiveMembers = 0;

            if (partyMembers != null && partyMembers.Count() > 0)
            {
                foreach (EliteAPI.PartyMember PT_Data in partyMembers)
                {
                    if (PT_Data != null &&
                        !string.IsNullOrWhiteSpace(PT_Data.Name) &&
                        PT_Data.Name != _api.Player.Name &&
                        PT_Data.Active >= 1)
                    {
                        otherActiveMembers++;
                    }
                }
            }

            return otherActiveMembers > 0;
        }

        #endregion

        #region "PARTY MEMBER CHECKER TIMER"


        private void GrabParty()
        {
            // IF IN A PARTY THEN SET EACH CHECKBOX FIELD AS ENABLED AND POSSIBLE TO CHECK WITH THE
            // PT MEMBERS NAME SHOWN
            if (_api == null)
            {
                MessageBox.Show("Your messenger is not connected to POL, please select a POLID from the list and click 'Select POLID' button.");
                return;
            }

            if (_api != null)
            {
                List<EliteAPI.PartyMember> PartyMembers = _api.Party.GetPartyMembers();

                PartyMembersGroup1_ListBox.Items.Clear(); // Updated control name
                PartyMembersGroup2_ListBox.Items.Clear(); // Added for Group 2



                if (PartyMembers.Count() > 1)
                {
                    foreach (EliteAPI.PartyMember PT_Data in PartyMembers)
                    {



                        if (!string.IsNullOrWhiteSpace(PT_Data.Name)
                            && PT_Data.Name != _api.Player.Name
                            && PT_Data.Active >= 1
                            && !PartyMembersGroup1_ListBox.Items.Contains(PT_Data.Name)
                            && !PartyMembersGroup2_ListBox.Items.Contains(PT_Data.Name))
                        {
                            PartyMembersGroup1_ListBox.Items.Add(PT_Data.Name);
                            PartyMembersGroup2_ListBox.Items.Add(PT_Data.Name);
                        }

                    }
                }


            }
        }
        #endregion



        // Handles the countdown timer for an individual active song effect.
        // Updates the UI timer label and cleans up when the song expires.
        private void ActiveSong_Tick(object sender, EventArgs e, ActiveSongEffect songEffect)
        {
            songEffect.RemainingDurationSeconds--;
            if (songEffect.SongUITimerLabel != null)
            {
                if (songEffect.SongUITimerLabel.InvokeRequired)
                {
                    songEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate
                    {
                        songEffect.SongUITimerLabel.Text = $"{songEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(songEffect.RemainingDurationSeconds):mm\\:ss}";
                    }));
                }
                else
                {
                    songEffect.SongUITimerLabel.Text = $"{songEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(songEffect.RemainingDurationSeconds):mm\\:ss}";
                }
            }

            if (songEffect.RemainingDurationSeconds <= 0)
            {
                songEffect.AssociatedTimer.Stop();
                songEffect.AssociatedTimer.Dispose();

                if (activeSongEffectsByTarget.ContainsKey(songEffect.TargetName))
                {
                    activeSongEffectsByTarget[songEffect.TargetName].Remove(songEffect);
                    if (activeSongEffectsByTarget[songEffect.TargetName].Count == 0)
                    {
                        activeSongEffectsByTarget.Remove(songEffect.TargetName);
                    }
                }
                allActiveSongEffects.Remove(songEffect);

                if (songEffect.SongUITimerLabel != null)
                {
                    if (songEffect.SongUITimerLabel.InvokeRequired)
                    {
                        songEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { songEffect.SongUITimerLabel.Text = "00:00"; }));
                    }
                    else
                    {
                        songEffect.SongUITimerLabel.Text = "00:00";
                    }
                }
            }
        }

        // Processes the selected songs for a given group, applying them to checked targets.
        // Handles distance checks, existing song effects, song overwriting, and initiates song timers.
        private async Task ProcessSongGroup(List<SongData> selectedSongs, List<PartyRequirements> targets, List<Label> uiTimerLabels, int groupNumber)
        {
            if (_api == null || !botRunning) return;

            // Check if player is in a party with other active members
            if (!IsPlayerInParty())
            {
                if (!hasShownPartyWarningForProcessSongGroup)
                {
                    MetroMessageBox.Show(this, "You must be in a party with at least one other active member to play songs for the current song group. Songs will not be played until you are in a valid party.", "Party Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasShownPartyWarningForProcessSongGroup = true;
                }
                return; // Still return early
            }
            else
            {
                // If player is in a party, reset the flag so they get notified again if they leave party later.
                hasShownPartyWarningForProcessSongGroup = false;
            }

            // Check and use Soul Voice if toggled
            if (toggleSoulVoiceSwitch.Checked)
            {
                // Check if player actually has Soul Voice and if it's ready (optional but good practice)
                // For now, we assume the player manages this.
                _api.ThirdParty.SendString("/ja \"Soul Voice\" <me>");

                // Brief delay for JA to activate
                await Task.Delay(TimeSpan.FromMilliseconds(500)); // 0.5 second delay, adjust as needed

                // Turn off the toggle - it's a one-time use per activation
                if (toggleSoulVoiceSwitch.InvokeRequired)
                {
                    toggleSoulVoiceSwitch.Invoke(new MethodInvoker(delegate { toggleSoulVoiceSwitch.Checked = false; }));
                }
                else
                {
                    toggleSoulVoiceSwitch.Checked = false;
                }
            }

            // Existing song processing logic starts here
            for (int i = 0; i < selectedSongs.Count; i++)
            {
                SongData songToApply = selectedSongs[i];
                Label songLabel = (uiTimerLabels.Count > i) ? uiTimerLabels[i] : null;

                if (songToApply == null) continue;

                List<PartyRequirements> currentGroupTargets = targets.Where(t => t.Checked).ToList();
                if (!currentGroupTargets.Any()) continue;

                foreach (var targetMember in currentGroupTargets)
                {
                    if (!DistanceChecker(targetMember.CharacterName, (uint)songToApply.AreaOfEffectYalms))
                    {
                        continue;
                    }

                    if (!activeSongEffectsByTarget.ContainsKey(targetMember.CharacterName))
                    {
                        activeSongEffectsByTarget[targetMember.CharacterName] = new List<ActiveSongEffect>();
                    }
                    List<ActiveSongEffect> targetEffects = activeSongEffectsByTarget[targetMember.CharacterName];

                    if (targetEffects.Any(eff => eff.SongName == songToApply.SongName))
                    {
                        continue;
                    }

                    // If target already has 2 songs, overwrite the oldest one
                    if (targetEffects.Count >= 2)
                    {
                        ActiveSongEffect oldestEffect = targetEffects.OrderBy(eff => eff.StartTime).FirstOrDefault();
                        if (oldestEffect != null)
                        {
                            oldestEffect.AssociatedTimer.Stop();
                            oldestEffect.AssociatedTimer.Dispose();
                            targetEffects.Remove(oldestEffect);
                            allActiveSongEffects.Remove(oldestEffect);
                            if (oldestEffect.SongUITimerLabel != null)
                            {
                                if (oldestEffect.SongUITimerLabel.InvokeRequired)
                                {
                                    oldestEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { oldestEffect.SongUITimerLabel.Text = "00:00"; }));
                                }
                                else
                                {
                                    oldestEffect.SongUITimerLabel.Text = "00:00";
                                }
                            }
                        }
                    }

                    // Apply the new song by sending the command
                    //                    _api.ThirdParty.SendString($"/ma \"{songToApply.SongName}\" \"{targetMember.CharacterName}\"");
                    _api.ThirdParty.SendString($"/ma \"{songToApply.SongName}\" <me>"); // Changed to self-cast for testing

                    await Task.Delay(500);

                    ActiveSongEffect newEffect = new ActiveSongEffect
                    {
                        SongName = songToApply.SongName,
                        TargetName = targetMember.CharacterName,
                        RemainingDurationSeconds = songToApply.DurationSeconds,
                        AssociatedTimer = new System.Windows.Forms.Timer(),
                        AppliedByGroup = groupNumber,
                        SongUITimerLabel = songLabel,
                        StartTime = DateTime.UtcNow
                    };

                    newEffect.AssociatedTimer.Interval = 1000;
                    newEffect.AssociatedTimer.Tick += (senderObj, eventArgs) => ActiveSong_Tick(senderObj, eventArgs, newEffect);
                    newEffect.AssociatedTimer.Start();

                    targetEffects.Add(newEffect);
                    allActiveSongEffects.Add(newEffect);

                    if (songLabel != null)
                    {
                        if (songLabel.InvokeRequired)
                        {
                            songLabel.Invoke(new MethodInvoker(delegate { songLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}"; }));
                        }
                        else
                        {
                            songLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}";
                        }
                    }

                    // THIS IS THE MODIFIED DELAY:
                    int songPlayDuration = GetSongDelaySeconds();
                    await Task.Delay(TimeSpan.FromSeconds(songPlayDuration));
                } // End of targetMember loop for the current song

                // THE PREVIOUS userDefinedDelay LOGIC THAT WAS HERE IS NOW REMOVED.
            } // End of loop for selectedSongs (Song 1, Song 2)
        }

        private int GetSongDelaySeconds()
        {
            if (comboBoxSongDelay.SelectedItem != null && int.TryParse(comboBoxSongDelay.SelectedItem.ToString(), out int delay))
            {
                // Optional: Add validation for range 5-11 if necessary, though items are controlled
                if (delay >= 5 && delay <= 11)
                {
                    return delay;
                }
            }
            return 10; // Default to 10 seconds if parsing fails or value is somehow out of expected range
        }

        // Populates all song selection ComboBoxes with names from the Songs list
        // and sets default selections.
        private void PopulateSongComboBoxes()
        {
            var songNames = Songs.Select(s => s.SongName).ToArray();

            SongGroup1_Song1_ComboBox.Items.Clear();
            SongGroup1_Song1_ComboBox.Items.AddRange(songNames);
            SongGroup1_Song2_ComboBox.Items.Clear();
            SongGroup1_Song2_ComboBox.Items.AddRange(songNames);
            SongGroup2_Song1_ComboBox.Items.Clear();
            SongGroup2_Song1_ComboBox.Items.AddRange(songNames);
            SongGroup2_Song2_ComboBox.Items.Clear();
            SongGroup2_Song2_ComboBox.Items.AddRange(songNames);

            if (songNames.Length > 0)
            {
                int advancingMarchIndex = Songs.FindIndex(s => s.SongName == "Advancing March");
                int victoryMarchIndex = Songs.FindIndex(s => s.SongName == "Victory March");

                if (advancingMarchIndex != -1)
                {
                    SongGroup1_Song1_ComboBox.SelectedIndex = advancingMarchIndex;
                }
                else
                {
                    SongGroup1_Song1_ComboBox.SelectedIndex = 0; // Default if not found
                }

                if (victoryMarchIndex != -1)
                {
                    SongGroup1_Song2_ComboBox.SelectedIndex = victoryMarchIndex;
                }
                else
                {
                    // Default to second song or first if only one/zero songs and Advancing March wasn't found
                    SongGroup1_Song2_ComboBox.SelectedIndex = Math.Min(1, songNames.Length - 1);
                }

                int magesBalladIIIndex = Songs.FindIndex(s => s.SongName == "Mage's Ballad II");
                int magesBalladIndex = Songs.FindIndex(s => s.SongName == "Mage's Ballad");

                if (magesBalladIIIndex != -1)
                {
                    SongGroup2_Song1_ComboBox.SelectedIndex = magesBalladIIIndex;
                }
                else
                {
                    SongGroup2_Song1_ComboBox.SelectedIndex = 0; // Default if not found
                }

                if (magesBalladIndex != -1)
                {
                    SongGroup2_Song2_ComboBox.SelectedIndex = magesBalladIndex;
                }
                else
                {
                    SongGroup2_Song2_ComboBox.SelectedIndex = Math.Min(1, songNames.Length - 1);
                }
            }
        }

        #region "CHECK IF THE USER HAS AN ABILITY AND IT'S RECAST TIMER"

        public int AbilityRecast(string checked_abilityName)
        {
            int id = _api.Resources.GetAbility(checked_abilityName, 0).TimerID;
            List<int> IDs = _api.Recast.GetAbilityIds();
            for (int x = 0; x < IDs.Count; x++)
            {
                if (IDs[x] == id)
                {
                    return _api.Recast.GetAbilityRecast(x);
                }
            }
            return 0;
        }

        public static bool HasAbility(string checked_abilityName)
        {

            uint AbilityID = _api.Resources.GetAbility(checked_abilityName, 0).ID;


            if (_api.Player.HasAbility(AbilityID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        private void DEBUG_Click(object sender, EventArgs e)
        {
            string Debug_MSG = string.Empty;

            // Updated to show Member_List_Group1 for debugging
            if (Member_List_Group1 != null && Member_List_Group1.Count() > 0)
            {
                foreach (PartyRequirements CharacterD in Member_List_Group1)
                {
                    Debug_MSG = Debug_MSG + "G1: " + CharacterD.CharacterName + "\n";
                }
            }
            if (Member_List_Group2 != null && Member_List_Group2.Count() > 0)
            {
                foreach (PartyRequirements CharacterD in Member_List_Group2)
                {
                    Debug_MSG = Debug_MSG + "G2: " + CharacterD.CharacterName + "\n";
                }
            }

            MessageBox.Show(Debug_MSG);

        }

        private void PartyMembersGroup1_ListBox_SelectedValueChanged(object sender, EventArgs e) // Renamed method
        {
            Member_List_Group1.Clear(); // Updated list name

            int count = PartyMembersGroup1_ListBox.Items.Count; // Updated control name

            foreach (object selecteditem in PartyMembersGroup1_ListBox.SelectedItems) // Updated control name
            {
                string strItem = selecteditem as string;
                Member_List_Group1.Add(new PartyRequirements { Checked = true, CharacterName = strItem }); // Updated list name
            }
        }

        private void ReloadParty_Click(object sender, EventArgs e)
        {
            GrabParty();
        }

        private void PartyMembersGroup2_ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Member_List_Group2.Clear();
            foreach (object selecteditem in PartyMembersGroup2_ListBox.SelectedItems)
            {
                string strItem = selecteditem as string;
                Member_List_Group2.Add(new PartyRequirements { Checked = true, CharacterName = strItem });
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            FollowerTarget.Text = string.Empty;
        }

        private void labelFollowerTargetGroup2Clear_Click(object sender, EventArgs e)
        {
            FollowerTargetGroup2.Text = string.Empty;
        }

        private void buttonToggleManualFollow_Click(object sender, EventArgs e)
        {
            if (_api == null || _api.Player.LoginStatus != (int)LoginStatus.LoggedIn)
            {
                MetroMessageBox.Show(this, "Please select a POL process first.", "API Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!manualFollowActive) // If we are not currently manually following, try to start.
            {
                string targetToFollow = "";
                // Determine target based on currentFollowTargetGroup or fallback
                if (currentFollowTargetGroup == 1 && !string.IsNullOrWhiteSpace(FollowerTarget.Text) && FollowerTarget.Text != "Follower target name.")
                {
                    targetToFollow = FollowerTarget.Text;
                }
                else if (currentFollowTargetGroup == 2 && !string.IsNullOrWhiteSpace(FollowerTargetGroup2.Text) && FollowerTargetGroup2.Text != "Follower target G2 name.")
                {
                    targetToFollow = FollowerTargetGroup2.Text;
                }
                // Fallback logic if current group's target is empty
                else if (!string.IsNullOrWhiteSpace(FollowerTarget.Text) && FollowerTarget.Text != "Follower target name.")
                {
                    targetToFollow = FollowerTarget.Text;
                }
                else if (!string.IsNullOrWhiteSpace(FollowerTargetGroup2.Text) && FollowerTargetGroup2.Text != "Follower target G2 name.")
                {
                    targetToFollow = FollowerTargetGroup2.Text;
                }

                if (!string.IsNullOrWhiteSpace(targetToFollow))
                {
                    // Verify target exists before attempting to follow
                    uint tempTargetId = GetTargetIdByName(targetToFollow);
                    if (tempTargetId == 0)
                    {
                        MetroMessageBox.Show(this, $"Target '{targetToFollow}' not found in the current zone.", "Target Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Do not proceed if target not found
                    }

                    _api.ThirdParty.SendString($"/follow \"{targetToFollow}\"");
                    // If a brief delay was beneficial, it could be added here if this method becomes async
                    // await Task.Delay(300); 

                    // Set API flags to reflect that the bot considers itself to be in a follow state.
                    // These flags are important if other parts of the bot's logic (like the song cycle's own follow check)
                    // depend on them, or if the user's original "unfollow was working fine" means these flags + text command were the combo.
                    _api.AutoFollow.IsAutoFollowing = true;
                    isMoving = true;

                    manualFollowTargetName = targetToFollow;
                    manualFollowActive = true;
                    if (buttonToggleManualFollow.InvokeRequired)
                    {
                        buttonToggleManualFollow.Invoke(new MethodInvoker(delegate { buttonToggleManualFollow.Text = "Unfollow"; }));
                    }
                    else
                    {
                        buttonToggleManualFollow.Text = "Unfollow";
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "No valid target name entered in either follow field.", "No Target", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else // manualFollowActive is true, so stop following.
            {
                _api.ThirdParty.SendString("/follow"); // Placeholder for actual stop follow command.

                // Reset API/bot state variables, consistent with original interpretation of "unfollow was working"
                _api.AutoFollow.IsAutoFollowing = false;
                isMoving = false;

                // Clear the UI field that was used for manual follow
                if (!string.IsNullOrEmpty(manualFollowTargetName))
                {
                    if (FollowerTarget.Text == manualFollowTargetName)
                    {
                        FollowerTarget.Text = "Follower target name."; // Reset to placeholder
                    }
                    else if (FollowerTargetGroup2.Text == manualFollowTargetName)
                    {
                        FollowerTargetGroup2.Text = "Follower target G2 name."; // Reset to placeholder
                    }
                }
                manualFollowTargetName = "";
                manualFollowActive = false;
                if (buttonToggleManualFollow.InvokeRequired)
                {
                    buttonToggleManualFollow.Invoke(new MethodInvoker(delegate { buttonToggleManualFollow.Text = "Follow Current Target"; }));
                }
                else
                {
                    buttonToggleManualFollow.Text = "Follow Current Target";
                }
            }
        }

        // StartBotFollow and StopBotFollow methods would be here if not deleted in this step.

        private void PauseTimersChecks_Tick(object sender, EventArgs e)
        {
            if (_api != null)
            {
                if (_api.Player.LoginStatus == (int)LoginStatus.Loading || _api.Player.LoginStatus == (int)LoginStatus.Loading)
                {
                    if (PauseOnZone_Switch.Checked == true)
                    {
                        if (ActivityButton.InvokeRequired)
                        {
                            ActivityButton.Invoke(new MethodInvoker(delegate () { ActivityButton.BackColor = Color.Red; ActivityButton.Text = "ZONED!"; }));
                        }
                        else
                        {
                            ActivityButton.BackColor = Color.Red; ActivityButton.Text = "ZONED!";
                        }

                        botRunning = false;
                    }

                }
            }
        }

        private async void toggleBardRotationSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleBardRotationSwitch.Checked)
            {
                if (isBardRotationActive) return; // Already running

                if (!toggleGroup2Switch.Checked)
                {
                    MetroMessageBox.Show(this, "Bard Rotation requires Group 2 to be enabled. Please enable Group 2 first.", "Rotation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toggleBardRotationSwitch.Checked = false; // Revert toggle
                    return;
                }

                if (_api == null || _api.Player.LoginStatus != (int)LoginStatus.LoggedIn)
                {
                    MetroMessageBox.Show(this, "Please connect to a POL instance first.", "API Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    toggleBardRotationSwitch.Checked = false; // Revert toggle
                    return;
                }

                // Set the Auto Join toggle to ON
                if (toggleAutoJoinSwitch.InvokeRequired)
                {
                    toggleAutoJoinSwitch.Invoke(new MethodInvoker(delegate { toggleAutoJoinSwitch.Checked = true; }));
                }
                else
                {
                    toggleAutoJoinSwitch.Checked = true;
                }

                // Send custom rotation start call
                if (comboBoxRotationStartCall.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBoxRotationStartCall.SelectedItem.ToString()))
                {
                    // We need to ensure _api is not null and player is logged in before sending command.
                    // These checks are already performed above for starting the rotation.
                    // We also need a CancellationToken. Since this is before the main CancellationTokenSource for the rotation is created,
                    // we might not have one. Sending a command should be quick.
                    // If SendCommand requires a token and it's problematic here, we might need to adjust SendCommand or call _api.ThirdParty.SendString directly.
                    // For now, let's assume SendCommand can be called or we can use _api.ThirdParty.SendString.
                    // The SendCommand helper is async, so this method part might need to be async if it isn't already.
                    // The `toggleBardRotationSwitch_CheckedChanged` is already `async void`.

                    // Let's use a temporary CancellationToken if SendCommand strictly requires it,
                    // or adapt if SendCommand can be called without one for a brief command.
                    // Given SendCommand is defined as: async Task SendCommand(string command, int delayMs = 1000)
                    // which internally uses the main cancellationToken passed to ExecuteBardRotation,
                    // we cannot use it directly here before bardRotationCancellationTokenSource is created.
                    // So, we will use _api.ThirdParty.SendString directly.

                    _api.ThirdParty.SendString($"/p Bard Rotation start: {comboBoxRotationStartCall.SelectedItem.ToString()}");
                    await Task.Delay(1000); // Brief delay to allow message to send, adjust if needed.
                }

                isBardRotationActive = true;
                bardRotationCancellationTokenSource = new CancellationTokenSource();
                // ActivityButton.Enabled = false; // Optional: disable manual start/stop

                try
                {
                    await ExecuteBardRotation(bardRotationCancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    MetroMessageBox.Show(this, "Bard Rotation was cancelled.", "Rotation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // --- START OF NEW CLEANUP LOGIC ---
                    if (_api != null && _api.Player != null) // Ensure API is available
                    {
                        string playerName = _api.Player.Name;
                        if (activeSongEffectsByTarget.ContainsKey(playerName))
                        {
                            // Find effects applied by the rotation toggle to the player
                            var rotationPlayerEffectsToCancel = activeSongEffectsByTarget[playerName]
                                .Where(eff => eff.IsFromRotationToggle == true)
                                .ToList(); // Create a copy to modify the original list while iterating

                            foreach (var effect in rotationPlayerEffectsToCancel)
                            {
                                effect.AssociatedTimer.Stop();
                                effect.AssociatedTimer.Dispose();

                                if (effect.SongUITimerLabel != null)
                                {
                                    if (effect.SongUITimerLabel.InvokeRequired)
                                    {
                                        effect.SongUITimerLabel.Invoke(new MethodInvoker(() => effect.SongUITimerLabel.Text = "00:00"));
                                    }
                                    else
                                    {
                                        effect.SongUITimerLabel.Text = "00:00";
                                    }
                                }
                                // Remove from player-specific list
                                activeSongEffectsByTarget[playerName].Remove(effect);
                                // Also remove from the global list of all active effects
                                allActiveSongEffects.Remove(effect);
                            }
                        }
                    }
                    // --- END OF NEW CLEANUP LOGIC ---
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"An error occurred during Bard Rotation: {ex.Message}", "Rotation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    isBardRotationActive = false;
                    if (this.IsHandleCreated && toggleBardRotationSwitch.IsHandleCreated) // Ensure control is still valid
                    {
                        toggleBardRotationSwitch.Checked = false; // Ensure toggle is off
                    }
                    // ActivityButton.Enabled = true; // Re-enable
                    if (bardRotationCancellationTokenSource != null)
                    {
                        bardRotationCancellationTokenSource.Dispose();
                        bardRotationCancellationTokenSource = null;
                    }
                }
            }
            else // Toggle switched OFF
            {
                if (isBardRotationActive && bardRotationCancellationTokenSource != null && !bardRotationCancellationTokenSource.IsCancellationRequested)
                {
                    bardRotationCancellationTokenSource.Cancel();
                }
            }
        }

        private async Task ExecuteBardRotation(CancellationToken cancellationToken)
        {
            if (!IsPlayerInParty())
            {
                // Show a message to the user.
                MetroMessageBox.Show(this, "Bard Rotation: You must be in a party with at least one other active member to start the rotation.", "Party Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Throwing OperationCanceledException will be caught by the calling method's finally block
                // to reset the toggle switch and rotation state.
                throw new OperationCanceledException("Party required to start rotation.");
            }

            // Helper function to send command and delay
            async Task SendCommand(string command, int delayMs = 1000)
            {
                if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
                _api.ThirdParty.SendString(command);
                await Task.Delay(delayMs, cancellationToken);
            }

            // Helper function to play songs for a group
            async Task PlaySongsForGroup(int groupNum, string followTargetName, List<SongData> songsToPlay, List<PartyRequirements> partyMembers)
            {
                string playerName = _api.Player.Name;
                if (!activeSongEffectsByTarget.ContainsKey(playerName))
                {
                    activeSongEffectsByTarget[playerName] = new List<ActiveSongEffect>();
                }
                List<ActiveSongEffect> playerEffects = activeSongEffectsByTarget[playerName];

                if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

                if (!string.IsNullOrWhiteSpace(followTargetName) && followTargetName != "Follower target name." && followTargetName != "Follower target G2 name.")
                {
                    await SendCommand($"/follow \"{followTargetName}\"");
                    await Task.Delay(3000, cancellationToken);
                }

                bool partyCheckSuccessful = false;
                for (int i = 1; i <= 3; i++)
                {
                    if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

                    if (IsPlayerInParty())
                    {
                        Console.WriteLine($"Party check successful on attempt {i} for Group {groupNum}.");
                        partyCheckSuccessful = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Party check failed on attempt {i} for Group {groupNum}. Retrying in {GetSongDelaySeconds()} seconds...");
                        if (i < 3) // Don't wait after the last attempt
                        {
                            await Task.Delay(GetSongDelaySeconds() * 1000, cancellationToken);
                        }
                    }
                }

                if (!partyCheckSuccessful)
                {
                    MetroMessageBox.Show(this, $"Bard Rotation (Group {groupNum}): Not in a valid party with other active members after 3 attempts. Aborting this group's songs.", "Party Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Abort songs for this group
                }

                // It's good practice to refresh party details if the check passes, 
                // though IsPlayerInParty already fetches them. 
                // If GrabParty() updates UI elements specifically needed before song casting, keep it.
                // Otherwise, it might be redundant if IsPlayerInParty() is comprehensive enough.
                // For now, let's assume GrabParty() is still useful here if the party check passes.
                GrabParty();

                foreach (var song in songsToPlay)
                {
                    if (song == null) continue;
                    if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

                    // Announce song to party chat
                    await SendCommand($"/p Now playing: {song.SongName}!", 1500);
                    _api.ThirdParty.SendString($"/ma \"{song.SongName}\" <me>");

                    if (groupNum == 1)
                    {
                        Label currentSongLabel = null;
                        int songIndexInGroup = songsToPlay.IndexOf(song);

                        if (songIndexInGroup == 0) currentSongLabel = SongGroup1_Timer1_Label;
                        else if (songIndexInGroup == 1) currentSongLabel = SongGroup1_Timer2_Label;

                        // Overwrite logic for group 1 songs on the player
                        var existingGroup1PlayerEffects = playerEffects.Where(eff => eff.AppliedByGroup == 1).ToList();
                        if (existingGroup1PlayerEffects.Count >= 2) // Max 2 songs from this group for the player
                        {
                            ActiveSongEffect oldestEffect = existingGroup1PlayerEffects.OrderBy(eff => eff.StartTime).FirstOrDefault();
                            if (oldestEffect != null)
                            {
                                oldestEffect.AssociatedTimer.Stop();
                                oldestEffect.AssociatedTimer.Dispose();
                                playerEffects.Remove(oldestEffect); // Remove from player-specific list
                                allActiveSongEffects.Remove(oldestEffect); // Remove from global list
                                if (oldestEffect.SongUITimerLabel != null)
                                {
                                    if (oldestEffect.SongUITimerLabel.InvokeRequired)
                                    {
                                        oldestEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { oldestEffect.SongUITimerLabel.Text = "00:00"; }));
                                    }
                                    else
                                    {
                                        oldestEffect.SongUITimerLabel.Text = "00:00";
                                    }
                                }
                            }
                        }

                        // Create and add new effect for the player
                        ActiveSongEffect newEffect = new ActiveSongEffect
                        {
                            SongName = song.SongName,
                            TargetName = playerName, // Target is the player
                            RemainingDurationSeconds = song.DurationSeconds,
                            AssociatedTimer = new System.Windows.Forms.Timer(),
                            AppliedByGroup = 1, // Song applied by Group 1 rotation
                            IsFromRotationToggle = true, // <--- SET THIS
                            SongUITimerLabel = currentSongLabel,
                            StartTime = DateTime.UtcNow
                        };

                        newEffect.AssociatedTimer.Interval = 1000;
                        // Ensure newEffect is captured correctly in the lambda
                        newEffect.AssociatedTimer.Tick += (senderObj, eventArgs) => ActiveSong_Tick(senderObj, eventArgs, newEffect);
                        newEffect.AssociatedTimer.Start();

                        playerEffects.Add(newEffect); // Add to player-specific list
                        allActiveSongEffects.Add(newEffect); // Add to global list

                        // Update UI label for the new song
                        if (newEffect.SongUITimerLabel != null)
                        {
                            if (newEffect.SongUITimerLabel.InvokeRequired)
                            {
                                newEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { newEffect.SongUITimerLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}"; }));
                            }
                            else
                            {
                                newEffect.SongUITimerLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}";
                            }
                        }
                    } // End of if (groupNum == 1)
                    else if (groupNum == 2) // Add this new block for Group 2
                    {
                        Label currentSongLabel = null;
                        int songIndexInGroup = songsToPlay.IndexOf(song);

                        if (songIndexInGroup == 0) currentSongLabel = SongGroup2_Timer1_Label;
                        else if (songIndexInGroup == 1) currentSongLabel = SongGroup2_Timer2_Label;

                        // Overwrite logic for group 2 songs on the player
                        // Note: playerEffects is already defined at the start of PlaySongsForGroup
                        var existingGroup2PlayerEffects = playerEffects.Where(eff => eff.AppliedByGroup == 2).ToList();
                        if (existingGroup2PlayerEffects.Count >= 2) // Max 2 songs from this group for the player
                        {
                            ActiveSongEffect oldestEffect = existingGroup2PlayerEffects.OrderBy(eff => eff.StartTime).FirstOrDefault();
                            if (oldestEffect != null)
                            {
                                oldestEffect.AssociatedTimer.Stop();
                                oldestEffect.AssociatedTimer.Dispose();
                                playerEffects.Remove(oldestEffect);
                                allActiveSongEffects.Remove(oldestEffect);
                                if (oldestEffect.SongUITimerLabel != null)
                                {
                                    if (oldestEffect.SongUITimerLabel.InvokeRequired)
                                    {
                                        oldestEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { oldestEffect.SongUITimerLabel.Text = "00:00"; }));
                                    }
                                    else
                                    {
                                        oldestEffect.SongUITimerLabel.Text = "00:00";
                                    }
                                }
                            }
                        }

                        // Create and add new effect for the player for Group 2 song
                        ActiveSongEffect newEffect = new ActiveSongEffect
                        {
                            SongName = song.SongName,
                            TargetName = playerName, // Target is the player
                            RemainingDurationSeconds = song.DurationSeconds,
                            AssociatedTimer = new System.Windows.Forms.Timer(),
                            AppliedByGroup = 2, // Song applied by Group 2 rotation
                            IsFromRotationToggle = true, // <--- SET THIS
                            SongUITimerLabel = currentSongLabel,
                            StartTime = DateTime.UtcNow
                        };

                        newEffect.AssociatedTimer.Interval = 1000;
                        newEffect.AssociatedTimer.Tick += (senderObj, eventArgs) => ActiveSong_Tick(senderObj, eventArgs, newEffect);
                        newEffect.AssociatedTimer.Start();

                        playerEffects.Add(newEffect);
                        allActiveSongEffects.Add(newEffect);

                        // Update UI label for the new Group 2 song
                        if (newEffect.SongUITimerLabel != null)
                        {
                            if (newEffect.SongUITimerLabel.InvokeRequired)
                            {
                                newEffect.SongUITimerLabel.Invoke(new MethodInvoker(delegate { newEffect.SongUITimerLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}"; }));
                            }
                            else
                            {
                                newEffect.SongUITimerLabel.Text = $"{newEffect.SongName.Split(' ')[0]}: {TimeSpan.FromSeconds(newEffect.RemainingDurationSeconds):mm\\:ss}";
                            }
                        }
                    } // End of else if (groupNum == 2)

                    // THIS IS THE MODIFIED DELAY:
                    int songPlayDuration = GetSongDelaySeconds();
                    await Task.Delay(songPlayDuration * 1000, cancellationToken);
                }

                string leaveMessage = $"/p Bard Rotation: Group {groupNum} songs complete. Leaving party.";
                if (comboBoxLeavePartyCall.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBoxLeavePartyCall.SelectedItem.ToString()))
                {
                    leaveMessage += " " + comboBoxLeavePartyCall.SelectedItem.ToString();
                }
                await SendCommand(leaveMessage, 1500);
                await SendCommand("/pcmd leave", 2000); // Changed command
            }

            // --- Rotation Start ---
            //MetroMessageBox.Show(this, "Bard Rotation Started. Ensure you are in a party or can accept invites for each group.", "Rotation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Task.Delay(2000, cancellationToken);

            // GROUP 1
            var group1Songs = new List<SongData> {
                Songs.FirstOrDefault(s => s.Position == SongGroup1_Song1_ComboBox.SelectedIndex),
                Songs.FirstOrDefault(s => s.Position == SongGroup1_Song2_ComboBox.SelectedIndex)
            };
            await PlaySongsForGroup(1, FollowerTarget.Text, group1Songs, Member_List_Group1);
            if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

            //MetroMessageBox.Show(this, "Bard Rotation: Group 1 complete. Waiting for new party invite for Group 2 (auto-join is active).", "Rotation Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Task.Delay(5000, cancellationToken); // Shortened wait
            if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();

            // GROUP 2
            if (!toggleGroup2Switch.Checked)
            {
                MetroMessageBox.Show(this, "Bard Rotation: Group 2 was disabled (UI toggle). Skipping Group 2.", "Rotation Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var group2Songs = new List<SongData> {
                    Songs.FirstOrDefault(s => s.Position == SongGroup2_Song1_ComboBox.SelectedIndex),
                    Songs.FirstOrDefault(s => s.Position == SongGroup2_Song2_ComboBox.SelectedIndex)
                };
                await PlaySongsForGroup(2, FollowerTargetGroup2.Text, group2Songs, Member_List_Group2);
            }

            if (cancellationToken.IsCancellationRequested) cancellationToken.ThrowIfCancellationRequested();
            //MetroMessageBox.Show(this, "Bard Rotation Finished.", "Rotation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toggleAutoJoinSwitch_CheckedChanged(object sender, EventArgs e)
        {
            // Currently, no specific action is needed when this toggle changes,
            // as its state is read directly in Song_Timer_TickAsync.
            // This handler is here for completeness and future use if needed.
            // Example: Could add logging here if desired:
            // if (toggleAutoJoinSwitch.Checked)
            // {
            //     Console.WriteLine("Auto Join on Invite: Enabled by user.");
            // }
            // else
            // {
            //     Console.WriteLine("Auto Join on Invite: Disabled by user.");
            // }
        }

        private void SongGroup1_Song1_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxSongDelay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toggleSoulVoiceSwitch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelSoulVoice_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxBardOptionsGroup2_Enter(object sender, EventArgs e)
        {

        }

        private void PauseOnZone_Switch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxSongGroup2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxPartyGroup2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void labelSongDelay_Click(object sender, EventArgs e)
        {

        }
    }
}