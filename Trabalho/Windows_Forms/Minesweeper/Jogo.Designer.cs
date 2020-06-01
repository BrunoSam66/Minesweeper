namespace Minesweeper
{
    partial class Jogo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Jogo));
            this.textBoxPontos = new System.Windows.Forms.TextBox();
            this.Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modoDeJogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fácilToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.top10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPontos
            // 
            this.textBoxPontos.Location = new System.Drawing.Point(16, 42);
            this.textBoxPontos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPontos.Name = "textBoxPontos";
            this.textBoxPontos.ReadOnly = true;
            this.textBoxPontos.Size = new System.Drawing.Size(101, 22);
            this.textBoxPontos.TabIndex = 0;
            this.textBoxPontos.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Panel
            // 
            this.Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel.Location = new System.Drawing.Point(16, 81);
            this.Panel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(360, 315);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            this.Panel.Layout += new System.Windows.Forms.LayoutEventHandler(this.LayoutPanel);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(173, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 32);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTime.Location = new System.Drawing.Point(273, 43);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(101, 23);
            this.textBoxTime.TabIndex = 2;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTime.TextChanged += new System.EventHandler(this.textBoxTime_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.top10ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(392, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilToolStripMenuItem1,
            this.modoDeJogoToolStripMenuItem,
            this.fácilToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // perfilToolStripMenuItem1
            // 
            this.perfilToolStripMenuItem1.Name = "perfilToolStripMenuItem1";
            this.perfilToolStripMenuItem1.Size = new System.Drawing.Size(127, 26);
            this.perfilToolStripMenuItem1.Text = "Perfil";
            this.perfilToolStripMenuItem1.Click += new System.EventHandler(this.perfilToolStripMenuItem_Click);
            // 
            // modoDeJogoToolStripMenuItem
            // 
            this.modoDeJogoToolStripMenuItem.Name = "modoDeJogoToolStripMenuItem";
            this.modoDeJogoToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.modoDeJogoToolStripMenuItem.Text = "Fácil";
            this.modoDeJogoToolStripMenuItem.Click += new System.EventHandler(this.FacilToolStripMenuItem_Click);
            // 
            // fácilToolStripMenuItem1
            // 
            this.fácilToolStripMenuItem1.Name = "fácilToolStripMenuItem1";
            this.fácilToolStripMenuItem1.Size = new System.Drawing.Size(127, 26);
            this.fácilToolStripMenuItem1.Text = "Médio";
            this.fácilToolStripMenuItem1.Click += new System.EventHandler(this.MedioToolStripMenuItem1_Click);
            // 
            // top10ToolStripMenuItem
            // 
            this.top10ToolStripMenuItem.Name = "top10ToolStripMenuItem";
            this.top10ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.top10ToolStripMenuItem.Text = "Top 10";
            this.top10ToolStripMenuItem.Click += new System.EventHandler(this.top10ToolStripMenuItem_Click);
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 407);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.textBoxPontos);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Jogo";
            this.Text = "Jogo";
            this.Load += new System.EventHandler(this.Jogo_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPontos;
        private System.Windows.Forms.FlowLayoutPanel Panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modoDeJogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fácilToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem top10ToolStripMenuItem;
    }
}