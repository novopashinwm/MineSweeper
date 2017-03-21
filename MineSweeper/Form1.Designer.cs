namespace MineSweeper
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameNew = new System.Windows.Forms.ToolStripMenuItem();
            this.strip1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGameBeginer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameMiddle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameProfi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGameUser = new System.Windows.Forms.ToolStripMenuItem();
            this.strip2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGameExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFlagCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(469, 233);
            this.panel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuGame
            // 
            this.mnuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGameNew,
            this.strip1,
            this.mnuGameBeginer,
            this.mnuGameMiddle,
            this.mnuGameProfi,
            this.mnuGameUser,
            this.strip2,
            this.mnuGameExit});
            this.mnuGame.Name = "mnuGame";
            this.mnuGame.Size = new System.Drawing.Size(46, 20);
            this.mnuGame.Text = "Игра";
            // 
            // mnuGameNew
            // 
            this.mnuGameNew.Name = "mnuGameNew";
            this.mnuGameNew.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuGameNew.Size = new System.Drawing.Size(158, 22);
            this.mnuGameNew.Text = "Новая игра";
            this.mnuGameNew.Click += new System.EventHandler(this.mnuGameNew_Click);
            // 
            // strip1
            // 
            this.strip1.Name = "strip1";
            this.strip1.Size = new System.Drawing.Size(155, 6);
            // 
            // mnuGameBeginer
            // 
            this.mnuGameBeginer.Name = "mnuGameBeginer";
            this.mnuGameBeginer.Size = new System.Drawing.Size(158, 22);
            this.mnuGameBeginer.Text = "Новичек";
            this.mnuGameBeginer.Click += new System.EventHandler(this.mnuGameBeginer_Click);
            // 
            // mnuGameMiddle
            // 
            this.mnuGameMiddle.Name = "mnuGameMiddle";
            this.mnuGameMiddle.Size = new System.Drawing.Size(158, 22);
            this.mnuGameMiddle.Text = "Любитель";
            this.mnuGameMiddle.Click += new System.EventHandler(this.mnuGameMiddle_Click);
            // 
            // mnuGameProfi
            // 
            this.mnuGameProfi.Name = "mnuGameProfi";
            this.mnuGameProfi.Size = new System.Drawing.Size(158, 22);
            this.mnuGameProfi.Text = "Профессионал";
            this.mnuGameProfi.Click += new System.EventHandler(this.mnuGameProfi_Click);
            // 
            // mnuGameUser
            // 
            this.mnuGameUser.Name = "mnuGameUser";
            this.mnuGameUser.Size = new System.Drawing.Size(158, 22);
            this.mnuGameUser.Text = "Особые ...";
            this.mnuGameUser.Click += new System.EventHandler(this.mnuGameUser_Click);
            // 
            // strip2
            // 
            this.strip2.Name = "strip2";
            this.strip2.Size = new System.Drawing.Size(155, 6);
            // 
            // mnuGameExit
            // 
            this.mnuGameExit.Name = "mnuGameExit";
            this.mnuGameExit.Size = new System.Drawing.Size(158, 22);
            this.mnuGameExit.Text = "Выход";
            this.mnuGameExit.Click += new System.EventHandler(this.mnuGameExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotal,
            this.lblWidth,
            this.lblHeight,
            this.lblFlagCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 236);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(469, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotal
            // 
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 17);
            this.lblTotal.Text = "Мины:";
            // 
            // lblWidth
            // 
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(55, 17);
            this.lblWidth.Text = "Ширина:";
            // 
            // lblHeight
            // 
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(50, 17);
            this.lblHeight.Text = "Высота:";
            // 
            // lblFlagCount
            // 
            this.lblFlagCount.Name = "lblFlagCount";
            this.lblFlagCount.Size = new System.Drawing.Size(54, 17);
            this.lblFlagCount.Text = "Флажки:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 258);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuGame;
        private System.Windows.Forms.ToolStripMenuItem mnuGameNew;
        private System.Windows.Forms.ToolStripSeparator strip1;
        private System.Windows.Forms.ToolStripMenuItem mnuGameBeginer;
        private System.Windows.Forms.ToolStripMenuItem mnuGameMiddle;
        private System.Windows.Forms.ToolStripMenuItem mnuGameProfi;
        private System.Windows.Forms.ToolStripMenuItem mnuGameUser;
        private System.Windows.Forms.ToolStripSeparator strip2;
        private System.Windows.Forms.ToolStripMenuItem mnuGameExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotal;
        private System.Windows.Forms.ToolStripStatusLabel lblWidth;
        private System.Windows.Forms.ToolStripStatusLabel lblHeight;
        private System.Windows.Forms.ToolStripStatusLabel lblFlagCount;

    }
}

