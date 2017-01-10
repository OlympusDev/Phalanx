using UnityEngine;
using System.Collections.Generic;
using Olympus.Phalanx.Map;
using System;

namespace Olympus.Phalanx.Controller
{
    public class GameManager : MonoBehaviour
    {
        private GameInfo gameInfo;
        private GameState activeGameState;
        private Dictionary<int, GameState> gameStates;

        [SerializeField]
        private GameObject _entity;

        private MapManager mapManager;


        public static GameManager instance
        {
            get;
            private set;
        }


        // Use this for initialization
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
            initializeGameStates();
        }

        void Start()
        {
            initializeMap();

            //Unit setup - placeholder
            GameObject entity = Instantiate(_entity);
            Entity.IOccupant unit = entity.GetComponentInChildren<Entity.Unit>();
            unit.tile = mapManager[new Point(5, 5)];
            mapManager.tileClickEvent += tileClick;
        }


        private void initializeMap()
        {
            if (!(mapManager = MapManager.instance))
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
                activeGameState = gameStates[1];
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
            activeGameState.tileClick(clickedTile, args);
        }

    }
}
