namespace KikikuruAmagumoViewer
{
    partial class Viewer_Simple
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
            PB_Main = new PictureBox();
            L_message = new Label();
            ((System.ComponentModel.ISupportInitialize)PB_Main).BeginInit();
            SuspendLayout();
            // 
            // PB_Main
            // 
            PB_Main.BackColor = Color.FromArgb(0, 0, 0, 0);
            PB_Main.Dock = DockStyle.Fill;
            PB_Main.Location = new Point(0, 0);
            PB_Main.Name = "PB_Main";
            PB_Main.Size = new Size(512, 512);
            PB_Main.SizeMode = PictureBoxSizeMode.Zoom;
            PB_Main.TabIndex = 0;
            PB_Main.TabStop = false;
            // 
            // L_message
            // 
            L_message.AutoSize = true;
            L_message.BackColor = Color.FromArgb(0, 0, 0, 0);
            L_message.Location = new Point(0, 0);
            L_message.Name = "L_message";
            L_message.Size = new Size(63, 15);
            L_message.TabIndex = 1;
            L_message.Text = "地図データ: ";
            // 
            // Viewer_Simple
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 512);
            Controls.Add(L_message);
            Controls.Add(PB_Main);
            Name = "Viewer_Simple";
            Text = "Viewer.Simple";
            Load += Viewer_Load;
            KeyDown += Viewer_Simple_KeyDown;
            Resize += Viewer_Simple_Resize;
            ((System.ComponentModel.ISupportInitialize)PB_Main).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PB_Main;
        private Label L_message;
    }
}