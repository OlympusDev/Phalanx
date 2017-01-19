using Olympus.Phalanx.Map;
using UnityEngine;

namespace Olympus.Phalanx.Controller
{
    public class GameStateMove : GameState
    {
        private Tile activeTile;
        private Entity.Unit selectedUnit;

        public GameStateMove(IGame parent) : base(parent)
        {
            activeTile = null;
            selectedUnit = null;
        }

        public override void tileClick(Tile clickedTile, Map.TileClickEventArgs args)
        {
            if (clickedTile.occupant != null)
            {
                if (clickedTile.occupant is Entity.Unit)
                {
                    selectedUnit = (Entity.Unit)clickedTile.occupant;
                }
                activeTile = null;
                return;
            }

            //Check for move
            if (clickedTile == activeTile)
            {
                if (selectedUnit != null)
                {
                    if (selectedUnit.tile[clickedTile]) { 
                            selectedUnit.tile = activeTile;
                    }
                }
            }
            activeTile = clickedTile;
        }
    }
}
