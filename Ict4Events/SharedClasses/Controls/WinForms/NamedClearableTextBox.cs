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

        private bool _hideClearButton;
        private string _labelText;

        public NamedClearableTextBox()
        {
            InitializeComponent();
        }

        public int InputWidth
        {
            get { return textBoxInput.Width; }
            set
            {
                if (value < 0)
                    return;
                textBoxInput.Width = value;
            }
        }

        [DefaultValue(ClearButtonActionType.ClearText)]
        public ClearButtonActionType ButtonActionType { get; set; }

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

        /// <summary>
        ///     Gets or sets the input text.
        /// </summary>
        public override string Text
        {
            get { return textBoxInput.Text; }
            set { textBoxInput.Text = value; }
        }

        /// <summary>
        ///     Clears the <see cref="TextBox.Text" />.
        /// </summary>
        public void Clear()
        {
            textBoxInput.Clear();
        }

        /// <summary>
        ///     Moves the cursor at the first position in the <see cref="TextBox" />.
        /// </summary>
        public void FocusStart()
        {
            textBoxInput.Focus();
            textBoxInput.Select(0, 0);
        }

        /// <summary>
        ///     /Moves the cursor at the last position in the <see cref="TextBox" />.
        /// </summary>
        public void FocusEnd()
        {
            textBoxInput.Focus();
            textBoxInput.Select(textBoxInput.TextLength, 0);
        }

        /// <summary>
        ///     Moves the cursor in the <see cref="TextBox" /> and selects all the text.
        /// </summary>
        public void FocusSelectAll()
        {
            textBoxInput.Focus();
            textBoxInput.SelectAll();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    buttonClear.PerformClick();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}