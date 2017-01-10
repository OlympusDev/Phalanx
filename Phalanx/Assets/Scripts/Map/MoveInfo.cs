using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public class MoveInfo
    {

        public int moves { get; set; }
        public MoveType type { get; private set; }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public MoveInfo(int moves, MoveType type)
        {
            //TODO
        }
        public MoveInfo memoize()
        {
            //TODO
            //makes copy
            return null;
        }
        public bool better(MoveInfo info)
        {
            //TODO
            //Comparison
            //true if more moves left in this than info
            return false;
        }

    }
    public enum MoveType
    {
        Standard = 0
    }
}
