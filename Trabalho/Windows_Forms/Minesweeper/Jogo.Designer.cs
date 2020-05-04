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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPontos
            // 
            this.textBoxPontos.Location = new System.Drawing.Point(12, 34);
            this.textBoxPontos.Name = "textBoxPontos";
            this.textBoxPontos.ReadOnly = true;
            this.textBoxPontos.Size = new System.Drawing.Size(77, 20);
            this.textBoxPontos.TabIndex = 0;
            this.textBoxPontos.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Panel
            // 
            this.Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel.Location = new System.Drawing.Point(12, 66);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(270, 256);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            this.Panel.Layout += new System.Windows.Forms.LayoutEventHandler(this.LayoutPanel);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(130, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
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
            this.textBoxTime.Font = new System.Drawing.Font("Rockwell Nova Extra Bold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTime.Location = new System.Drawing.Point(205, 35);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(77, 22);
            this.textBoxTime.TabIndex = 2;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTime.TextChanged += new System.EventHandler(this.textBoxTime_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(294, 24);
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
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // perfilToolStripMenuItem1
            // 
            this.perfilToolStripMenuItem1.Name = "perfilToolStripMenuItem1";
            this.perfilToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.perfilToolStripMenuItem1.Text = "Perfil";
            this.perfilToolStripMenuItem1.Click += new System.EventHandler(this.perfilToolStripMenuItem_Click);
            // 
            // modoDeJogoToolStripMenuItem
            // 
            this.modoDeJogoToolStripMenuItem.Name = "modoDeJogoToolStripMenuItem";
            this.modoDeJogoToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.modoDeJogoToolStripMenuItem.Text = "Fácil";
            this.modoDeJogoToolStripMenuItem.Click += new System.EventHandler(this.FacilToolStripMenuItem_Click);
            // 
            // fácilToolStripMenuItem1
            // 
            this.fácilToolStripMenuItem1.Name = "fácilToolStripMenuItem1";
            this.fácilToolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.fácilToolStripMenuItem1.Text = "Médio";
            this.fácilToolStripMenuItem1.Click += new System.EventHandler(this.MedioToolStripMenuItem1_Click);
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 331);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.textBoxPontos);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
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
    }
}