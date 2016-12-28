using UnityEngine;
using System.Collections.Generic;
using Olympus.Phalanx.Entity;

namespace Olympus.Phalanx.Map
{
    public class Tile : MonoBehaviour
    {
    ICollection<Tile> neighbors = new List<Tile>();

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
        
    //Called on initialization
    public void addNeighbor(Tile neighbor)
    {
        if(!neighbors
            .Contains(neighbor))
        neighbors.Add(neighbor);
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
            //TODO
            return null;
        }
    }
}
