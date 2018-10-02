namespace SxGeoReader
{
    partial class frmMain
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
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnShowRegions = new System.Windows.Forms.Button();
            this.BtnShowCountries = new System.Windows.Forms.Button();
            this.btnShowCites = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.rbSxGeoCity = new System.Windows.Forms.RadioButton();
            this.rbSxGeo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(2, 3);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnShowRegions
            // 
            this.btnShowRegions.Location = new System.Drawing.Point(83, 3);
            this.btnShowRegions.Name = "btnShowRegions";
            this.btnShowRegions.Size = new System.Drawing.Size(75, 23);
            this.btnShowRegions.TabIndex = 2;
            this.btnShowRegions.Text = "Regions";
            this.btnShowRegions.UseVisualStyleBackColor = true;
            this.btnShowRegions.Click += new System.EventHandler(this.btnShowRegions_Click);
            // 
            // BtnShowCountries
            // 
            this.BtnShowCountries.Location = new System.Drawing.Point(164, 3);
            this.BtnShowCountries.Name = "BtnShowCountries";
            this.BtnShowCountries.Size = new System.Drawing.Size(75, 23);
            this.BtnShowCountries.TabIndex = 3;
            this.BtnShowCountries.Text = "Countries";
            this.BtnShowCountries.UseVisualStyleBackColor = true;
            this.BtnShowCountries.Click += new System.EventHandler(this.BtnShowCountries_Click);
            // 
            // btnShowCites
            // 
            this.btnShowCites.Location = new System.Drawing.Point(245, 3);
            this.btnShowCites.Name = "btnShowCites";
            this.btnShowCites.Size = new System.Drawing.Size(75, 23);
            this.btnShowCites.TabIndex = 4;
            this.btnShowCites.Text = "Cites";
            this.btnShowCites.UseVisualStyleBackColor = true;
            this.btnShowCites.Click += new System.EventHandler(this.btnShowCites_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(-1, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(321, 20);
            this.txtIP.TabIndex = 6;
            this.txtIP.Text = "93.190.206.171";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(112, 79);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Check IP";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // rbSxGeoCity
            // 
            this.rbSxGeoCity.AutoSize = true;
            this.rbSxGeoCity.Checked = true;
            this.rbSxGeoCity.Location = new System.Drawing.Point(66, 56);
            this.rbSxGeoCity.Name = "rbSxGeoCity";
            this.rbSxGeoCity.Size = new System.Drawing.Size(92, 17);
            this.rbSxGeoCity.TabIndex = 8;
            this.rbSxGeoCity.TabStop = true;
            this.rbSxGeoCity.Text = "SxGeoCity.dat";
            this.rbSxGeoCity.UseVisualStyleBackColor = true;
            this.rbSxGeoCity.CheckedChanged += new System.EventHandler(this.rbSxGeoCity_CheckedChanged);
            // 
            // rbSxGeo
            // 
            this.rbSxGeo.AutoSize = true;
            this.rbSxGeo.Location = new System.Drawing.Point(164, 56);
            this.rbSxGeo.Name = "rbSxGeo";
            this.rbSxGeo.Size = new System.Drawing.Size(75, 17);
            this.rbSxGeo.TabIndex = 9;
            this.rbSxGeo.Text = "SxGeo.dat";
            this.rbSxGeo.UseVisualStyleBackColor = true;
            this.rbSxGeo.CheckedChanged += new System.EventHandler(this.rbSxGeoCity_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 108);
            this.Controls.Add(this.rbSxGeo);
            this.Controls.Add(this.rbSxGeoCity);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnShowCites);
            this.Controls.Add(this.BtnShowCountries);
            this.Controls.Add(this.btnShowRegions);
            this.Controls.Add(this.btnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnShowRegions;
        private System.Windows.Forms.Button BtnShowCountries;
        private System.Windows.Forms.Button btnShowCites;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.RadioButton rbSxGeoCity;
        private System.Windows.Forms.RadioButton rbSxGeo;
    }
}

