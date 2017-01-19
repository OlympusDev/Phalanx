namespace Olympus.Phalanx.Controller
{
    public abstract class GameState
    {
        protected IGame game { get; set; }
        protected GameState(IGame parent)
        {
            game = parent;
        }
        public abstract string debugInfo();
        public abstract void tileClick(Map.Tile clickedTile, Map.TileClickEventArgs args);
        public abstract void buttonClicked(ButtonPressEventArgs args);
    }
}
