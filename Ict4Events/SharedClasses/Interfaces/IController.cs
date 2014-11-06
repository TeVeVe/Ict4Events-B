using System.Collections.Generic;
using System.Windows.Forms;

namespace SharedClasses.Interfaces
{
    public interface IController
    {
        Control View { get; set; }
        bool IsPopup { get; set; }
        Dictionary<string, object> Values { get; set; }

        /// <summary>
        ///     Called on every showing of this controller.
        /// </summary>
        void Activate();
    }

    public interface IController<T> : IController where T : class
    {
        new T View { get; set; }
    }
}