using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Controller
{
    public interface IGameState
    {
        void tileClick(Map.Tile clickedTile, Map.TileClickEventArgs args);
        //void buttonClicked(ButtonPressEventArgs args);
    }
}
