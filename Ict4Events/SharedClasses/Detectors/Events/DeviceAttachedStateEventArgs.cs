using System;

namespace SharedClasses.Detectors.Events
{
    public class DeviceAttachedStateEventArgs : EventArgs
    {
        public DeviceAttachedStateEventArgs(AttachState state, string type, string name)
        {
            Type = type;
            Name = name;
            State = state;
        }

        public AttachState State { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}