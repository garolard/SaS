using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace SaS.Service.Interface
{
    public interface ITilesService
    {
        /// <summary>
        /// Ancla a la pantalla de inicio un Tile Secundario.
        /// </summary>
        /// <param name="tileId">Id para el Tile Secundario.</param>
        /// <param name="displayName">El nombre a mostrar en el Tile.</param>
        /// <param name="activationArgs">Argumentos de activación.</param>
        /// <param name="tileLogo">Imagen que se mostrará en el Tile Secundario.</param>
        /// <param name="desiredSize">Tamaño por defecto preferido para el Tile.</param>
        /// <returns>Una <see cref="System.Threading.Task"/> vacía.</returns>
        Task PinSecondaryTileAsync(string tileId, string displayName, string activationArgs, Uri tileLogo, TileSize desiredSize);
    }
}
