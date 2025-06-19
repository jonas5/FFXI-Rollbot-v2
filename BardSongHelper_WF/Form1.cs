﻿using EliteMMO.API;
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

        #endregion

        public Form1()
        {
            InitializeComponent();
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

            this.Text = "Bard Song Helper v1.0"; // Added
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

            processids.SelectedIndex = POLID.SelectedIndex;
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

                if (botRunning == true && !knownCities.Contains(_api.Player.ZoneId) && isMoving == false && manualFollowActive == false)
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

                    await Task.Delay(TimeSpan.FromSeconds(songToApply.CastTimeSeconds));
                }
            }
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
                SongGroup1_Song1_ComboBox.SelectedIndex = 0;
                SongGroup1_Song2_ComboBox.SelectedIndex = Math.Min(1, songNames.Length - 1);
                SongGroup2_Song1_ComboBox.SelectedIndex = 0;
                SongGroup2_Song2_ComboBox.SelectedIndex = Math.Min(1, songNames.Length - 1);
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
                    if (buttonToggleManualFollow.InvokeRequired) {
                        buttonToggleManualFollow.Invoke(new MethodInvoker(delegate { buttonToggleManualFollow.Text = "Unfollow"; }));
                    } else {
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
                if (buttonToggleManualFollow.InvokeRequired) {
                    buttonToggleManualFollow.Invoke(new MethodInvoker(delegate { buttonToggleManualFollow.Text = "Follow Current Target"; }));
                } else {
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
    }
}