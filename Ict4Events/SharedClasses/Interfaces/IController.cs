using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace SharedClasses.Interfaces
{
    public interface IController
    {
        Control View { get; set; }
    }

    public interface IController<T> : IController where T : class
    {
        new T View { get; set; } 
    }
}