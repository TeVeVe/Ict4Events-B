using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedClasses.Detectors.Events;
using P = Phidgets;
using TagEventArgs = Phidgets.Events.TagEventArgs;

namespace SharedClasses.Detectors
{
    /// <summary>
    ///     A wrapper for Phidget API - RFID devices.
    /// </summary>
    public class RadioFrequency : IDisposable
    {
        private bool _ledOnDetecting;

        /// <summary>
        ///     Creates and waits for a connected RFID USB device and gives it -1 as serialkey.
        /// </summary>
        public RadioFrequency(bool waitForAttachment = false) : this(-1, waitForAttachment)
        {
        }

        /// <summary>
        ///     Creates and waits for a connected RFID USB device.
        /// </summary>
        /// <param name="serial">Serialkey of the device as identitfier. Useful when multiple devices are connected.</param>
        /// <param name="waitForAttachment">If true, waits for attachment</param>
        public RadioFrequency(int serial, bool waitForAttachment = false)
        {
            // A cache for all the detected keys.
            Cache = new List<string>();

            // Booting up the base API.
            BaseRFID = new P.RFID();
            BaseRFID.open(serial);
            if (waitForAttachment)
            {
                BaseRFID.waitForAttachment();
                InitRadioFrequency();
            }
            else
                BaseRFID.Attach += (sender, args) => InitRadioFrequency();
        }

        protected List<string> Cache { get; set; }

        /// <summary>
        ///     Previously detected tags in chronological order.
        /// </summary>
        public IEnumerable<string> TagsDetected
        {
            get { return Cache; }
        }

        /// <summary>
        ///     Phidget API main RFID object. This is used for wrapping the API.
        /// </summary>
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
                if (TagsDetected.Count() <= 1)
                    return null;
                return BaseRFID.LastTag;
            }
        }

        /// <summary>
        ///     Device type of the Phidget device.
        /// </summary>
        public string Type
        {
            get { return BaseRFID.Type; }
        }

        /// <summary>
        ///     Device version of the Phidget device.
        /// </summary>
        public int Version
        {
            get { return BaseRFID.Version; }
        }

        /// <summary>
        ///     When enabled, turns on the LED when a tag is being detected.
        /// </summary>
        public bool LEDOnDetecting
        {
            set
            {
                if (value == _ledOnDetecting)
                    return;
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

        /// <summary>
        ///     Closes the connection to the device.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        private void InitRadioFrequency()
        {
            BaseRFID.Antenna = true;

            // Re-route events to use ours instead.
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

        private void LEDOnDetectingTagLost(object sender, TagEventArgs tagEventArgs)
        {
            BaseRFID.LED = false;
        }

        private void LEDOnDetectingTag(object sender, TagEventArgs tagEventArgs)
        {
            BaseRFID.LED = true;
        }

        /// <summary>
        ///     Hits when a tag is being detected.
        /// </summary>
        public event EventHandler<Events.TagEventArgs> Tag;

        /// <summary>
        ///     Hits when a device is connected.
        /// </summary>
        public event EventHandler<DeviceAttachedStateEventArgs> Attached;

        protected virtual void OnAttached(DeviceAttachedStateEventArgs e)
        {
            EventHandler<DeviceAttachedStateEventArgs> handler = Attached;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnTag(Events.TagEventArgs e)
        {
            EventHandler<Events.TagEventArgs> handler = Tag;
            if (handler != null)
                Task.Factory.StartNew(() => handler(this, e));
        }

        /// <summary>
        ///     Hits when a tag is no longer detected.
        /// </summary>
        public event EventHandler<Events.TagEventArgs> TagLost;

        protected virtual void OnTagLost(Events.TagEventArgs e)
        {
            EventHandler<Events.TagEventArgs> handler = TagLost;
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        ///     Blocks execution of further code until a Phidget RFID device is attached.
        /// </summary>
        public void WaitForAttachment()
        {
            BaseRFID.waitForAttachment();
        }

        /// <summary>
        ///     Writes to an in-range tag when it's writable.
        /// </summary>
        /// <param name="value"></param>
        public void Write(string value)
        {
            BaseRFID.write(value, P.RFID.RFIDTagProtocol.EM4100, false);
        }

        /// <summary>
        ///     Writes to an in-range tag when it's writable and makes the tag unwritable afterwards.
        /// </summary>
        /// <param name="value"></param>
        public void WriteLock(string value)
        {
            BaseRFID.write(value, P.RFID.RFIDTagProtocol.EM4100, true);
        }

        /// <summary>
        ///     Closes the connection to the device.
        /// </summary>
        public void Close()
        {
            BaseRFID.Antenna = false;
            BaseRFID.LED = false;
            BaseRFID.close();
        }
    }
}