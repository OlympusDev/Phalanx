using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Olympus.Phalanx.Map
{
    public abstract class TerrainType : MonoBehaviour
    {


        public int height
        {
            get
            {
                //TODO
                return 0;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public abstract bool tryMove(TargetingInfo moveInfo, TerrainType previousTerrain);
    }
}
