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
        System.Threading.Tasks.Task ShowDialogAsync(string message);
        System.Threading.Tasks.Task ShowDialogAsync(string message, string title);
        System.Threading.Tasks.Task ShowDialogAsync(string message, string title, List<UICommand> commands);
    }
}
