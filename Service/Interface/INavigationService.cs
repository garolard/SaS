using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS.Service.Interface
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>();
        void NavigateTo<TViewModel>(object parameter);
        void NavigateBack();
    }
}
