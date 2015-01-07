using SaS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SaS.Service
{
    public class NavigationService : INavigationService
    {
        public void NavigateTo<TViewModel>()
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(TViewModel));
        }

        public void NavigateTo<TViewModel>(object parameter)
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(TViewModel), parameter);
        }

        public void NavigateBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}
