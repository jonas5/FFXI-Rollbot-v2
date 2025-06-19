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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Select_POLID = new System.Windows.Forms.Button();
            this.POLID = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SongGroup1_Song1_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup1_Song2_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup1_Timer1_Label = new System.Windows.Forms.Label();
            this.SongGroup1_Timer2_Label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FollowerTarget = new MetroFramework.Controls.MetroTextBox();
            this.ActivityButton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ReloadParty = new System.Windows.Forms.Button();
            this.PartyMembersGroup1_ListBox = new System.Windows.Forms.ListBox();
            this.Song_Timer = new System.Windows.Forms.Timer(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.DEBUG = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.PauseOnZone_Switch = new MetroFramework.Controls.MetroToggle();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.PauseTimersChecks = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSongGroup2 = new System.Windows.Forms.GroupBox();
            this.SongGroup2_Song1_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup2_Song2_ComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SongGroup2_Timer1_Label = new System.Windows.Forms.Label();
            this.SongGroup2_Timer2_Label = new System.Windows.Forms.Label();
            this.groupBoxPartyGroup2 = new System.Windows.Forms.GroupBox();
            this.PartyMembersGroup2_ListBox = new System.Windows.Forms.ListBox();
            this.groupBoxBardOptionsGroup2 = new System.Windows.Forms.GroupBox();
            this.FollowerTargetGroup2 = new MetroFramework.Controls.MetroTextBox();
            this.labelFollowerTargetGroup2Clear = new System.Windows.Forms.Label();
            this.buttonToggleManualFollow = new MetroFramework.Controls.MetroButton(); // Added declaration
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBoxSongGroup2.SuspendLayout();
            this.groupBoxPartyGroup2.SuspendLayout();
            this.groupBoxBardOptionsGroup2.SuspendLayout();
            this.SuspendLayout();





            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.Select_POLID);
            this.groupBox1.Controls.Add(this.POLID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " SELECT PROCESS ";
            //
            // Select_POLID
            //
            this.Select_POLID.Location = new System.Drawing.Point(280, 15);
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
            this.POLID.Size = new System.Drawing.Size(266, 29);
            this.POLID.TabIndex = 2;
            this.POLID.UseSelectable = true;
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.SongGroup1_Song1_ComboBox);
            this.groupBox2.Controls.Add(this.SongGroup1_Song2_ComboBox);
            this.groupBox2.Controls.Add(this.SongGroup1_Timer1_Label);
            this.groupBox2.Controls.Add(this.SongGroup1_Timer2_Label);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 94);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " SONG GROUP 1 ";



            //
            // SongGroup1_Song1_ComboBox
            //
            this.SongGroup1_Song1_ComboBox.FormattingEnabled = true;
            this.SongGroup1_Song1_ComboBox.ItemHeight = 23;
            this.SongGroup1_Song1_ComboBox.Items.AddRange(new object[] {
            "Corsair\'s Roll ", "Ninja Roll ", "Hunter\'s Roll ", "Chaos Roll ", "Magus\'s Roll ", "Healer\'s Roll ", "Drachen Roll ", "Choral Roll ", "Monk\'s Roll ", "Beast Roll ", "Samurai Roll ", "Evoker\'s Roll ", "Rogue\'s Roll ", "Warlock\'s Roll ", "Fighter\'s Roll ", "Puppet Roll ", "Gallant\'s Roll ", "Wizard\'s Roll ", "Dancer\'s Roll ", "Scholar\'s Roll ", "Naturalist\'s Roll ", "Runeist\'s Roll ", "Bolter\'s Roll ", "Caster\'s Roll ", "Courser\'s Roll ", "Blitzer\'s Roll ", "Tactician\'s Roll ", "Allies\' Roll ", "Miser\'s Roll ", "Companion\'s Roll ", "Avenger\'s Roll "});
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
            this.SongGroup1_Song2_ComboBox.Items.AddRange(new object[] {
            "Corsair\'s Roll ", "Ninja Roll ", "Hunter\'s Roll ", "Chaos Roll ", "Magus\'s Roll ", "Healer\'s Roll ", "Drachen Roll ", "Choral Roll ", "Monk\'s Roll ", "Beast Roll ", "Samurai Roll ", "Evoker\'s Roll ", "Rogue\'s Roll ", "Warlock\'s Roll ", "Fighter\'s Roll ", "Puppet Roll ", "Gallant\'s Roll ", "Wizard\'s Roll ", "Dancer\'s Roll ", "Scholar\'s Roll ", "Naturalist\'s Roll ", "Runeist\'s Roll ", "Bolter\'s Roll ", "Caster\'s Roll ", "Courser\'s Roll ", "Blitzer\'s Roll ", "Tactician\'s Roll ", "Allies\' Roll ", "Miser\'s Roll ", "Companion\'s Roll ", "Avenger\'s Roll "});
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
            // groupBox3
            //
            this.labelSoulVoice = new MetroFramework.Controls.MetroLabel();
            this.toggleSoulVoiceSwitch = new MetroFramework.Controls.MetroToggle();

            this.groupBox3.Controls.Add(this.labelSoulVoice);
            this.groupBox3.Controls.Add(this.toggleSoulVoiceSwitch);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 80); // Increased width
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " BARD OPTIONS (Group 1) ";
            //
            // groupBox7
            //
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.FollowerTarget);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(6, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(163, 54);
            this.groupBox7.TabIndex = 0; // First control in this group box

            //
            // labelSoulVoice
            //
            this.labelSoulVoice.AutoSize = true;
            this.labelSoulVoice.Location = new System.Drawing.Point(175, 22); // Positioned to the right of groupBox7
            this.labelSoulVoice.Name = "labelSoulVoice";
            this.labelSoulVoice.Size = new System.Drawing.Size(100, 19);
            this.labelSoulVoice.TabIndex = 1; // Next control
            this.labelSoulVoice.Text = "Soul Voice Next:";
            //
            // toggleSoulVoiceSwitch
            //
            this.toggleSoulVoiceSwitch.AutoSize = true;
            this.toggleSoulVoiceSwitch.Location = new System.Drawing.Point(185, 45); // Below labelSoulVoice
            this.toggleSoulVoiceSwitch.Name = "toggleSoulVoiceSwitch";
            this.toggleSoulVoiceSwitch.Size = new System.Drawing.Size(80, 17);
            this.toggleSoulVoiceSwitch.TabIndex = 2; // Next control
            this.toggleSoulVoiceSwitch.Text = "Off";
            this.toggleSoulVoiceSwitch.UseSelectable = true;
            this.toggleSoulVoiceSwitch.Checked = false; // Default to off
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " FOLLOW TARGET ";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            //
            // FollowerTarget
            //
            this.FollowerTarget.CustomButton.Image = null;
            this.FollowerTarget.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.FollowerTarget.CustomButton.Name = "";
            this.FollowerTarget.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FollowerTarget.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FollowerTarget.CustomButton.TabIndex = 1;
            this.FollowerTarget.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FollowerTarget.CustomButton.UseSelectable = true;
            this.FollowerTarget.CustomButton.Visible = false;
            this.FollowerTarget.Lines = new string[] { "Follower target name." };
            this.FollowerTarget.Location = new System.Drawing.Point(6, 19);
            this.FollowerTarget.MaxLength = 32767;
            this.FollowerTarget.Name = "FollowerTarget";
            this.FollowerTarget.PasswordChar = '\0';
            this.FollowerTarget.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FollowerTarget.SelectedText = "";
            this.FollowerTarget.SelectionLength = 0;
            this.FollowerTarget.SelectionStart = 0;
            this.FollowerTarget.ShortcutsEnabled = true;
            this.FollowerTarget.Size = new System.Drawing.Size(151, 23);
            this.FollowerTarget.TabIndex = 6;
            this.FollowerTarget.Text = "Follower target name.";
            this.FollowerTarget.UseSelectable = true;
            this.FollowerTarget.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FollowerTarget.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            //
            // groupBoxSongGroup2
            //
            // toggleGroup2Switch
            // NOTE: This control is added first to the groupbox for TabIndex reasons.
            this.toggleGroup2Switch = new MetroFramework.Controls.MetroToggle();
            this.toggleGroup2Switch.AutoSize = true;
            this.toggleGroup2Switch.Location = new System.Drawing.Point(150, 0); // Adjusted X, Y to be near the title, within the groupbox
            this.toggleGroup2Switch.Name = "toggleGroup2Switch";
            this.toggleGroup2Switch.Size = new System.Drawing.Size(80, 17);
            this.toggleGroup2Switch.TabIndex = 0; // First control in this group
            this.toggleGroup2Switch.Text = "Off"; // Will show "On"/"Off"
            this.toggleGroup2Switch.UseSelectable = true;
            this.toggleGroup2Switch.Checked = true; // Default to enabled
            this.toggleGroup2Switch.CheckedChanged += new System.EventHandler(this.toggleGroup2Switch_CheckedChanged);

            this.groupBoxSongGroup2.Controls.Add(this.toggleGroup2Switch); // Add toggle first
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Song1_ComboBox);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Song2_ComboBox);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Timer1_Label);
            this.groupBoxSongGroup2.Controls.Add(this.SongGroup2_Timer2_Label);
            this.groupBoxSongGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSongGroup2.Location = new System.Drawing.Point(11, 310);
            this.groupBoxSongGroup2.Name = "groupBoxSongGroup2";
            this.groupBoxSongGroup2.Size = new System.Drawing.Size(300, 94);
            this.groupBoxSongGroup2.TabIndex = 11;
            this.groupBoxSongGroup2.TabStop = false;
            this.groupBoxSongGroup2.Text = " SONG GROUP 2 ";
            //
            // SongGroup2_Song1_ComboBox
            //
            this.SongGroup2_Song1_ComboBox.FormattingEnabled = true;
            this.SongGroup2_Song1_ComboBox.ItemHeight = 23;
            this.SongGroup2_Song1_ComboBox.Location = new System.Drawing.Point(6, 19);
            this.SongGroup2_Song1_ComboBox.MaxDropDownItems = 5;
            this.SongGroup2_Song1_ComboBox.Name = "SongGroup2_Song1_ComboBox";
            this.SongGroup2_Song1_ComboBox.Size = new System.Drawing.Size(227, 29);
            this.SongGroup2_Song1_ComboBox.TabIndex = 1; // Adjusted TabIndex
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
            this.SongGroup2_Song2_ComboBox.TabIndex = 2; // Adjusted TabIndex
            this.SongGroup2_Song2_ComboBox.UseSelectable = true;
            //
            // SongGroup2_Timer1_Label
            //
            this.SongGroup2_Timer1_Label.Location = new System.Drawing.Point(238, 24);
            this.SongGroup2_Timer1_Label.Name = "SongGroup2_Timer1_Label";
            this.SongGroup2_Timer1_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup2_Timer1_Label.TabIndex = 3; // Adjusted TabIndex
            this.SongGroup2_Timer1_Label.Text = "00:00";
            //
            // SongGroup2_Timer2_Label
            //
            this.SongGroup2_Timer2_Label.Location = new System.Drawing.Point(238, 60);
            this.SongGroup2_Timer2_Label.Name = "SongGroup2_Timer2_Label";
            this.SongGroup2_Timer2_Label.Size = new System.Drawing.Size(50, 23);
            this.SongGroup2_Timer2_Label.TabIndex = 4; // Adjusted TabIndex
            this.SongGroup2_Timer2_Label.Text = "00:00";
            //
            // groupBoxPartyGroup2
            //
            
            this.groupBoxPartyGroup2.Controls.Add(this.ReloadParty);
            this.groupBoxPartyGroup2.Controls.Add(this.PartyMembersGroup2_ListBox);
            this.groupBoxPartyGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPartyGroup2.Location = new System.Drawing.Point(317, 280);
            this.groupBoxPartyGroup2.Name = "groupBoxPartyGroup2";
            this.groupBoxPartyGroup2.Size = new System.Drawing.Size(152, 210);
            this.groupBoxPartyGroup2.TabIndex = 12;
            this.groupBoxPartyGroup2.TabStop = false;
            this.groupBoxPartyGroup2.Text = " GROUP 2 TARGETS ";
            //
            // PartyMembersGroup2_ListBox
            //
            this.PartyMembersGroup2_ListBox.FormattingEnabled = true;
            this.PartyMembersGroup2_ListBox.ItemHeight = 12;
            this.PartyMembersGroup2_ListBox.Location = new System.Drawing.Point(6, 19);
            this.PartyMembersGroup2_ListBox.Name = "PartyMembersGroup2_ListBox";
            this.PartyMembersGroup2_ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.PartyMembersGroup2_ListBox.Size = new System.Drawing.Size(136, 148);
            this.PartyMembersGroup2_ListBox.TabIndex = 0;
            this.PartyMembersGroup2_ListBox.SelectedValueChanged += new System.EventHandler(this.PartyMembersGroup2_ListBox_SelectedValueChanged);




            //
            // groupBox6
            //
            this.groupBox6.Controls.Add(this.PartyMembersGroup1_ListBox);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(317, 124);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(152, 210);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " GROUP 1 TARGETS ";


            //
            // ReloadParty
            //
            // THEN, define ReloadParty and its properties
            this.ReloadParty.Location = new System.Drawing.Point(37, 180);
            this.ReloadParty.Name = "ReloadParty";
            this.ReloadParty.Size = new System.Drawing.Size(75, 23);
            this.ReloadParty.TabIndex = 1;
            this.ReloadParty.Text = "reload";
            this.ReloadParty.UseVisualStyleBackColor = true;
            this.ReloadParty.Click += new System.EventHandler(this.ReloadParty_Click);
            
                        
            //
            // ActivityButton
            //
            this.ActivityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivityButton.Location = new System.Drawing.Point(245, 540);
            this.ActivityButton.Name = "ActivityButton";
            this.ActivityButton.Size = new System.Drawing.Size(163, 43);
            this.ActivityButton.TabIndex = 6;
            this.ActivityButton.Text = "START";
            this.ActivityButton.UseVisualStyleBackColor = true;
            this.ActivityButton.Click += new System.EventHandler(this.ActivityButton_Click);


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
            this.DEBUG.Location = new System.Drawing.Point(333, 34);
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
            this.labelSongDelay = new MetroFramework.Controls.MetroLabel();
            this.textBoxSongDelay = new MetroFramework.Controls.MetroTextBox();

            this.groupBox8.Controls.Add(this.labelSongDelay);
            this.labelBardRotationSwitch = new MetroFramework.Controls.MetroLabel();
            this.toggleBardRotationSwitch = new MetroFramework.Controls.MetroToggle();

            this.groupBox8.Controls.Add(this.labelBardRotationSwitch);
            this.groupBox8.Controls.Add(this.toggleBardRotationSwitch);
            this.groupBox8.Controls.Add(this.labelSongDelay);
            this.groupBox8.Controls.Add(this.textBoxSongDelay);
            this.groupBox8.Controls.Add(this.metroLabel5);
            this.groupBox8.Controls.Add(this.PauseOnZone_Switch);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(11, 496);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(233, 100); // Further increased height
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " PROGRAM OPTIONS ";
            //
            // PauseOnZone_Switch
            //
            this.PauseOnZone_Switch.AutoSize = true;
            this.PauseOnZone_Switch.DisplayStatus = false;
            this.PauseOnZone_Switch.Location = new System.Drawing.Point(122, 13);
            this.PauseOnZone_Switch.Name = "PauseOnZone_Switch";
            this.PauseOnZone_Switch.Size = new System.Drawing.Size(50, 16);
            this.PauseOnZone_Switch.TabIndex = 0; // Original TabIndex
            this.PauseOnZone_Switch.Text = "Off";
            this.PauseOnZone_Switch.UseSelectable = true;
            //
            // metroLabel5
            //
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(6, 13);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(95, 19);
            this.metroLabel5.TabIndex = 1; // Original TabIndex
            this.metroLabel5.Text = "Pause on Zone";

            //
            // labelSongDelay
            //
            this.labelSongDelay.AutoSize = true;
            this.labelSongDelay.Location = new System.Drawing.Point(6, 40); // Placed on a new line
            this.labelSongDelay.Name = "labelSongDelay";
            this.labelSongDelay.TabIndex = 2; // Next TabIndex
            this.labelSongDelay.Text = "Song Delay (s):";
            //
            // textBoxSongDelay
            //
            this.textBoxSongDelay.CustomButton.Image = null;
            this.textBoxSongDelay.CustomButton.Location = new System.Drawing.Point(28, 1);
            this.textBoxSongDelay.CustomButton.Name = "";
            this.textBoxSongDelay.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxSongDelay.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxSongDelay.CustomButton.TabIndex = 1;
            this.textBoxSongDelay.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxSongDelay.CustomButton.UseSelectable = true;
            this.textBoxSongDelay.CustomButton.Visible = false;
            this.textBoxSongDelay.Lines = new string[] { "1" };
            this.textBoxSongDelay.Location = new System.Drawing.Point(122, 40); // Next to labelSongDelay
            this.textBoxSongDelay.MaxLength = 3;
            this.textBoxSongDelay.Name = "textBoxSongDelay";
            this.textBoxSongDelay.PasswordChar = '\0';
            this.textBoxSongDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxSongDelay.SelectedText = "";
            this.textBoxSongDelay.SelectionLength = 0;
            this.textBoxSongDelay.SelectionStart = 0;
            this.textBoxSongDelay.ShortcutsEnabled = true;
            this.textBoxSongDelay.Size = new System.Drawing.Size(50, 23);
            this.textBoxSongDelay.TabIndex = 3; // Original TabIndex for this row
            this.textBoxSongDelay.Text = "1";
            this.textBoxSongDelay.UseSelectable = true;
            this.textBoxSongDelay.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxSongDelay.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxSongDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSongDelay_KeyPress);
            //
            // labelBardRotationSwitch
            //
            this.labelBardRotationSwitch.AutoSize = true;
            this.labelBardRotationSwitch.Location = new System.Drawing.Point(6, 67); // New row
            this.labelBardRotationSwitch.Name = "labelBardRotationSwitch";
            this.labelBardRotationSwitch.TabIndex = 4; // Next TabIndex
            this.labelBardRotationSwitch.Text = "Bard Rotation:";
            //
            // toggleBardRotationSwitch
            //
            this.toggleBardRotationSwitch.AutoSize = true;
            this.toggleBardRotationSwitch.Location = new System.Drawing.Point(122, 67); // Next to labelBardRotationSwitch
            this.toggleBardRotationSwitch.Name = "toggleBardRotationSwitch";
            this.toggleBardRotationSwitch.Size = new System.Drawing.Size(80, 17);
            this.toggleBardRotationSwitch.TabIndex = 5; // Next TabIndex
            this.toggleBardRotationSwitch.Text = "Off";
            this.toggleBardRotationSwitch.UseSelectable = true;
            this.toggleBardRotationSwitch.Checked = false;
            this.toggleBardRotationSwitch.CheckedChanged += new System.EventHandler(this.toggleBardRotationSwitch_CheckedChanged);
            //
            // PauseTimersChecks
            //
            this.PauseTimersChecks.Enabled = true;
            this.PauseTimersChecks.Interval = 500;
            this.PauseTimersChecks.Tick += new System.EventHandler(this.PauseTimersChecks_Tick);
            //
            // groupBoxBardOptionsGroup2
            //
            this.groupBoxBardOptionsGroup2.Controls.Add(this.labelFollowerTargetGroup2Clear);
            this.groupBoxBardOptionsGroup2.Controls.Add(this.FollowerTargetGroup2);
            this.groupBoxBardOptionsGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBardOptionsGroup2.Location = new System.Drawing.Point(11, 410);
            this.groupBoxBardOptionsGroup2.Name = "groupBoxBardOptionsGroup2";
            this.groupBoxBardOptionsGroup2.Size = new System.Drawing.Size(239, 80);
            this.groupBoxBardOptionsGroup2.TabIndex = 13;
            this.groupBoxBardOptionsGroup2.TabStop = false;
            this.groupBoxBardOptionsGroup2.Text = " FOLLOW TARGET (Group 2) ";
            //
            // FollowerTargetGroup2
            //
            this.FollowerTargetGroup2.CustomButton.Image = null;
            this.FollowerTargetGroup2.CustomButton.Location = new System.Drawing.Point(129, 1);
            this.FollowerTargetGroup2.CustomButton.Name = "";
            this.FollowerTargetGroup2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.FollowerTargetGroup2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FollowerTargetGroup2.CustomButton.TabIndex = 1;
            this.FollowerTargetGroup2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FollowerTargetGroup2.CustomButton.UseSelectable = true;
            this.FollowerTargetGroup2.CustomButton.Visible = false;
            this.FollowerTargetGroup2.Lines = new string[] { "Follower target G2 name." };
            this.FollowerTargetGroup2.Location = new System.Drawing.Point(6, 19);
            this.FollowerTargetGroup2.MaxLength = 32767;
            this.FollowerTargetGroup2.Name = "FollowerTargetGroup2";
            this.FollowerTargetGroup2.PasswordChar = '\0';
            this.FollowerTargetGroup2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.FollowerTargetGroup2.SelectedText = "";
            this.FollowerTargetGroup2.SelectionLength = 0;
            this.FollowerTargetGroup2.SelectionStart = 0;
            this.FollowerTargetGroup2.ShortcutsEnabled = true;
            this.FollowerTargetGroup2.Size = new System.Drawing.Size(151, 23);
            this.FollowerTargetGroup2.TabIndex = 6;
            this.FollowerTargetGroup2.Text = "Follower target G2 name.";
            this.FollowerTargetGroup2.UseSelectable = true;
            this.FollowerTargetGroup2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.FollowerTargetGroup2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            //
            // labelFollowerTargetGroup2Clear
            //
            this.labelFollowerTargetGroup2Clear.AutoSize = true;
            this.labelFollowerTargetGroup2Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFollowerTargetGroup2Clear.Location = new System.Drawing.Point(160, 24); // Adjusted location
            this.labelFollowerTargetGroup2Clear.Name = "labelFollowerTargetGroup2Clear";
            this.labelFollowerTargetGroup2Clear.Size = new System.Drawing.Size(15, 13);
            this.labelFollowerTargetGroup2Clear.TabIndex = 7;
            this.labelFollowerTargetGroup2Clear.Text = "X";
            this.labelFollowerTargetGroup2Clear.Click += new System.EventHandler(this.labelFollowerTargetGroup2Clear_Click);
            // 
            // buttonToggleManualFollow
            // 
            this.buttonToggleManualFollow.Location = new System.Drawing.Point(245, 589);
            this.buttonToggleManualFollow.Name = "buttonToggleManualFollow";
            this.buttonToggleManualFollow.Size = new System.Drawing.Size(163, 35);
            this.buttonToggleManualFollow.TabIndex = 14; // Assuming 13 was last used by groupBoxBardOptionsGroup2
            this.buttonToggleManualFollow.Text = "Follow Current Target";
            this.buttonToggleManualFollow.UseSelectable = true;
            this.buttonToggleManualFollow.Click += new System.EventHandler(this.buttonToggleManualFollow_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 644); // Adjusted ClientSize
            this.Controls.Add(this.buttonToggleManualFollow); // Added control
            this.Controls.Add(this.groupBoxBardOptionsGroup2);
            this.Controls.Add(this.groupBoxPartyGroup2);
            this.Controls.Add(this.groupBoxSongGroup2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.DEBUG);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.ActivityButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Corsair Roll Bot v2.0.4"; // This will be changed by Form1.cs
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBoxSongGroup2.ResumeLayout(false);
            this.groupBoxPartyGroup2.ResumeLayout(false);
            this.groupBoxBardOptionsGroup2.ResumeLayout(false);
            this.groupBoxBardOptionsGroup2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private MetroFramework.Controls.MetroTextBox FollowerTarget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBoxBardOptionsGroup2;
        private MetroFramework.Controls.MetroTextBox FollowerTargetGroup2;
        private System.Windows.Forms.Label labelFollowerTargetGroup2Clear;
        private MetroFramework.Controls.MetroButton buttonToggleManualFollow;
        private MetroFramework.Controls.MetroToggle toggleGroup2Switch;
        private MetroFramework.Controls.MetroLabel labelSongDelay;
        private MetroFramework.Controls.MetroTextBox textBoxSongDelay;
        private MetroFramework.Controls.MetroToggle toggleSoulVoiceSwitch;
        private MetroFramework.Controls.MetroLabel labelSoulVoice;
        private MetroFramework.Controls.MetroLabel labelBardRotationSwitch;
        private MetroFramework.Controls.MetroToggle toggleBardRotationSwitch;
    }
}
