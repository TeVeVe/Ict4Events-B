using System;

namespace SharedClasses.Detectors.Events
{
    public delegate void DeviceAttachedStateEventHandler(object sender, DeviceAttachedStateEventArgs e);

    public class DeviceAttachedStateEventArgs : EventArgs
    {
        public AttachState State { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public DeviceAttachedStateEventArgs(AttachState state, string type, string name)
        {
            Type = type;
            Name = name;
            State = state;
        }
    }
}