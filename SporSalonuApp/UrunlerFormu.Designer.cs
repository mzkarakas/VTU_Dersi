namespace SporSalonuApp
{
    partial class UrunlerFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunlerFormu));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSil = new System.Windows.Forms.Button();
            this.BtnDuzelt = new System.Windows.Forms.Button();
            this.BtnEkle = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnArama = new System.Windows.Forms.Button();
            this.BtnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(101, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 30);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(101, 88);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 30);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Adi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(10, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fiyati";
            // 
            // BtnSil
            // 
            this.BtnSil.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.Image")));
            this.BtnSil.Location = new System.Drawing.Point(162, 157);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(68, 63);
            this.BtnSil.TabIndex = 48;
            this.BtnSil.UseVisualStyleBackColor = true;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnDuzelt
            // 
            this.BtnDuzelt.Image = ((System.Drawing.Image)(resources.GetObject("BtnDuzelt.Image")));
            this.BtnDuzelt.Location = new System.Drawing.Point(90, 157);
            this.BtnDuzelt.Name = "BtnDuzelt";
            this.BtnDuzelt.Size = new System.Drawing.Size(66, 63);
            this.BtnDuzelt.TabIndex = 47;
            this.BtnDuzelt.UseVisualStyleBackColor = true;
            this.BtnDuzelt.Click += new System.EventHandler(this.BtnDuzelt_Click);
            // 
            // BtnEkle
            // 
            this.BtnEkle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEkle.BackgroundImage")));
            this.BtnEkle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnEkle.Location = new System.Drawing.Point(23, 157);
            this.BtnEkle.Name = "BtnEkle";
            this.BtnEkle.Size = new System.Drawing.Size(61, 63);
            this.BtnEkle.TabIndex = 46;
            this.BtnEkle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEkle.UseVisualStyleBackColor = true;
            this.BtnEkle.Click += new System.EventHandler(this.BtnEkle_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LemonChiffon;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ForeColor = System.Drawing.Color.Blue;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(331, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(296, 191);
            this.listView1.TabIndex = 49;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Urun No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ürün Adi";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fiyatı";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // BtnArama
            // 
            this.BtnArama.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnArama.BackgroundImage")));
            this.BtnArama.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnArama.Location = new System.Drawing.Point(286, 28);
            this.BtnArama.Name = "BtnArama";
            this.BtnArama.Size = new System.Drawing.Size(39, 34);
            this.BtnArama.TabIndex = 51;
            this.BtnArama.UseVisualStyleBackColor = true;
            this.BtnArama.Click += new System.EventHandler(this.BtnArama_Click);
            // 
            // BtnCikis
            // 
            this.BtnCikis.BackColor = System.Drawing.Color.Transparent;
            this.BtnCikis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCikis.BackgroundImage")));
            this.BtnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCikis.Location = new System.Drawing.Point(262, 157);
            this.BtnCikis.Name = "BtnCikis";
            this.BtnCikis.Size = new System.Drawing.Size(63, 63);
            this.BtnCikis.TabIndex = 52;
            this.BtnCikis.UseVisualStyleBackColor = false;
            this.BtnCikis.Click += new System.EventHandler(this.BtnCikis_Click);
            // 
            // UrunlerFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 260);
            this.Controls.Add(this.BtnCikis);
            this.Controls.Add(this.BtnArama);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.BtnSil);
            this.Controls.Add(this.BtnDuzelt);
            this.Controls.Add(this.BtnEkle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.MinimizeBox = false;
            this.Name = "UrunlerFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürünler";
            this.Load += new System.EventHandler(this.UrunlerFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSil;
        private System.Windows.Forms.Button BtnDuzelt;
        private System.Windows.Forms.Button BtnEkle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button BtnArama;
        private System.Windows.Forms.Button BtnCikis;
    }
}