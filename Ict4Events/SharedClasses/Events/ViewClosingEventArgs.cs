using System;
using System.Windows.Controls;

namespace SharedClasses.Events
{
    public class ViewClosingEventArgs : EventArgs
    {
        public UserControl View { get; protected set; }

        public ViewClosingEventArgs(UserControl view)
        {
            View = view;
        }
    }
}