using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS.Service.Interface
{
    public interface ISettingsService
    {
        void SaveOrUpdate<T>(string key, T value);
        T Load<T>(string key, T defaultValue);
    }
}
