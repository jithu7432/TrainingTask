namespace BatteryAppGUI 
{
    partial class MainWindow 
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent() {
            this._badlabel = new System.Windows.Forms.Label();
            this._droplabel = new System.Windows.Forms.Label();
            this._optimallabel = new System.Windows.Forms.Label();
            this._spotlabel = new System.Windows.Forms.Label();
            this._timelabel = new System.Windows.Forms.Label();
            this.badlabel = new System.Windows.Forms.Label();
            this.clearbutton = new System.Windows.Forms.Button();
            this.cookbutton = new System.Windows.Forms.Button();
            this.droplabel = new System.Windows.Forms.Label();
            this.headerlabel = new System.Windows.Forms.Label();
            this.lheader = new System.Windows.Forms.Label();
            this.optimallabel = new System.Windows.Forms.Label();
            this.spotlabel = new System.Windows.Forms.Label();
            this.timelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // headerlabel
            // 
            this.headerlabel.AutoSize = true;
            this.headerlabel.BackColor = System.Drawing.Color.White;
            this.headerlabel.Font = new System.Drawing.Font("Showcard Gothic", 20.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerlabel.ForeColor = System.Drawing.Color.Red;
            this.headerlabel.Location = new System.Drawing.Point(241, 35);
            this.headerlabel.Name = "headerlabel";
            this.headerlabel.Size = new System.Drawing.Size(294, 35);
            this.headerlabel.TabIndex = 0;
            this.headerlabel.Text = "Battery Satistics";
            // 
            // lheader
            // 
            this.lheader.AutoSize = true;
            this.lheader.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lheader.Location = new System.Drawing.Point(33, 140);
            this.lheader.Name = "lheader";
            this.lheader.Size = new System.Drawing.Size(268, 29);
            this.lheader.TabIndex = 1;
            this.lheader.Text = "*Past 1 hour of usage*";
            // 
            // _droplabel
            // 
            this._droplabel.AutoSize = true;
            this._droplabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._droplabel.Location = new System.Drawing.Point(33, 191);
            this._droplabel.Name = "_droplabel";
            this._droplabel.Size = new System.Drawing.Size(83, 29);
            this._droplabel.TabIndex = 3;
            this._droplabel.Text = "Drop: ";
            // 
            // _timelabel
            // 
            this._timelabel.AutoSize = true;
            this._timelabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._timelabel.Location = new System.Drawing.Point(33, 246);
            this._timelabel.Name = "_timelabel";
            this._timelabel.Size = new System.Drawing.Size(83, 29);
            this._timelabel.TabIndex = 4;
            this._timelabel.Text = "Time: ";
            // 
            // _optimallabel
            // 
            this._optimallabel.AutoSize = true;
            this._optimallabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._optimallabel.Location = new System.Drawing.Point(467, 192);
            this._optimallabel.Name = "_optimallabel";
            this._optimallabel.Size = new System.Drawing.Size(186, 29);
            this._optimallabel.TabIndex = 5;
            this._optimallabel.Text = "Optimal Count:";
            // 
            // _spotlabel
            // 
            this._spotlabel.AutoSize = true;
            this._spotlabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._spotlabel.Location = new System.Drawing.Point(502, 140);
            this._spotlabel.Name = "_spotlabel";
            this._spotlabel.Size = new System.Drawing.Size(151, 29);
            this._spotlabel.TabIndex = 6;
            this._spotlabel.Text = "Spot Count:\r\n";
            // 
            // _badlabel
            // 
            this._badlabel.AutoSize = true;
            this._badlabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._badlabel.Location = new System.Drawing.Point(511, 245);
            this._badlabel.Name = "_badlabel";
            this._badlabel.Size = new System.Drawing.Size(142, 29);
            this._badlabel.TabIndex = 7;
            this._badlabel.Text = "Bad Count:";
            // 
            // spotlabel
            // 
            this.spotlabel.AutoSize = true;
            this.spotlabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.spotlabel.Location = new System.Drawing.Point(659, 140);
            this.spotlabel.Name = "spotlabel";
            this.spotlabel.Size = new System.Drawing.Size(83, 28);
            this.spotlabel.TabIndex = 8;
            this.spotlabel.Text = "label7";
            // 
            // optimallabel
            // 
            this.optimallabel.AutoSize = true;
            this.optimallabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.optimallabel.Location = new System.Drawing.Point(659, 192);
            this.optimallabel.Name = "optimallabel";
            this.optimallabel.Size = new System.Drawing.Size(83, 28);
            this.optimallabel.TabIndex = 9;
            this.optimallabel.Text = "label8";
            // 
            // badlabel
            // 
            this.badlabel.AutoSize = true;
            this.badlabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.badlabel.Location = new System.Drawing.Point(659, 245);
            this.badlabel.Name = "badlabel";
            this.badlabel.Size = new System.Drawing.Size(83, 28);
            this.badlabel.TabIndex = 10;
            this.badlabel.Text = "label9";
            // 
            // droplabel
            // 
            this.droplabel.AutoSize = true;
            this.droplabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.droplabel.Location = new System.Drawing.Point(120, 190);
            this.droplabel.Name = "droplabel";
            this.droplabel.Size = new System.Drawing.Size(97, 28);
            this.droplabel.TabIndex = 11;
            this.droplabel.Text = "label10";
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timelabel.Location = new System.Drawing.Point(120, 246);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(97, 28);
            this.timelabel.TabIndex = 12;
            this.timelabel.Text = "label11";
            // 
            // clearbutton
            // 
            this.clearbutton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearbutton.Location = new System.Drawing.Point(303, 368);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(144, 47);
            this.clearbutton.TabIndex = 13;
            this.clearbutton.Text = "Clear";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // cookbutton
            // 
            this.cookbutton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cookbutton.Location = new System.Drawing.Point(303, 315);
            this.cookbutton.Name = "cookbutton";
            this.cookbutton.Size = new System.Drawing.Size(144, 47);
            this.cookbutton.TabIndex = 14;
            this.cookbutton.Text = "Cook";
            this.cookbutton.UseVisualStyleBackColor = true;
            this.cookbutton.Click += new System.EventHandler(this.Cookbutton_Click);

            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this._badlabel);
            this.Controls.Add(this._droplabel);
            this.Controls.Add(this._optimallabel);
            this.Controls.Add(this._spotlabel);
            this.Controls.Add(this._timelabel);
            this.Controls.Add(this.badlabel);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.cookbutton);
            this.Controls.Add(this.droplabel);
            this.Controls.Add(this.headerlabel);
            this.Controls.Add(this.lheader);
            this.Controls.Add(this.optimallabel);
            this.Controls.Add(this.spotlabel);
            this.Controls.Add(this.timelabel);
            this.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainWindow";
            this.Text = "BatteryApp";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button clearbutton;
        private Button cookbutton;
        private Label _badlabel;
        private Label _droplabel;
        private Label _optimallabel;
        private Label _spotlabel;
        private Label _timelabel;
        private Label badlabel;
        private Label droplabel;
        private Label headerlabel;
        private Label lheader;
        private Label optimallabel;
        private Label spotlabel;
        private Label timelabel;
    }
}
