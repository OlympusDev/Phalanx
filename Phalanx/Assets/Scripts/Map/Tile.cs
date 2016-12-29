using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Olympus.Phalanx.Entity;

namespace Olympus.Phalanx.Map
{

    public class Tile : MonoBehaviour
    {
        //NOTE: All my changes to tile are temporary for me to test, except for enterTile, though feel free to change as
        //see fit.
        bool this[Tile neighbor]
        {
            get
            {
                //TODO
                return false;
            }
        }

        public IOccupant occupant
        {//TODO
            get { return null; }
        }

        public TerrainType terrain
        {//TODO
            get { return null; }
        }

        public int x
        {//TODO
            get { return 0; }
            set { }
        }
        public int y
        {//TODO
            get { return 0; }
            set { }
        }

        private void Awake()
        {
           
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void addEffect()
        {
            //TODO
        }

        //Called on initialization
        public void addNeighbor(Tile neighbor)
        {
            //TODO
        }


        void dealDamage(AttackInfo info)
        {
            //TODO
        }
       
        public void enterTile(Entity.IOccupant newOccupant)
        {

            //TODO
        }

        public void exitTile()
        {
            //TODO
        }

        public Tile[] getNeighbors()
        {
            return null; 
            //TODO
        }
    }
}
