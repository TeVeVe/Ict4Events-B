using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public class PanelTileOld : Panel
    {
        public PanelTileOld(string primaryText, string secondaryText, string image = null)
        {
            BackColor = Color.Red;

            Width = 140;
            Height = 140;

            Panel textPanel = new Panel();
            textPanel.BackColor = Color.Black;
            Controls.Add(textPanel);
            textPanel.Height = 30;
            textPanel.Dock = DockStyle.Bottom;

            Label primaryLabel = new Label();
            textPanel.Controls.Add(primaryLabel);
            primaryLabel.Text = primaryText;
            primaryLabel.ForeColor = Color.White;
            primaryLabel.AutoSize = true;
            
            Label secondaryLabel = new Label();
            textPanel.Controls.Add(secondaryLabel);
            secondaryLabel.Text = secondaryText;
            secondaryLabel.ForeColor = Color.White;
            secondaryLabel.Location = new Point(0, 15);
            secondaryLabel.AutoSize = true;
            secondaryLabel.Font = new Font(secondaryLabel.Font.FontFamily, 6);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
        }
    }
}
