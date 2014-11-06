using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class NamedClearableTextBox : UserControl
    {
        public enum ClearButtonActionType
        {
            ClearText,
            Custom
        }

        [DefaultValue(ClearButtonActionType.ClearText)]
        public ClearButtonActionType ButtonActionType { get; set; }

        private bool _hideClearButton;
        private string _labelText;

        public NamedClearableTextBox()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public Action ClearButtonAction { get; set; }

        [DefaultValue(false)]
        public bool HideClearButton
        {
            get { return _hideClearButton; }
            set
            {
                _hideClearButton = value;
                buttonClear.Visible = !_hideClearButton;
            }
        }

        [DefaultValue("LabelText:")]
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                labelName.Text = value;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            switch (ButtonActionType)
            {
                case ClearButtonActionType.Custom:
                    if (ClearButtonAction != null)
                        ClearButtonAction();
                    break;
                default:
                    textBoxInput.Clear();
                    break;
            }
        }
    }
}