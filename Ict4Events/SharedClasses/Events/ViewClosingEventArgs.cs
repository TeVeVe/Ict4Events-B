using System;
using System.Windows.Controls;

namespace SharedClasses.Events
{
    public class ViewClosingEventArgs : EventArgs
    {
        public ViewClosingEventArgs(UserControl view)
        {
            View = view;
        }

        public UserControl View { get; protected set; }
    }
}