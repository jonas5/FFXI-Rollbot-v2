namespace BardSongTracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600); // Increased height to accommodate controls
            this.Text = "Bard Song Tracker";

            // Group 1 Controls
            this.group1ControlsContainer = new System.Windows.Forms.GroupBox();
            this.group1Label = new System.Windows.Forms.Label();
            this.song1AComboBox = new System.Windows.Forms.ComboBox();
            this.song1BComboBox = new System.Windows.Forms.ComboBox();
            this.partyGroup1ListBox = new System.Windows.Forms.ListBox();
            this.timer1ALabel = new System.Windows.Forms.Label();
            this.timer1BLabel = new System.Windows.Forms.Label();

            // Group 2 Controls
            this.group2ControlsContainer = new System.Windows.Forms.GroupBox();
            this.group2Label = new System.Windows.Forms.Label();
            this.song2AComboBox = new System.Windows.Forms.ComboBox();
            this.song2BComboBox = new System.Windows.Forms.ComboBox();
            this.partyGroup2ListBox = new System.Windows.Forms.ListBox();
            this.timer2ALabel = new System.Windows.Forms.Label();
            this.timer2BLabel = new System.Windows.Forms.Label();

            // General Controls
            this.startStopButton = new System.Windows.Forms.Button();

            // SuspendLayout for performance
            this.SuspendLayout();
            this.group1ControlsContainer.SuspendLayout();
            this.group2ControlsContainer.SuspendLayout();

            // Configure Group 1 Controls
            this.group1ControlsContainer.Controls.Add(this.group1Label);
            this.group1ControlsContainer.Controls.Add(this.song1AComboBox);
            this.group1ControlsContainer.Controls.Add(this.song1BComboBox);
            this.group1ControlsContainer.Controls.Add(this.partyGroup1ListBox);
            this.group1ControlsContainer.Controls.Add(this.timer1ALabel);
            this.group1ControlsContainer.Controls.Add(this.timer1BLabel);
            this.group1ControlsContainer.Location = new System.Drawing.Point(12, 12);
            this.group1ControlsContainer.Name = "group1ControlsContainer";
            this.group1ControlsContainer.Size = new System.Drawing.Size(380, 250);
            this.group1ControlsContainer.TabIndex = 0;
            this.group1ControlsContainer.TabStop = false;
            this.group1ControlsContainer.Text = "Group 1";

            this.group1Label.AutoSize = true;
            this.group1Label.Location = new System.Drawing.Point(6, 19);
            this.group1Label.Name = "group1Label";
            this.group1Label.Size = new System.Drawing.Size(76, 15);
            this.group1Label.TabIndex = 0;
            this.group1Label.Text = "Party Group 1";

            this.song1AComboBox.FormattingEnabled = true;
            this.song1AComboBox.Location = new System.Drawing.Point(9, 37);
            this.song1AComboBox.Name = "song1AComboBox";
            this.song1AComboBox.Size = new System.Drawing.Size(121, 23);
            this.song1AComboBox.TabIndex = 1;

            this.timer1ALabel.AutoSize = true;
            this.timer1ALabel.Location = new System.Drawing.Point(136, 40);
            this.timer1ALabel.Name = "timer1ALabel";
            this.timer1ALabel.Size = new System.Drawing.Size(49, 15);
            this.timer1ALabel.TabIndex = 2;
            this.timer1ALabel.Text = "00:00";

            this.song1BComboBox.FormattingEnabled = true;
            this.song1BComboBox.Location = new System.Drawing.Point(9, 66);
            this.song1BComboBox.Name = "song1BComboBox";
            this.song1BComboBox.Size = new System.Drawing.Size(121, 23);
            this.song1BComboBox.TabIndex = 3;

            this.timer1BLabel.AutoSize = true;
            this.timer1BLabel.Location = new System.Drawing.Point(136, 69);
            this.timer1BLabel.Name = "timer1BLabel";
            this.timer1BLabel.Size = new System.Drawing.Size(49, 15);
            this.timer1BLabel.TabIndex = 4;
            this.timer1BLabel.Text = "00:00";

            this.partyGroup1ListBox.FormattingEnabled = true;
            this.partyGroup1ListBox.ItemHeight = 15;
            this.partyGroup1ListBox.Location = new System.Drawing.Point(9, 95);
            this.partyGroup1ListBox.Name = "partyGroup1ListBox";
            this.partyGroup1ListBox.Size = new System.Drawing.Size(177, 139);
            this.partyGroup1ListBox.TabIndex = 5;
            this.partyGroup1ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;

            // Configure Group 2 Controls
            this.group2ControlsContainer.Controls.Add(this.group2Label);
            this.group2ControlsContainer.Controls.Add(this.song2AComboBox);
            this.group2ControlsContainer.Controls.Add(this.song2BComboBox);
            this.group2ControlsContainer.Controls.Add(this.partyGroup2ListBox);
            this.group2ControlsContainer.Controls.Add(this.timer2ALabel);
            this.group2ControlsContainer.Controls.Add(this.timer2BLabel);
            this.group2ControlsContainer.Location = new System.Drawing.Point(408, 12);
            this.group2ControlsContainer.Name = "group2ControlsContainer";
            this.group2ControlsContainer.Size = new System.Drawing.Size(380, 250);
            this.group2ControlsContainer.TabIndex = 1;
            this.group2ControlsContainer.TabStop = false;
            this.group2ControlsContainer.Text = "Group 2";

            this.group2Label.AutoSize = true;
            this.group2Label.Location = new System.Drawing.Point(6, 19);
            this.group2Label.Name = "group2Label";
            this.group2Label.Size = new System.Drawing.Size(76, 15);
            this.group2Label.TabIndex = 0;
            this.group2Label.Text = "Party Group 2";

            this.song2AComboBox.FormattingEnabled = true;
            this.song2AComboBox.Location = new System.Drawing.Point(9, 37);
            this.song2AComboBox.Name = "song2AComboBox";
            this.song2AComboBox.Size = new System.Drawing.Size(121, 23);
            this.song2AComboBox.TabIndex = 1;

            this.timer2ALabel.AutoSize = true;
            this.timer2ALabel.Location = new System.Drawing.Point(136, 40);
            this.timer2ALabel.Name = "timer2ALabel";
            this.timer2ALabel.Size = new System.Drawing.Size(49, 15);
            this.timer2ALabel.TabIndex = 2;
            this.timer2ALabel.Text = "00:00";

            this.song2BComboBox.FormattingEnabled = true;
            this.song2BComboBox.Location = new System.Drawing.Point(9, 66);
            this.song2BComboBox.Name = "song2BComboBox";
            this.song2BComboBox.Size = new System.Drawing.Size(121, 23);
            this.song2BComboBox.TabIndex = 3;

            this.timer2BLabel.AutoSize = true;
            this.timer2BLabel.Location = new System.Drawing.Point(136, 69);
            this.timer2BLabel.Name = "timer2BLabel";
            this.timer2BLabel.Size = new System.Drawing.Size(49, 15);
            this.timer2BLabel.TabIndex = 4;
            this.timer2BLabel.Text = "00:00";

            this.partyGroup2ListBox.FormattingEnabled = true;
            this.partyGroup2ListBox.ItemHeight = 15;
            this.partyGroup2ListBox.Location = new System.Drawing.Point(9, 95);
            this.partyGroup2ListBox.Name = "partyGroup2ListBox";
            this.partyGroup2ListBox.Size = new System.Drawing.Size(177, 139);
            this.partyGroup2ListBox.TabIndex = 5;
            this.partyGroup2ListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;

            // Configure Add Party Member Controls
            this.addPartyMemberLabel = new System.Windows.Forms.Label();
            this.addPartyMemberLabel.AutoSize = true;
            this.addPartyMemberLabel.Location = new System.Drawing.Point(12, 270);
            this.addPartyMemberLabel.Name = "addPartyMemberLabel";
            this.addPartyMemberLabel.Size = new System.Drawing.Size(78, 15);
            this.addPartyMemberLabel.TabIndex = 3;
            this.addPartyMemberLabel.Text = "New Member:";

            this.partyMemberNameTextBox = new System.Windows.Forms.TextBox();
            this.partyMemberNameTextBox.Location = new System.Drawing.Point(96, 267);
            this.partyMemberNameTextBox.Name = "partyMemberNameTextBox";
            this.partyMemberNameTextBox.Size = new System.Drawing.Size(130, 23);
            this.partyMemberNameTextBox.TabIndex = 4;

            this.addPartyMemberButton = new System.Windows.Forms.Button();
            this.addPartyMemberButton.Location = new System.Drawing.Point(232, 266);
            this.addPartyMemberButton.Name = "addPartyMemberButton";
            this.addPartyMemberButton.Size = new System.Drawing.Size(80, 25);
            this.addPartyMemberButton.TabIndex = 5;
            this.addPartyMemberButton.Text = "Add to Lists";
            this.addPartyMemberButton.UseVisualStyleBackColor = true;

            // Configure Game Integration Controls
            // Process Label
            this.processLabel = new System.Windows.Forms.Label();
            this.processLabel.AutoSize = true;
            this.processLabel.Location = new System.Drawing.Point(12, 300); // Y below add member
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(84, 15); // Adjusted size for "Game Process:"
            this.processLabel.TabIndex = 8;
            this.processLabel.Text = "Game Process:";
            this.Controls.Add(this.processLabel);

            // Process ComboBox
            this.processComboBox = new System.Windows.Forms.ComboBox();
            this.processComboBox.FormattingEnabled = true;
            this.processComboBox.Location = new System.Drawing.Point(100, 297); // Adjusted X to align with label
            this.processComboBox.Name = "processComboBox";
            this.processComboBox.Size = new System.Drawing.Size(212, 23); // Adjusted width
            this.processComboBox.TabIndex = 9;
            this.Controls.Add(this.processComboBox);

            // Select Process Button
            this.selectProcessButton = new System.Windows.Forms.Button();
            this.selectProcessButton.Location = new System.Drawing.Point(318, 296);
            this.selectProcessButton.Name = "selectProcessButton";
            this.selectProcessButton.Size = new System.Drawing.Size(75, 25);
            this.selectProcessButton.TabIndex = 10;
            this.selectProcessButton.Text = "Connect";
            this.selectProcessButton.UseVisualStyleBackColor = true;
            this.Controls.Add(this.selectProcessButton);

            // Refresh Party Button
            this.refreshPartyButton = new System.Windows.Forms.Button();
            this.refreshPartyButton.Location = new System.Drawing.Point(399, 296);
            this.refreshPartyButton.Name = "refreshPartyButton";
            this.refreshPartyButton.Size = new System.Drawing.Size(100, 25);
            this.refreshPartyButton.TabIndex = 11;
            this.refreshPartyButton.Text = "Refresh Party";
            this.refreshPartyButton.UseVisualStyleBackColor = true;
            this.refreshPartyButton.Enabled = false; // Initial state
            this.Controls.Add(this.refreshPartyButton);

            // Follow Label
            this.followLabel = new System.Windows.Forms.Label();
            this.followLabel.AutoSize = true;
            this.followLabel.Location = new System.Drawing.Point(12, 330);
            this.followLabel.Name = "followLabel";
            this.followLabel.Size = new System.Drawing.Size(83, 15); // Adjusted size for "Follow Target:"
            this.followLabel.TabIndex = 12;
            this.followLabel.Text = "Follow Target:";
            this.Controls.Add(this.followLabel);

            // Follow Target TextBox
            this.followTargetTextBox = new System.Windows.Forms.TextBox();
            this.followTargetTextBox.Location = new System.Drawing.Point(100, 327); // Adjusted X
            this.followTargetTextBox.Name = "followTargetTextBox";
            this.followTargetTextBox.Size = new System.Drawing.Size(212, 23); // Adjusted width
            this.followTargetTextBox.TabIndex = 13;
            this.followTargetTextBox.Enabled = false; // Initial state
            this.Controls.Add(this.followTargetTextBox);

            // Set Follow Target Button
            this.setFollowTargetButton = new System.Windows.Forms.Button();
            this.setFollowTargetButton.Location = new System.Drawing.Point(318, 326);
            this.setFollowTargetButton.Name = "setFollowTargetButton";
            this.setFollowTargetButton.Size = new System.Drawing.Size(75, 25);
            this.setFollowTargetButton.TabIndex = 14;
            this.setFollowTargetButton.Text = "Follow";
            this.setFollowTargetButton.UseVisualStyleBackColor = true;
            this.setFollowTargetButton.Enabled = false; // Initial state
            this.Controls.Add(this.setFollowTargetButton);

            // Configure General Controls (adjust Y and TabIndex for Start/Stop and Run Tests)
            this.startStopButton.Location = new System.Drawing.Point(12, 360); // New Y, moved to left
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(100, 30);
            this.startStopButton.TabIndex = 15;
            this.startStopButton.Text = "Start/Stop All";
            this.startStopButton.UseVisualStyleBackColor = true;

            // Configure Run Tests Button
            this.runTestsButton.Location = new System.Drawing.Point(118, 360); // New Y, next to start/stop
            this.runTestsButton.Name = "runTestsButton";
            this.runTestsButton.Size = new System.Drawing.Size(100, 30);
            this.runTestsButton.TabIndex = 16;
            this.runTestsButton.Text = "Run Basic Tests";
            this.runTestsButton.UseVisualStyleBackColor = true;
            // this.Controls.Add(this.runTestsButton); // Already added

            // Adjust Form ClientSize if needed
            this.ClientSize = new System.Drawing.Size(800, 400); // Adjusted height

            // ResumeLayout
            this.group1ControlsContainer.ResumeLayout(false);
            this.group1ControlsContainer.PerformLayout();
            this.group2ControlsContainer.ResumeLayout(false);
            this.group2ControlsContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // New Controls
        private System.Windows.Forms.Label addPartyMemberLabel;
        private System.Windows.Forms.TextBox partyMemberNameTextBox;
        private System.Windows.Forms.Button addPartyMemberButton;
        private System.Windows.Forms.Button runTestsButton;

        // Game Integration Controls
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.ComboBox processComboBox;
        private System.Windows.Forms.Button selectProcessButton;
        private System.Windows.Forms.Button refreshPartyButton;
        private System.Windows.Forms.Label followLabel;
        private System.Windows.Forms.TextBox followTargetTextBox;
        private System.Windows.Forms.Button setFollowTargetButton;

        private System.Windows.Forms.GroupBox group1ControlsContainer;
        private System.Windows.Forms.Label group1Label;
        private System.Windows.Forms.ComboBox song1AComboBox;
        private System.Windows.Forms.ComboBox song1BComboBox;
        private System.Windows.Forms.ListBox partyGroup1ListBox;
        private System.Windows.Forms.Label timer1ALabel;
        private System.Windows.Forms.Label timer1BLabel;
        private System.Windows.Forms.GroupBox group2ControlsContainer;
        private System.Windows.Forms.Label group2Label;
        private System.Windows.Forms.ComboBox song2AComboBox;
        private System.Windows.Forms.ComboBox song2BComboBox;
        private System.Windows.Forms.ListBox partyGroup2ListBox;
        private System.Windows.Forms.Label timer2ALabel;
        private System.Windows.Forms.Label timer2BLabel;
        private System.Windows.Forms.Button startStopButton;
    }
}
