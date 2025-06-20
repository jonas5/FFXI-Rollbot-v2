namespace BardSongHelper_WF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxLeavePartyCall = new MetroFramework.Controls.MetroComboBox();
            this.comboBoxRotationStartCall = new MetroFramework.Controls.MetroComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Select_POLID = new System.Windows.Forms.Button();
            this.POLID = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FollowerTarget = new MetroFramework.Controls.MetroTextBox();
            this.SongGroup1_Song1_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup1_Song2_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup1_Timer1_Label = new System.Windows.Forms.Label();
            this.SongGroup1_Timer2_Label = new System.Windows.Forms.Label();
            this.ActivityButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.PartyMembersGroup1_ListBox = new System.Windows.Forms.ListBox();
            this.Song_Timer = new System.Windows.Forms.Timer(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.DEBUG = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.labelSoulVoice = new MetroFramework.Controls.MetroLabel();
            this.toggleSoulVoiceSwitch = new MetroFramework.Controls.MetroToggle();
            this.labelSongDelay = new MetroFramework.Controls.MetroLabel();
            this.comboBoxSongDelay = new System.Windows.Forms.ComboBox();
            this.labelBardRotationSwitch = new MetroFramework.Controls.MetroLabel();
            this.toggleBardRotationSwitch = new MetroFramework.Controls.MetroToggle();
            this.labelAutoJoin = new MetroFramework.Controls.MetroLabel();
            this.toggleAutoJoinSwitch = new MetroFramework.Controls.MetroToggle();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.PauseOnZone_Switch = new MetroFramework.Controls.MetroToggle();
            this.PauseTimersChecks = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSongGroup2 = new System.Windows.Forms.GroupBox();
            this.toggleGroup2Switch = new MetroFramework.Controls.MetroToggle();
            this.groupBoxBardOptionsGroup2 = new System.Windows.Forms.GroupBox();
            this.labelFollowerTargetGroup2Clear = new System.Windows.Forms.Label();
            this.FollowerTargetGroup2 = new MetroFramework.Controls.MetroTextBox();
            this.SongGroup2_Song1_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup2_Song2_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup2_Timer1_Label = new System.Windows.Forms.Label();
            this.SongGroup2_Timer2_Label = new System.Windows.Forms.Label();
            this.groupBoxPartyGroup2 = new System.Windows.Forms.GroupBox();
            this.PartyMembersGroup2_ListBox = new System.Windows.Forms.ListBox();
            this.ReloadParty = new System.Windows.Forms.Button();
            this.buttonToggleManualFollow = new MetroFramework.Controls.MetroButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBoxSongGroup2.SuspendLayout();
            this.groupBoxBardOptionsGroup2.SuspendLayout();
            this.groupBoxPartyGroup2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Select_POLID);
            this.groupBox1.Controls.Add(this.POLID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " SELECT PROCESS ";
            // 
            // Select_POLID
            // 
            this.Select_POLID.Location = new System.Drawing.Point(322, 16);
            this.Select_POLID.Name = "Select_POLID";
            this.Select_POLID.Size = new System.Drawing.Size(111, 31);
            this.Select_POLID.TabIndex = 3;
            this.Select_POLID.Text = "SELECT";
            this.Select_POLID.UseVisualStyleBackColor = true;
            this.Select_POLID.Click += new System.EventHandler(this.Select_POLID_Click);
            // 
            // POLID
            // 
            this.POLID.FormattingEnabled = true;
            this.POLID.ItemHeight = 23;
            this.POLID.Location = new System.Drawing.Point(7, 16);
            this.POLID.Name = "POLID";
            this.POLID.Size = new System.Drawing.Size(293, 29);
            this.POLID.TabIndex = 2;
            this.POLID.UseSelectable = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.SongGroup1_Song1_ComboBox);
            this.groupBox2.Controls.Add(this.SongGroup1_Song2_ComboBox);
            this.groupBox2.Controls.Add(this.SongGroup1_Timer1_Label);
            this.groupBox2.Controls.Add(this.SongGroup1_Timer2_Label);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " SONG GROUP 1 ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.FollowerTarget);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(7, 90);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(226, 56);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " FOLLOW TARGET ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FollowerTarget
            // 
            // 
            // 
            // 
            this.FollowerTarget.CustomButton.Image = null;
            this.FollowerTarget.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.FollowerTarget.CustomButton.Name = "";
            this.FollowerTarget.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FollowerTarget.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FollowerTarget.CustomButton.TabIndex = 1;
            this.FollowerTarget.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FollowerTarget.CustomButton.UseSelectable = true;
            this.FollowerTarget.CustomButton.Visible = false;
            this.FollowerTarget.Lines = new string[] {
        "Follower target name."};
            this.FollowerTarget.Location = new System.Drawing.Point(6, 19);
            this.FollowerTarget.MaxLength = 32767;
            this.FollowerTarget.Name = "FollowerTarget";
            this.FollowerTarget.PasswordChar = '\0';
            this.FollowerTarget.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FollowerTarget.SelectedText = "";
            this.FollowerTarget.SelectionLength = 0;
            this.FollowerTarget.SelectionStart = 0;
            this.FollowerTarget.ShortcutsEnabled = true;
            this.FollowerTarget.Size = new System.Drawing.Size(214, 23);
            this.FollowerTarget.TabIndex = 6;
            this.FollowerTarget.Text = "Follower target name.";
            this.FollowerTarget.UseSelectable = true;
            this.FollowerTarget.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FollowerTarget.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SongGroup1_Song1_ComboBox
            // 
            this.SongGroup1_Song1_ComboBox.FormattingEnabled = true;
            this.SongGroup1_Song1_ComboBox.ItemHeight = 23;
            this.SongGroup1_Song1_ComboBox.Location = new System.Drawing.Point(6, 19);
            this.SongGroup1_Song1_ComboBox.MaxDropDownItems = 5;
            this.SongGroup1_Song1_ComboBox.Name = "SongGroup1_Song1_ComboBox";
            this.SongGroup1_Song1_ComboBox.Size = new System.Drawing.Size(227, 29);
            this.SongGroup1_Song1_ComboBox.TabIndex = 2;
            this.SongGroup1_Song1_ComboBox.UseSelectable = true;
            // 
            // SongGroup1_Song2_ComboBox
            // 
            this.SongGroup1_Song2_ComboBox.FormattingEnabled = true;
            this.SongGroup1_Song2_ComboBox.ItemHeight = 23;
            this.SongGroup1_Song2_ComboBox.Location = new System.Drawing.Point(7, 55);
            this.SongGroup1_Song2_ComboBox.MaxDropDownItems = 5;
            this.SongGroup1_Song2_ComboBox.Name = "SongGroup1_Song2_ComboBox";
            this.SongGroup1_Song2_ComboBox.Size = new System.Drawing.Size(226, 29);
            this.SongGroup1_Song2_ComboBox.TabIndex = 3;
            this.SongGroup1_Song2_ComboBox.UseSelectable = true;
            // 
            // SongGroup1_Timer1_Label
            // 
            this.SongGroup1_Timer1_Label.Location = new System.Drawing.Point(238, 24);
            this.SongGroup1_Timer1_Label.Name = "SongGroup1_Timer1_Label";
            this.SongGroup1_Timer1_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup1_Timer1_Label.TabIndex = 4;
            this.SongGroup1_Timer1_Label.Text = "00:00";
            // 
            // SongGroup1_Timer2_Label
            // 
            this.SongGroup1_Timer2_Label.Location = new System.Drawing.Point(238, 60);
            this.SongGroup1_Timer2_Label.Name = "SongGroup1_Timer2_Label";
            this.SongGroup1_Timer2_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup1_Timer2_Label.TabIndex = 5;
            this.SongGroup1_Timer2_Label.Text = "00:00";
            // 
            // ActivityButton
            // 
            this.ActivityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityButton.Location = new System.Drawing.Point(317, 536);
            this.ActivityButton.Name = "ActivityButton";
            this.ActivityButton.Size = new System.Drawing.Size(152, 40);
            this.ActivityButton.TabIndex = 6;
            this.ActivityButton.Text = "START";
            this.ActivityButton.UseVisualStyleBackColor = true;
            this.ActivityButton.Click += new System.EventHandler(this.ActivityButton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.PartyMembersGroup1_ListBox);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(317, 124);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(152, 177);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " GROUP 1 TARGETS ";
            // 
            // PartyMembersGroup1_ListBox
            // 
            this.PartyMembersGroup1_ListBox.FormattingEnabled = true;
            this.PartyMembersGroup1_ListBox.ItemHeight = 12;
            this.PartyMembersGroup1_ListBox.Location = new System.Drawing.Point(6, 19);
            this.PartyMembersGroup1_ListBox.Name = "PartyMembersGroup1_ListBox";
            this.PartyMembersGroup1_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PartyMembersGroup1_ListBox.Size = new System.Drawing.Size(136, 148);
            this.PartyMembersGroup1_ListBox.TabIndex = 0;
            this.PartyMembersGroup1_ListBox.SelectedValueChanged += new System.EventHandler(this.PartyMembersGroup1_ListBox_SelectedValueChanged);
            // 
            // Song_Timer
            // 
            this.Song_Timer.Enabled = true;
            this.Song_Timer.Interval = 500;
            this.Song_Timer.Tick += new System.EventHandler(this.Song_Timer_TickAsync);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // DEBUG
            // 
            this.DEBUG.Location = new System.Drawing.Point(355, 34);
            this.DEBUG.Name = "DEBUG";
            this.DEBUG.Size = new System.Drawing.Size(75, 23);
            this.DEBUG.TabIndex = 9;
            this.DEBUG.Text = "DEBUG";
            this.DEBUG.UseVisualStyleBackColor = true;
            this.DEBUG.Visible = false;
            this.DEBUG.Click += new System.EventHandler(this.DEBUG_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.labelSoulVoice);
            this.groupBox8.Controls.Add(this.toggleSoulVoiceSwitch);
            this.groupBox8.Controls.Add(this.labelSongDelay);
            this.groupBox8.Controls.Add(this.comboBoxSongDelay);
            this.groupBox8.Controls.Add(this.labelBardRotationSwitch);
            this.groupBox8.Controls.Add(this.toggleBardRotationSwitch);
            this.groupBox8.Controls.Add(this.labelAutoJoin);
            this.groupBox8.Controls.Add(this.toggleAutoJoinSwitch);
            this.groupBox8.Controls.Add(this.metroLabel5);
            this.groupBox8.Controls.Add(this.PauseOnZone_Switch);
            this.groupBox8.Controls.Add(this.comboBoxLeavePartyCall);
            this.groupBox8.Controls.Add(this.comboBoxRotationStartCall);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(11, 473);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(300, 228);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " PROGRAM OPTIONS ";
            // 
            // labelSoulVoice
            // 
            this.labelSoulVoice.AutoSize = true;
            this.labelSoulVoice.Location = new System.Drawing.Point(7, 113);
            this.labelSoulVoice.Name = "labelSoulVoice";
            this.labelSoulVoice.Size = new System.Drawing.Size(103, 19);
            this.labelSoulVoice.TabIndex = 1;
            this.labelSoulVoice.Text = "Soul Voice Next:";
            this.labelSoulVoice.Click += new System.EventHandler(this.labelSoulVoice_Click);
            // 
            // toggleSoulVoiceSwitch
            // 
            this.toggleSoulVoiceSwitch.AutoSize = true;
            this.toggleSoulVoiceSwitch.Location = new System.Drawing.Point(208, 116);
            this.toggleSoulVoiceSwitch.Name = "toggleSoulVoiceSwitch";
            this.toggleSoulVoiceSwitch.Size = new System.Drawing.Size(80, 16);
            this.toggleSoulVoiceSwitch.TabIndex = 2;
            this.toggleSoulVoiceSwitch.Text = "Off";
            this.toggleSoulVoiceSwitch.UseSelectable = true;
            this.toggleSoulVoiceSwitch.CheckedChanged += new System.EventHandler(this.toggleSoulVoiceSwitch_CheckedChanged);
            // 
            // labelSongDelay
            // 
            this.labelSongDelay.AutoSize = true;
            this.labelSongDelay.Location = new System.Drawing.Point(6, 40);
            this.labelSongDelay.Name = "labelSongDelay";
            this.labelSongDelay.Size = new System.Drawing.Size(95, 19);
            this.labelSongDelay.TabIndex = 2;
            this.labelSongDelay.Text = "Song Delay (s):";
            // 
            // comboBoxSongDelay
            // 
            this.comboBoxSongDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSongDelay.FormattingEnabled = true;
            this.comboBoxSongDelay.Location = new System.Drawing.Point(238, 36);
            this.comboBoxSongDelay.Name = "comboBoxSongDelay";
            this.comboBoxSongDelay.Size = new System.Drawing.Size(50, 20);
            this.comboBoxSongDelay.TabIndex = 3;
            // 
            // labelBardRotationSwitch
            // 
            this.labelBardRotationSwitch.AutoSize = true;
            this.labelBardRotationSwitch.Location = new System.Drawing.Point(6, 67);
            this.labelBardRotationSwitch.Name = "labelBardRotationSwitch";
            this.labelBardRotationSwitch.Size = new System.Drawing.Size(93, 19);
            this.labelBardRotationSwitch.TabIndex = 4;
            this.labelBardRotationSwitch.Text = "Bard Rotation:";
            // 
            // toggleBardRotationSwitch
            // 
            this.toggleBardRotationSwitch.AutoSize = true;
            this.toggleBardRotationSwitch.Location = new System.Drawing.Point(208, 68);
            this.toggleBardRotationSwitch.Name = "toggleBardRotationSwitch";
            this.toggleBardRotationSwitch.Size = new System.Drawing.Size(80, 16);
            this.toggleBardRotationSwitch.TabIndex = 5;
            this.toggleBardRotationSwitch.Text = "Off";
            this.toggleBardRotationSwitch.UseSelectable = true;
            this.toggleBardRotationSwitch.CheckedChanged += new System.EventHandler(this.toggleBardRotationSwitch_CheckedChanged);
            // 
            // labelAutoJoin
            // 
            this.labelAutoJoin.AutoSize = true;
            this.labelAutoJoin.Location = new System.Drawing.Point(6, 90);
            this.labelAutoJoin.Name = "labelAutoJoin";
            this.labelAutoJoin.Size = new System.Drawing.Size(120, 19);
            this.labelAutoJoin.TabIndex = 6;
            this.labelAutoJoin.Text = "Auto Join on Invite:";
            // 
            // toggleAutoJoinSwitch
            // 
            this.toggleAutoJoinSwitch.AutoSize = true;
            this.toggleAutoJoinSwitch.Location = new System.Drawing.Point(208, 92);
            this.toggleAutoJoinSwitch.Name = "toggleAutoJoinSwitch";
            this.toggleAutoJoinSwitch.Size = new System.Drawing.Size(80, 16);
            this.toggleAutoJoinSwitch.TabIndex = 7;
            this.toggleAutoJoinSwitch.Text = "Off";
            this.toggleAutoJoinSwitch.UseSelectable = true;
            this.toggleAutoJoinSwitch.CheckedChanged += new System.EventHandler(this.toggleAutoJoinSwitch_CheckedChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(6, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(95, 19);
            this.metroLabel5.TabIndex = 1;
            this.metroLabel5.Text = "Pause on Zone";
            // 
            // PauseOnZone_Switch
            // 
            this.PauseOnZone_Switch.AutoSize = true;
            this.PauseOnZone_Switch.DisplayStatus = false;
            this.PauseOnZone_Switch.Location = new System.Drawing.Point(238, 14);
            this.PauseOnZone_Switch.Name = "PauseOnZone_Switch";
            this.PauseOnZone_Switch.Size = new System.Drawing.Size(50, 16);
            this.PauseOnZone_Switch.TabIndex = 0;
            this.PauseOnZone_Switch.Text = "Off";
            this.PauseOnZone_Switch.UseSelectable = true;
            this.PauseOnZone_Switch.CheckedChanged += new System.EventHandler(this.PauseOnZone_Switch_CheckedChanged);
            // 
            // comboBoxLeavePartyCall
            //
            this.comboBoxLeavePartyCall.FormattingEnabled = true;
            this.comboBoxLeavePartyCall.ItemHeight = 23;
            this.comboBoxLeavePartyCall.Location = new System.Drawing.Point(6, 140);
            this.comboBoxLeavePartyCall.Name = "comboBoxLeavePartyCall";
            this.comboBoxLeavePartyCall.Size = new System.Drawing.Size(282, 29);
            this.comboBoxLeavePartyCall.TabIndex = 8;
            this.comboBoxLeavePartyCall.UseSelectable = true;
            this.comboBoxLeavePartyCall.PromptText = "Call on party leave...";
            //
            // comboBoxRotationStartCall
            //
            this.comboBoxRotationStartCall.FormattingEnabled = true;
            this.comboBoxRotationStartCall.ItemHeight = 23;
            this.comboBoxRotationStartCall.Location = new System.Drawing.Point(6, 175);
            this.comboBoxRotationStartCall.Name = "comboBoxRotationStartCall";
            this.comboBoxRotationStartCall.Size = new System.Drawing.Size(282, 29);
            this.comboBoxRotationStartCall.TabIndex = 9;
            this.comboBoxRotationStartCall.UseSelectable = true;
            this.comboBoxRotationStartCall.PromptText = "Call on rotation start...";
            //
            // PauseTimersChecks
            // 
            this.PauseTimersChecks.Enabled = true;
            this.PauseTimersChecks.Interval = 500;
            this.PauseTimersChecks.Tick += new System.EventHandler(this.PauseTimersChecks_Tick);
            // 
            // groupBoxSongGroup2
            // 
            this.groupBoxSongGroup2.Controls.Add(this.toggleGroup2Switch);
            this.groupBoxSongGroup2.Controls.Add(this.groupBoxBardOptionsGroup2);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Song1_ComboBox);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Song2_ComboBox);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Timer1_Label);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Timer2_Label);
            this.groupBoxSongGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongGroup2.Location = new System.Drawing.Point(11, 307);
            this.groupBoxSongGroup2.Name = "groupBoxSongGroup2";
            this.groupBoxSongGroup2.Size = new System.Drawing.Size(300, 160);
            this.groupBoxSongGroup2.TabIndex = 11;
            this.groupBoxSongGroup2.TabStop = false;
            this.groupBoxSongGroup2.Text = " SONG GROUP 2 ";
            this.groupBoxSongGroup2.Enter += new System.EventHandler(this.groupBoxSongGroup2_Enter);
            // 
            // toggleGroup2Switch
            // 
            this.toggleGroup2Switch.AutoSize = true;
            this.toggleGroup2Switch.Checked = true;
            this.toggleGroup2Switch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleGroup2Switch.Location = new System.Drawing.Point(150, 0);
            this.toggleGroup2Switch.Name = "toggleGroup2Switch";
            this.toggleGroup2Switch.Size = new System.Drawing.Size(80, 16);
            this.toggleGroup2Switch.TabIndex = 0;
            this.toggleGroup2Switch.Text = "On";
            this.toggleGroup2Switch.UseSelectable = true;
            this.toggleGroup2Switch.CheckedChanged += new System.EventHandler(this.toggleGroup2Switch_CheckedChanged);
            // 
            // groupBoxBardOptionsGroup2
            // 
            this.groupBoxBardOptionsGroup2.Controls.Add(this.labelFollowerTargetGroup2Clear);
            this.groupBoxBardOptionsGroup2.Controls.Add(this.FollowerTargetGroup2);
            this.groupBoxBardOptionsGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBardOptionsGroup2.Location = new System.Drawing.Point(7, 90);
            this.groupBoxBardOptionsGroup2.Name = "groupBoxBardOptionsGroup2";
            this.groupBoxBardOptionsGroup2.Size = new System.Drawing.Size(226, 53);
            this.groupBoxBardOptionsGroup2.TabIndex = 13;
            this.groupBoxBardOptionsGroup2.TabStop = false;
            this.groupBoxBardOptionsGroup2.Text = " FOLLOW TARGET ";
            this.groupBoxBardOptionsGroup2.Enter += new System.EventHandler(this.groupBoxBardOptionsGroup2_Enter);
            // 
            // labelFollowerTargetGroup2Clear
            // 
            this.labelFollowerTargetGroup2Clear.AutoSize = true;
            this.labelFollowerTargetGroup2Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFollowerTargetGroup2Clear.Location = new System.Drawing.Point(201, 24);
            this.labelFollowerTargetGroup2Clear.Name = "labelFollowerTargetGroup2Clear";
            this.labelFollowerTargetGroup2Clear.Size = new System.Drawing.Size(15, 13);
            this.labelFollowerTargetGroup2Clear.TabIndex = 7;
            this.labelFollowerTargetGroup2Clear.Text = "X";
            this.labelFollowerTargetGroup2Clear.Click += new System.EventHandler(this.labelFollowerTargetGroup2Clear_Click);
            // 
            // FollowerTargetGroup2
            // 
            // 
            // 
            // 
            this.FollowerTargetGroup2.CustomButton.Image = null;
            this.FollowerTargetGroup2.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.FollowerTargetGroup2.CustomButton.Name = "";
            this.FollowerTargetGroup2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FollowerTargetGroup2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FollowerTargetGroup2.CustomButton.TabIndex = 1;
            this.FollowerTargetGroup2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FollowerTargetGroup2.CustomButton.UseSelectable = true;
            this.FollowerTargetGroup2.CustomButton.Visible = false;
            this.FollowerTargetGroup2.Lines = new string[] {
        "Follower target name."};
            this.FollowerTargetGroup2.Location = new System.Drawing.Point(6, 19);
            this.FollowerTargetGroup2.MaxLength = 32767;
            this.FollowerTargetGroup2.Name = "FollowerTargetGroup2";
            this.FollowerTargetGroup2.PasswordChar = '\0';
            this.FollowerTargetGroup2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FollowerTargetGroup2.SelectedText = "";
            this.FollowerTargetGroup2.SelectionLength = 0;
            this.FollowerTargetGroup2.SelectionStart = 0;
            this.FollowerTargetGroup2.ShortcutsEnabled = true;
            this.FollowerTargetGroup2.Size = new System.Drawing.Size(214, 23);
            this.FollowerTargetGroup2.TabIndex = 6;
            this.FollowerTargetGroup2.Text = "Follower target name.";
            this.FollowerTargetGroup2.UseSelectable = true;
            this.FollowerTargetGroup2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FollowerTargetGroup2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SongGroup2_Song1_ComboBox
            // 
            this.SongGroup2_Song1_ComboBox.FormattingEnabled = true;
            this.SongGroup2_Song1_ComboBox.ItemHeight = 23;
            this.SongGroup2_Song1_ComboBox.Location = new System.Drawing.Point(6, 19);
            this.SongGroup2_Song1_ComboBox.MaxDropDownItems = 5;
            this.SongGroup2_Song1_ComboBox.Name = "SongGroup2_Song1_ComboBox";
            this.SongGroup2_Song1_ComboBox.Size = new System.Drawing.Size(227, 29);
            this.SongGroup2_Song1_ComboBox.TabIndex = 1;
            this.SongGroup2_Song1_ComboBox.UseSelectable = true;
            // 
            // SongGroup2_Song2_ComboBox
            // 
            this.SongGroup2_Song2_ComboBox.FormattingEnabled = true;
            this.SongGroup2_Song2_ComboBox.ItemHeight = 23;
            this.SongGroup2_Song2_ComboBox.Location = new System.Drawing.Point(7, 55);
            this.SongGroup2_Song2_ComboBox.MaxDropDownItems = 5;
            this.SongGroup2_Song2_ComboBox.Name = "SongGroup2_Song2_ComboBox";
            this.SongGroup2_Song2_ComboBox.Size = new System.Drawing.Size(226, 29);
            this.SongGroup2_Song2_ComboBox.TabIndex = 2;
            this.SongGroup2_Song2_ComboBox.UseSelectable = true;
            // 
            // SongGroup2_Timer1_Label
            // 
            this.SongGroup2_Timer1_Label.Location = new System.Drawing.Point(238, 24);
            this.SongGroup2_Timer1_Label.Name = "SongGroup2_Timer1_Label";
            this.SongGroup2_Timer1_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup2_Timer1_Label.TabIndex = 3;
            this.SongGroup2_Timer1_Label.Text = "00:00";
            // 
            // SongGroup2_Timer2_Label
            // 
            this.SongGroup2_Timer2_Label.Location = new System.Drawing.Point(238, 60);
            this.SongGroup2_Timer2_Label.Name = "SongGroup2_Timer2_Label";
            this.SongGroup2_Timer2_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup2_Timer2_Label.TabIndex = 4;
            this.SongGroup2_Timer2_Label.Text = "00:00";
            // 
            // groupBoxPartyGroup2
            // 
            this.groupBoxPartyGroup2.Controls.Add(this.PartyMembersGroup2_ListBox);
            this.groupBoxPartyGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPartyGroup2.Location = new System.Drawing.Point(317, 307);
            this.groupBoxPartyGroup2.Name = "groupBoxPartyGroup2";
            this.groupBoxPartyGroup2.Size = new System.Drawing.Size(152, 160);
            this.groupBoxPartyGroup2.TabIndex = 12;
            this.groupBoxPartyGroup2.TabStop = false;
            this.groupBoxPartyGroup2.Text = " GROUP 2 TARGETS ";
            this.groupBoxPartyGroup2.Enter += new System.EventHandler(this.groupBoxPartyGroup2_Enter);
            // 
            // PartyMembersGroup2_ListBox
            // 
            this.PartyMembersGroup2_ListBox.FormattingEnabled = true;
            this.PartyMembersGroup2_ListBox.ItemHeight = 12;
            this.PartyMembersGroup2_ListBox.Location = new System.Drawing.Point(6, 17);
            this.PartyMembersGroup2_ListBox.Name = "PartyMembersGroup2_ListBox";
            this.PartyMembersGroup2_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PartyMembersGroup2_ListBox.Size = new System.Drawing.Size(136, 136);
            this.PartyMembersGroup2_ListBox.TabIndex = 0;
            this.PartyMembersGroup2_ListBox.SelectedValueChanged += new System.EventHandler(this.PartyMembersGroup2_ListBox_SelectedValueChanged);
            // 
            // ReloadParty
            // 
            this.ReloadParty.Location = new System.Drawing.Point(355, 505);
            this.ReloadParty.Name = "ReloadParty";
            this.ReloadParty.Size = new System.Drawing.Size(75, 23);
            this.ReloadParty.TabIndex = 1;
            this.ReloadParty.Text = "Reload";
            this.ReloadParty.UseVisualStyleBackColor = true;
            this.ReloadParty.Click += new System.EventHandler(this.ReloadParty_Click);
            // 
            // buttonToggleManualFollow
            // 
            this.buttonToggleManualFollow.Location = new System.Drawing.Point(317, 583);
            this.buttonToggleManualFollow.Name = "buttonToggleManualFollow";
            this.buttonToggleManualFollow.Size = new System.Drawing.Size(152, 37);
            this.buttonToggleManualFollow.TabIndex = 14;
            this.buttonToggleManualFollow.Text = "Follow Current Target";
            this.buttonToggleManualFollow.UseSelectable = true;
            this.buttonToggleManualFollow.Click += new System.EventHandler(this.buttonToggleManualFollow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 644);
            this.Controls.Add(this.ReloadParty);
            this.Controls.Add(this.buttonToggleManualFollow);
            this.Controls.Add(this.groupBoxPartyGroup2);
            this.Controls.Add(this.groupBoxSongGroup2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.DEBUG);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.ActivityButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Pocket Bard v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBoxSongGroup2.ResumeLayout(false);
            this.groupBoxSongGroup2.PerformLayout();
            this.groupBoxBardOptionsGroup2.ResumeLayout(false);
            this.groupBoxBardOptionsGroup2.PerformLayout();
            this.groupBoxPartyGroup2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ActivityButton;
        private MetroFramework.Controls.MetroComboBox SongGroup1_Song2_ComboBox;
        private MetroFramework.Controls.MetroComboBox SongGroup1_Song1_ComboBox;
        private System.Windows.Forms.Label SongGroup1_Timer1_Label;
        private System.Windows.Forms.Label SongGroup1_Timer2_Label;
        private MetroFramework.Controls.MetroComboBox POLID;
        private System.Windows.Forms.Button Select_POLID;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Timer Song_Timer;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private System.Windows.Forms.Button DEBUG;
        private System.Windows.Forms.ListBox PartyMembersGroup1_ListBox;
        private System.Windows.Forms.Button ReloadParty;
        private System.Windows.Forms.GroupBox groupBox8;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroToggle PauseOnZone_Switch;
        private System.Windows.Forms.Timer PauseTimersChecks;
        private System.Windows.Forms.GroupBox groupBoxSongGroup2;
        private MetroFramework.Controls.MetroComboBox SongGroup2_Song1_ComboBox;
        private MetroFramework.Controls.MetroComboBox SongGroup2_Song2_ComboBox;
        private System.Windows.Forms.Label SongGroup2_Timer1_Label;
        private System.Windows.Forms.Label SongGroup2_Timer2_Label;
        private System.Windows.Forms.GroupBox groupBoxPartyGroup2;
        private System.Windows.Forms.ListBox PartyMembersGroup2_ListBox;
        private System.Windows.Forms.GroupBox groupBoxBardOptionsGroup2;
        private MetroFramework.Controls.MetroTextBox FollowerTargetGroup2;
        private System.Windows.Forms.Label labelFollowerTargetGroup2Clear;
        private MetroFramework.Controls.MetroButton buttonToggleManualFollow;
        private MetroFramework.Controls.MetroToggle toggleGroup2Switch;
        private MetroFramework.Controls.MetroLabel labelSongDelay;
        private System.Windows.Forms.ComboBox comboBoxSongDelay; // Ensured this is the type
        private MetroFramework.Controls.MetroLabel labelBardRotationSwitch;
        private MetroFramework.Controls.MetroToggle toggleBardRotationSwitch;
        private MetroFramework.Controls.MetroLabel labelAutoJoin;
        private MetroFramework.Controls.MetroToggle toggleAutoJoinSwitch;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox FollowerTarget;
        private MetroFramework.Controls.MetroLabel labelSoulVoice;
        private MetroFramework.Controls.MetroToggle toggleSoulVoiceSwitch;
        private MetroFramework.Controls.MetroComboBox comboBoxLeavePartyCall;
        private MetroFramework.Controls.MetroComboBox comboBoxRotationStartCall;
        // NOTE: textBoxSongDelay field is INTENTIONALLY REMOVED from this list
    }
}
