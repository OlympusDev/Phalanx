using UnityEngine;
using System.Collections.Generic;
using Olympus.Phalanx.Entity;

namespace Olympus.Phalanx.Map
{
    public class Tile : MonoBehaviour
    {
        private ICollection<Tile> neighbors = new List<Tile>();

        private Point _position;
       
        public bool this[Tile neighbor]
        {
            get
            {
                foreach (Tile t in neighbors)
                {
                    if (t == neighbor)
                        return true;
                }
                return false;
            }
        }

        public IOccupant occupant
        {//TODO
            get;
            set;
        }

        public TerrainType terrain
        {//TODO
            get { return null; }
        }

        public int x
        {//TODO
            get { return _position.x; }
            set { _position.x = value; }
        }

        public int y
        {//TODO
            get { return _position.y; }
            set { _position.y = value; }
        }

        public Point position
        {
            
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        void OnMouseUpAsButton()
        {
            Controller.GameManager.instance.tileClick(this, null);
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
            if (!neighbors
                .Contains(neighbor))
                neighbors.Add(neighbor);
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
