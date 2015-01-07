using SaS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace SaS.Service
{
    public class InternetService : IInternetService
    {
        public bool IsConnected()
        {
            return NetworkInformation.GetInternetConnectionProfile() != null;
        }

        public InternetConnectionType GetConnectionType()
        {
            var profile = NetworkInformation.GetInternetConnectionProfile();
            var connectionType = InternetConnectionType.NO_INTERNET;
            if (profile == null)
            {
                connectionType = InternetConnectionType.NO_INTERNET;
            }

            if (profile.IsWlanConnectionProfile)
            {
                if (NetworkCostType.Fixed == profile.GetConnectionCost().NetworkCostType)
                {
                    connectionType = InternetConnectionType.WIFI_METERED;
                }
                else
                {
                    connectionType = InternetConnectionType.WIFI_UNLIMITED;
                }
            }
            
            if (profile.IsWwanConnectionProfile)
            {
                if (NetworkCostType.Fixed == profile.GetConnectionCost().NetworkCostType)
                {
                    if (profile.GetConnectionCost().Roaming)
                    {
                        connectionType = InternetConnectionType.CELL_ROAMING;
                    }
                    else if (profile.GetConnectionCost().ApproachingDataLimit)
                    {
                        connectionType = InternetConnectionType.CELL_METERED_NEAR_LIMIT;
                    }
                    else
                    {
                        connectionType = InternetConnectionType.CELL_METERED;
                    }
                }
                else
                {
                    connectionType = InternetConnectionType.CELL_UNLIMITED;
                }
            }
            if (NetworkCostType.Unknown == profile.GetConnectionCost().NetworkCostType)
            {
                connectionType = InternetConnectionType.WIFI_UNLIMITED;
            }
            return connectionType;
        }
    }
}
