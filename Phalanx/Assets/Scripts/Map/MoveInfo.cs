using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public class MoveInfo
    {

        public int moves { get; private set; }
        public MoveType type { get; private set; }
        public MoveInfo from { get; private set; }
        public Tile tile { get; private set; }

        public MoveInfo(int moves, MoveType type,Tile tile)
        {
            this.moves = moves;
            this.type = type;
            this.tile = tile;
            from = this; //If origin
        }

        public MoveInfo(int moves, MoveType type,Tile tile,MoveInfo parent)
        {
            this.moves = moves;
            this.type = type;
            this.tile = tile;
            from =  parent; //remember who its moving from
        }

        public MoveInfo Move(Tile destination)
        {
            return new MoveInfo(moves - 1, type, destination, this);
        }
        public bool better(MoveInfo info)
        {
            //TODO
            //Comparison
            //true if more moves left in this than info
            //Posibly add 
            return this.moves>info.moves;
        }
    }
    public enum MoveType
    {
        Walk = 0x0000,
        Tank = 0x0001,
        Attack = 0x0100
    }
}
