
namespace DTC.UI.CommonPages
{
	partial class MainPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.btnF16 = new System.Windows.Forms.Button();
            this.btnWptDatabase = new System.Windows.Forms.Button();
            this.btnJF17 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnF16
            // 
            this.btnF16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF16.ForeColor = System.Drawing.Color.Black;
            this.btnF16.Image = global::DTC.Properties.Resources.F16;
            this.btnF16.Location = new System.Drawing.Point(13, 14);
            this.btnF16.Name = "btnF16";
            this.btnF16.Padding = new System.Windows.Forms.Padding(5);
            this.btnF16.Size = new System.Drawing.Size(200, 100);
            this.btnF16.TabIndex = 3;
            this.btnF16.Text = "F-16C Viper";
            this.btnF16.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnF16.UseVisualStyleBackColor = true;
            this.btnF16.Click += new System.EventHandler(this.btnf16_Click);
            // 
            // btnWptDatabase
            // 
            this.btnWptDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWptDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWptDatabase.ForeColor = System.Drawing.Color.Black;
            this.btnWptDatabase.Image = global::DTC.Properties.Resources.Waypoints;
            this.btnWptDatabase.Location = new System.Drawing.Point(219, 14);
            this.btnWptDatabase.Name = "btnWptDatabase";
            this.btnWptDatabase.Padding = new System.Windows.Forms.Padding(5);
            this.btnWptDatabase.Size = new System.Drawing.Size(200, 100);
            this.btnWptDatabase.TabIndex = 4;
            this.btnWptDatabase.Text = "Waypoints Database";
            this.btnWptDatabase.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnWptDatabase.UseVisualStyleBackColor = true;
            this.btnWptDatabase.Visible = false;
            this.btnWptDatabase.Click += new System.EventHandler(this.btnWptDatabase_Click);
            // 
            // btnJF17
            // 
            this.btnJF17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJF17.ForeColor = System.Drawing.Color.Black;
            this.btnJF17.Image = ((System.Drawing.Image)(resources.GetObject("btnJF17.Image")));
            this.btnJF17.Location = new System.Drawing.Point(13, 130);
            this.btnJF17.Name = "btnJF17";
            this.btnJF17.Padding = new System.Windows.Forms.Padding(5);
            this.btnJF17.Size = new System.Drawing.Size(200, 100);
            this.btnJF17.TabIndex = 5;
            this.btnJF17.Text = "JF-17";
            this.btnJF17.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnJF17.UseVisualStyleBackColor = true;
            this.btnJF17.Click += new System.EventHandler(this.btnJF17_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.btnJF17);
            this.Controls.Add(this.btnF16);
            this.Controls.Add(this.btnWptDatabase);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(669, 434);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnF16;
		private System.Windows.Forms.Button btnWptDatabase;
        private System.Windows.Forms.Button btnJF17;
    }
}
