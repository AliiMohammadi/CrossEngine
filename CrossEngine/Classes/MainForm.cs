using System.Windows.Forms;

namespace CrossEngine.Classes
{
    public class MainForm : Form
    {
        public PictureBox UIpic;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.UIpic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.UIpic)).BeginInit();
            this.SuspendLayout();
            // 
            // UIpic
            // 
            this.UIpic.BackColor = System.Drawing.Color.Transparent;
            this.UIpic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UIpic.Location = new System.Drawing.Point(0, 0);
            this.UIpic.Name = "UIpic";
            this.UIpic.Size = new System.Drawing.Size(444, 393);
            this.UIpic.TabIndex = 0;
            this.UIpic.TabStop = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(444, 393);
            this.Controls.Add(this.UIpic);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.UIpic)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
