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
            this.clearbutton = new System.Windows.Forms.Button();
            this.cookbutton = new System.Windows.Forms.Button();
            this.headerlabel = new System.Windows.Forms.Label();
            this.last_update_val_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.updatelabel = new System.Windows.Forms.Label();
            this.badlabel = new System.Windows.Forms.Label();
            this.spotlabel = new System.Windows.Forms.Label();
            this.optimallabel = new System.Windows.Forms.Label();
            this.droplabel = new System.Windows.Forms.Label();
            this.timelabel = new System.Windows.Forms.Label();
            this.framelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clearbutton
            // 
            this.clearbutton.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearbutton.Location = new System.Drawing.Point(391, 614);
            this.clearbutton.Name = "clearbutton";
            this.clearbutton.Size = new System.Drawing.Size(144, 47);
            this.clearbutton.TabIndex = 13;
            this.clearbutton.Text = "Clear";
            this.clearbutton.UseVisualStyleBackColor = true;
            this.clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // cookbutton
            // 
            this.cookbutton.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cookbutton.Location = new System.Drawing.Point(241, 614);
            this.cookbutton.Name = "cookbutton";
            this.cookbutton.Size = new System.Drawing.Size(144, 47);
            this.cookbutton.TabIndex = 14;
            this.cookbutton.Text = "Cook";
            this.cookbutton.UseVisualStyleBackColor = true;
            this.cookbutton.Click += new System.EventHandler(this.Cookbutton_Click);
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
            // last_update_val_label
            // 
            this.last_update_val_label.Location = new System.Drawing.Point(0, 0);
            this.last_update_val_label.Name = "last_update_val_label";
            this.last_update_val_label.Size = new System.Drawing.Size(100, 23);
            this.last_update_val_label.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(152, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "Last Updated: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(168, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 35);
            this.label2.TabIndex = 16;
            this.label2.Text = "Bad Count: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(168, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 35);
            this.label3.TabIndex = 17;
            this.label3.Text = "Spot Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(152, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 35);
            this.label4.TabIndex = 18;
            this.label4.Text = "Optimal Count: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(241, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 35);
            this.label5.TabIndex = 19;
            this.label5.Text = "Drop: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(184, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 35);
            this.label6.TabIndex = 20;
            this.label6.Text = "Time Taken: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(184, 477);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 35);
            this.label7.TabIndex = 21;
            this.label7.Text = "Time Frame: ";
            // 
            // updatelabel
            // 
            this.updatelabel.AutoSize = true;
            this.updatelabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.updatelabel.Location = new System.Drawing.Point(411, 155);
            this.updatelabel.Name = "updatelabel";
            this.updatelabel.Size = new System.Drawing.Size(111, 35);
            this.updatelabel.TabIndex = 22;
            this.updatelabel.Text = "label8";
            // 
            // badlabel
            // 
            this.badlabel.AutoSize = true;
            this.badlabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.badlabel.Location = new System.Drawing.Point(411, 212);
            this.badlabel.Name = "badlabel";
            this.badlabel.Size = new System.Drawing.Size(111, 35);
            this.badlabel.TabIndex = 23;
            this.badlabel.Text = "label9";
            // 
            // spotlabel
            // 
            this.spotlabel.AutoSize = true;
            this.spotlabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.spotlabel.Location = new System.Drawing.Point(411, 270);
            this.spotlabel.Name = "spotlabel";
            this.spotlabel.Size = new System.Drawing.Size(127, 35);
            this.spotlabel.TabIndex = 24;
            this.spotlabel.Text = "label10";
            // 
            // optimallabel
            // 
            this.optimallabel.AutoSize = true;
            this.optimallabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.optimallabel.Location = new System.Drawing.Point(411, 325);
            this.optimallabel.Name = "optimallabel";
            this.optimallabel.Size = new System.Drawing.Size(127, 35);
            this.optimallabel.TabIndex = 25;
            this.optimallabel.Text = "label11";
            // 
            // droplabel
            // 
            this.droplabel.AutoSize = true;
            this.droplabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.droplabel.Location = new System.Drawing.Point(411, 371);
            this.droplabel.Name = "droplabel";
            this.droplabel.Size = new System.Drawing.Size(127, 35);
            this.droplabel.TabIndex = 26;
            this.droplabel.Text = "label12";
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timelabel.Location = new System.Drawing.Point(411, 423);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(127, 35);
            this.timelabel.TabIndex = 27;
            this.timelabel.Text = "label13";
            // 
            // framelabel
            // 
            this.framelabel.AutoSize = true;
            this.framelabel.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.framelabel.Location = new System.Drawing.Point(411, 477);
            this.framelabel.Name = "framelabel";
            this.framelabel.Size = new System.Drawing.Size(127, 35);
            this.framelabel.TabIndex = 28;
            this.framelabel.Text = "label14";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(795, 776);
            this.Controls.Add(this.framelabel);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.droplabel);
            this.Controls.Add(this.optimallabel);
            this.Controls.Add(this.spotlabel);
            this.Controls.Add(this.badlabel);
            this.Controls.Add(this.updatelabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearbutton);
            this.Controls.Add(this.cookbutton);
            this.Controls.Add(this.headerlabel);
            this.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainWindow";
            this.Text = ":w";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button clearbutton;
        private Button cookbutton;
        private Label headerlabel;
        private Label last_update_val_label;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label updatelabel;
        private Label badlabel;
        private Label spotlabel;
        private Label optimallabel;
        private Label droplabel;
        private Label timelabel;
        private Label framelabel;
    }
}
