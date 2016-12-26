namespace MP3Effects.WinForms
{
    partial class MainForm
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.InputPathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseInputFileButton = new System.Windows.Forms.Button();
            this.SemitonesLabel = new System.Windows.Forms.Label();
            this.SemitonesTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputPathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseOutputFileButton = new System.Windows.Forms.Button();
            this.ApplyEffectsButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SemitonesTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MP3 File";
            // 
            // InputPathTextBox
            // 
            this.InputPathTextBox.Location = new System.Drawing.Point(13, 30);
            this.InputPathTextBox.Name = "InputPathTextBox";
            this.InputPathTextBox.Size = new System.Drawing.Size(679, 20);
            this.InputPathTextBox.TabIndex = 1;
            // 
            // BrowseInputFileButton
            // 
            this.BrowseInputFileButton.Location = new System.Drawing.Point(698, 27);
            this.BrowseInputFileButton.Name = "BrowseInputFileButton";
            this.BrowseInputFileButton.Size = new System.Drawing.Size(78, 23);
            this.BrowseInputFileButton.TabIndex = 2;
            this.BrowseInputFileButton.Text = "Open";
            this.BrowseInputFileButton.UseVisualStyleBackColor = true;
            this.BrowseInputFileButton.Click += new System.EventHandler(this.BrowseInputFileButton_Click);
            // 
            // SemitonesLabel
            // 
            this.SemitonesLabel.AutoSize = true;
            this.SemitonesLabel.Location = new System.Drawing.Point(12, 112);
            this.SemitonesLabel.Name = "SemitonesLabel";
            this.SemitonesLabel.Size = new System.Drawing.Size(56, 13);
            this.SemitonesLabel.TabIndex = 3;
            this.SemitonesLabel.Text = "Semitones";
            // 
            // SemitonesTrackBar
            // 
            this.SemitonesTrackBar.LargeChange = 4;
            this.SemitonesTrackBar.Location = new System.Drawing.Point(13, 128);
            this.SemitonesTrackBar.Maximum = 12;
            this.SemitonesTrackBar.Minimum = -12;
            this.SemitonesTrackBar.Name = "SemitonesTrackBar";
            this.SemitonesTrackBar.Size = new System.Drawing.Size(679, 45);
            this.SemitonesTrackBar.TabIndex = 4;
            this.SemitonesTrackBar.Scroll += new System.EventHandler(this.SemitonesTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output MP3 File";
            // 
            // OutputPathTextBox
            // 
            this.OutputPathTextBox.Location = new System.Drawing.Point(12, 81);
            this.OutputPathTextBox.Name = "OutputPathTextBox";
            this.OutputPathTextBox.Size = new System.Drawing.Size(680, 20);
            this.OutputPathTextBox.TabIndex = 6;
            // 
            // BrowseOutputFileButton
            // 
            this.BrowseOutputFileButton.Location = new System.Drawing.Point(698, 78);
            this.BrowseOutputFileButton.Name = "BrowseOutputFileButton";
            this.BrowseOutputFileButton.Size = new System.Drawing.Size(78, 23);
            this.BrowseOutputFileButton.TabIndex = 7;
            this.BrowseOutputFileButton.Text = "Save As...";
            this.BrowseOutputFileButton.UseVisualStyleBackColor = true;
            this.BrowseOutputFileButton.Click += new System.EventHandler(this.BrowseOutputFileButton_Click);
            // 
            // ApplyEffectsButton
            // 
            this.ApplyEffectsButton.Location = new System.Drawing.Point(698, 207);
            this.ApplyEffectsButton.Name = "ApplyEffectsButton";
            this.ApplyEffectsButton.Size = new System.Drawing.Size(78, 23);
            this.ApplyEffectsButton.TabIndex = 8;
            this.ApplyEffectsButton.Text = "Apply Effects";
            this.ApplyEffectsButton.UseVisualStyleBackColor = true;
            this.ApplyEffectsButton.Click += new System.EventHandler(this.ApplyEffectsButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(16, 168);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(676, 23);
            this.ProgressBar.TabIndex = 9;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(16, 198);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(0, 13);
            this.ProgressLabel.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 242);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ApplyEffectsButton);
            this.Controls.Add(this.BrowseOutputFileButton);
            this.Controls.Add(this.OutputPathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SemitonesTrackBar);
            this.Controls.Add(this.SemitonesLabel);
            this.Controls.Add(this.BrowseInputFileButton);
            this.Controls.Add(this.InputPathTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MP3 Effects";
            ((System.ComponentModel.ISupportInitialize)(this.SemitonesTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputPathTextBox;
        private System.Windows.Forms.Button BrowseInputFileButton;
        private System.Windows.Forms.Label SemitonesLabel;
        private System.Windows.Forms.TrackBar SemitonesTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutputPathTextBox;
        private System.Windows.Forms.Button BrowseOutputFileButton;
        private System.Windows.Forms.Button ApplyEffectsButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label ProgressLabel;
    }
}

