using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public class PanelTile : Panel
    {
        public PanelTile(string primaryText, string secondaryText, string imagePath = null)
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
        }

        protected override void OnMouseHover(EventArgs e)
        {
            BorderStyle = BorderStyle.FixedSingle;
            base.OnMouseHover(e);
        }



        protected override void OnMouseLeave(EventArgs e)
        {
            BorderStyle = BorderStyle.None;
            base.OnMouseLeave(e);
        }
    }
}
