using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public class TileClickEventArgs : EventArgs
    {
        public Tile tile { get; private set; }
        public int instigatorID { get; private set; }

        public TileClickEventArgs(Tile tile, int instigator)
        {
            this.tile = tile;
            this.instigatorID = instigator;
        }
    }
}
