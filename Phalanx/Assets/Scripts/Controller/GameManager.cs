using UnityEngine;
using System.Collections.Generic;
using Olympus.Phalanx.Map;
using System;

namespace Olympus.Phalanx.Controller
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private GameInfo gameInfo;
        private GameState active;
        private Dictionary<int, GameState> gameStates;

        private MapManager mapManager;


        public static GameManager instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }


        // Use this for initialization
        void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
            initializeMap();
            initializeGameStates();
        }


        private void initializeMap()
        {
            if (mapManager == null)
            {
                mapManager = gameObject.AddComponent<MapManager>();
            }
        }

        private void initializeGameStates()
        {
            if (gameStates == null)
            {
                gameInfo = new GameInfo(this);
                gameStates = new Dictionary<int, GameState>(1);
                gameStates.Add(1, new GameStateMove(gameInfo));
                active = gameStates[1];
            }
        }

        private class GameInfo : IGame
        {
            private GameManager parent { get; set; }
            internal GameInfo(GameManager parent)
            {
                this.parent = parent;
            }
            public int activePlayer
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public MapManager mapManager
            {
                get
                {
                    return parent.mapManager;
                }
            }
        }

        public void tileClick(Tile clickedTile, Map.TileClickEventArgs args)
        {
            active.tileClick(clickedTile, args);
        }

    }
}
