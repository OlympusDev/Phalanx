namespace Olympus.Phalanx.Controller
{
    public abstract class GameState
    {
        protected IGame game { get; set; }
        protected GameState(IGame parent)
        {
            game = parent;
        }
        public abstract void tileClick(Map.Tile clickedTile, Map.TileClickEventArgs args);
        //void buttonClicked(ButtonPressEventArgs args);
    }
}
