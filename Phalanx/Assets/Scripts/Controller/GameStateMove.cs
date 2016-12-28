using Olympus.Phalanx.Map;

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
                    //placeholder neighbor check because
                    //bool Tile[Tile neighbor] is not public
                    foreach (Tile t in selectedUnit.tile.getNeighbors())
                    {
                        if (t == activeTile)
                        {
                            //figure out who tells the tiles to update its occupants
                            //selectedUnit.tile.occupant = null;
                            selectedUnit.tile = activeTile;

                        }
                    }
                }
            }
            activeTile = clickedTile;
        }
    }
}
