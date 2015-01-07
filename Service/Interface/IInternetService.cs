using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS.Service.Interface
{
    public enum InternetConnectionType
    {
        NO_INTERNET,
        WIFI_UNLIMITED,
        WIFI_METERED,
        CELL_UNLIMITED,
        CELL_METERED,
        CELL_ROAMING,
        CELL_METERED_NEAR_LIMIT
    }

    public interface IInternetService
    {
        bool IsConnected();

        /// <summary>
        /// Resuelve el tipo de conexión a internet con el que cuenta
        /// la aplicación basándose en datos del API de DataSense.
        /// </summary>
        /// <returns>Un valor del enumerado <see cref="InternetConnectionType"/></returns>
        InternetConnectionType GetConnectionType();
    }
}
