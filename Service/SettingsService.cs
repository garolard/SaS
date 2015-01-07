using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaS.Service.Interface;

namespace SaS.Service
{
    public class SettingsService : ISettingsService
    {
        private const string SETTINGS_CONTAINER_KEY = "Linea11SettingsContainer";
        Windows.Storage.ApplicationDataContainer localSettings;

        public SettingsService()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (!localSettings.Containers.ContainsKey(SETTINGS_CONTAINER_KEY))
            {
                localSettings.CreateContainer(SETTINGS_CONTAINER_KEY, Windows.Storage.ApplicationDataCreateDisposition.Always);
            }
        }

        public void SaveOrUpdate<T>(string key, T value)
        {
            var container = localSettings.Containers[SETTINGS_CONTAINER_KEY];

            if (container.Values.ContainsKey(key))
            {
                container.Values[key] = value;
            }
            else
            {
                container.Values.Add(key, value);
            }
        }

        public T Load<T>(string key, T defaultValue)
        {
            T returnValue = defaultValue;
            var container = localSettings.Containers[SETTINGS_CONTAINER_KEY];

            if (container.Values.ContainsKey(key))
            {
                returnValue = (T)container.Values[key];
            }

            return returnValue;
        }
    }
}
