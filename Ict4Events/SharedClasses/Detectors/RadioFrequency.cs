using System;
using System.Collections.Generic;
using System.Linq;
using SharedClasses.Detectors.Events;
using P = Phidgets;
using TagEventArgs = Phidgets.Events.TagEventArgs;
using TagEventHandler = SharedClasses.Detectors.Events.TagEventHandler;

namespace SharedClasses.Detectors
{
    public class RadioFrequency : IDisposable
    {
        private bool _ledOnDetecting;

        public RadioFrequency() : this(-1)
        {
        }

        public RadioFrequency(int serial)
        {
            Cache = new List<string>();
            BaseRFID = new P.RFID();
            BaseRFID.open(serial);
            BaseRFID.waitForAttachment();
            BaseRFID.Antenna = true;
            BaseRFID.Tag += (sender, args) =>
            {
                Cache.Add(args.Tag);
                OnTag(new Events.TagEventArgs(args.Tag, LastTag, TagsDetected));
            };
            BaseRFID.TagLost +=
                (sender, args) => OnTagLost(new Events.TagEventArgs(args.Tag, LastTag, TagsDetected));
            BaseRFID.Attach +=
                (sender, args) =>
                    OnAttached(new DeviceAttachedStateEventArgs(AttachState.Connected, args.Device.Type,
                        args.Device.Name));
            BaseRFID.Detach +=
                (sender, args) =>
                    OnAttached(new DeviceAttachedStateEventArgs(AttachState.Disconnected, args.Device.Type,
                        args.Device.Name));
        }

        protected List<string> Cache { get; set; }

        public IEnumerable<string> TagsDetected
        {
            get { return Cache; }
        }

        protected P.RFID BaseRFID { get; set; }

        /// <summary>
        ///     True if a Tag is currently in range.
        /// </summary>
        public bool TagPresent
        {
            get { return BaseRFID.TagPresent; }
        }

        /// <summary>
        ///     Returns the last Tag detected.
        /// </summary>
        public string LastTag
        {
            get
            {
                if (TagsDetected.Count() <= 1) return null;
                return BaseRFID.LastTag;
            }
        }

        public string Type
        {
            get { return BaseRFID.Type; }
        }

        public int Version
        {
            get { return BaseRFID.Version; }
        }

        public bool LEDOnDetecting
        {
            set
            {
                if (value == _ledOnDetecting) return;
                _ledOnDetecting = value;
                if (_ledOnDetecting)
                {
                    BaseRFID.Tag += LEDOnDetectingTag;
                    BaseRFID.TagLost += LEDOnDetectingTagLost;
                }
                else
                {
                    BaseRFID.Tag -= LEDOnDetectingTag;
                    BaseRFID.TagLost -= LEDOnDetectingTagLost;
                }
            }
            get { return _ledOnDetecting; }
        }

        public void Dispose()
        {
            Close();
        }

        private void LEDOnDetectingTagLost(object sender, TagEventArgs tagEventArgs)
        {
            BaseRFID.LED = false;
        }

        private void LEDOnDetectingTag(object sender, TagEventArgs tagEventArgs)
        {
            BaseRFID.LED = true;
        }

        public event TagEventHandler Tag;
        public event DeviceAttachedStateEventHandler Attached;

        protected virtual void OnAttached(DeviceAttachedStateEventArgs e)
        {
            DeviceAttachedStateEventHandler handler = Attached;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnTag(Events.TagEventArgs e)
        {
            TagEventHandler handler = Tag;
            if (handler != null) handler(this, e);
        }

        public event TagEventHandler TagLost;

        protected virtual void OnTagLost(Events.TagEventArgs e)
        {
            TagEventHandler handler = TagLost;
            if (handler != null) handler(this, e);
        }

        public void WaitForAttachment()
        {
            BaseRFID.waitForAttachment();
        }

        public void Write(string value)
        {
            BaseRFID.write(value, P.RFID.RFIDTagProtocol.EM4100, false);
        }

        public void WriteLock(string value)
        {
            BaseRFID.write(value, P.RFID.RFIDTagProtocol.EM4100, true);
        }

        public void OpenLabel(string label)
        {
            BaseRFID.openLabel(label);
        }

        public void Close()
        {
            BaseRFID.close();
        }
    }
}