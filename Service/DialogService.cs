using SaS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace SaS.Service
{
    public class DialogService : IDialogService
    {
        async public Task ShowDialogAsync(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        async public Task ShowDialogAsync(string message, string title)
        {
            var dialog = new MessageDialog(message, title);
            await dialog.ShowAsync();
        }

        async public Task ShowDialogAsync(string message, string title, List<Windows.UI.Popups.UICommand> commands)
        {
            var dialog = new MessageDialog(message, title);
            foreach (UICommand command in commands)
            {
                dialog.Commands.Add(command);
            }
            await dialog.ShowAsync();
        }
    }
}
