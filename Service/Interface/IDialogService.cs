using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SaS.Service.Interface
{
    public interface IDialogService
    {
        void ShowDialogAsync(string message);
        void ShowDialogAsync(string message, string title);
        void ShowDialogAsync(string message, string title, List<UICommand> commands);
    }
}
