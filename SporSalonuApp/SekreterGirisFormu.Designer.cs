namespace SporSalonuApp
{
    partial class SekreterGirisFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SekreterGirisFormu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uyelerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uyeBilgileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışlarTahsilatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satislarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tahsilatarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urunGirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uyelerToolStripMenuItem,
            this.satışlarTahsilatlarToolStripMenuItem,
            this.ürünToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uyelerToolStripMenuItem
            // 
            this.uyelerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uyeBilgileriToolStripMenuItem});
            this.uyelerToolStripMenuItem.Name = "uyelerToolStripMenuItem";
            this.uyelerToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.uyelerToolStripMenuItem.Text = "Uyeler";
            // 
            // uyeBilgileriToolStripMenuItem
            // 
            this.uyeBilgileriToolStripMenuItem.Name = "uyeBilgileriToolStripMenuItem";
            this.uyeBilgileriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uyeBilgileriToolStripMenuItem.Text = "Uye Bilgileri";
            this.uyeBilgileriToolStripMenuItem.Click += new System.EventHandler(this.uyeBilgileriToolStripMenuItem_Click);
            // 
            // satışlarTahsilatlarToolStripMenuItem
            // 
            this.satışlarTahsilatlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.satislarToolStripMenuItem,
            this.tahsilatarToolStripMenuItem});
            this.satışlarTahsilatlarToolStripMenuItem.Name = "satışlarTahsilatlarToolStripMenuItem";
            this.satışlarTahsilatlarToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.satışlarTahsilatlarToolStripMenuItem.Text = "Satışlar Tahsilatlar";
            // 
            // satislarToolStripMenuItem
            // 
            this.satislarToolStripMenuItem.Name = "satislarToolStripMenuItem";
            this.satislarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.satislarToolStripMenuItem.Text = "Satislar";
            this.satislarToolStripMenuItem.Click += new System.EventHandler(this.satislarToolStripMenuItem_Click);
            // 
            // tahsilatarToolStripMenuItem
            // 
            this.tahsilatarToolStripMenuItem.Name = "tahsilatarToolStripMenuItem";
            this.tahsilatarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.tahsilatarToolStripMenuItem.Text = "Tahsilatar";
            this.tahsilatarToolStripMenuItem.Click += new System.EventHandler(this.tahsilatarToolStripMenuItem_Click);
            // 
            // ürünToolStripMenuItem
            // 
            this.ürünToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urunGirToolStripMenuItem});
            this.ürünToolStripMenuItem.Name = "ürünToolStripMenuItem";
            this.ürünToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.ürünToolStripMenuItem.Text = "Ürün";
            // 
            // urunGirToolStripMenuItem
            // 
            this.urunGirToolStripMenuItem.Name = "urunGirToolStripMenuItem";
            this.urunGirToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.urunGirToolStripMenuItem.Text = "Urun Gir";
            this.urunGirToolStripMenuItem.Click += new System.EventHandler(this.urunGirToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // SekreterGirisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(555, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SekreterGirisFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SekreterGirisFormu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SekreterGirisFormu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uyelerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uyeBilgileriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışlarTahsilatlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satislarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tahsilatarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urunGirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}