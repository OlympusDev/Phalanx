using System;
using Olympus.Phalanx.Map;
using UnityEngine;

namespace Olympus.Phalanx.Controller.States
{
    public class GameStateMove : GameState
    {
        private Tile activeTile;

        public GameStateMove(IGame parent) : base(parent)
        {
            activeTile = null;
        }

        Entity.Unit activeUnit { get; set; }

        public override string debugInfo()
        {
            string info = "Move Game State:";
            if (activeUnit != null)
            {
                info += "Entity:";
                info += activeUnit.ToString();
            }
            return info;
        }

        public override void buttonClicked(ButtonPressEventArgs args)
        {
            if(args.buttonID == ButtonID.Debug)
            {
                game.changeState(2);
            }
        }

        public override void tileClick(TileClickEventArgs args)
        {
            if (args.tile.occupant != null)
            {
                if (args.tile.occupant is Entity.Unit)
                {
                    activeUnit = (Entity.Unit)args.tile.occupant;
                }
                activeTile = null;
                return;
            }

            //Check for move
            if (args.tile == activeTile)
            {
                if (activeUnit != null)
                {
                    if (activeUnit.tile[args.tile]) { 
                            activeUnit.tile = activeTile;
                    }
                }
            }
            activeTile = args.tile;
        }
    }
}
