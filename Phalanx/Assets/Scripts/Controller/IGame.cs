namespace Olympus.Phalanx.Controller
{
    public interface IGame
    {
        int activePlayer { get; set; }
        Map.MapManager mapManager { get; }

        void changeState(int v);
    }
}
