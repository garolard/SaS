using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaS.Service.Interface;
using Windows.UI.StartScreen;

namespace SaS.Service
{
    public class TilesService : ITilesService
    {
        public async Task PinSecondaryTileAsync(string tileId, string displayName, string activationArgs, Uri tileLogo, Windows.UI.StartScreen.TileSize desiredSize)
        {
            SecondaryTile secondaryTile = new SecondaryTile(tileId,
                                                            displayName,
                                                            activationArgs,
                                                            tileLogo,
                                                            desiredSize);
            secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await secondaryTile.RequestCreateAsync();
        }
    }
}
