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
        private List<Tile> neighbors;
        private IOccupant currentOccupant;
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
            get
            {
                return currentOccupant;
            }
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
            //Temporary, obviously getting all objects with this tag, doesn't guarantee it to be a neighbor.
            GameObject[] neighborTiles = GameObject.FindGameObjectsWithTag("Tile");
            neighbors = new List<Tile>();
            foreach (var neighbor in  neighborTiles)
            {
                addNeighbor(neighbor.GetComponent<Tile>());
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

        public void addEffect()
        {
            //TODO
        }

        //Called on initialization
        public void addNeighbor(Tile neighbor)
        {
            //TODO
            if (!neighbors.Contains(neighbor))
                neighbors.Add(neighbor);
        }


        void dealDamage(AttackInfo info)
        {
            //TODO
        }

        void OnMouseOver()
        {
            //Selecting tile.
            if (Input.GetMouseButtonDown(0))
            {
                //temporary, more than just neighbors will be allowed to move to if a unit has a higher move stat.
                foreach (var x in neighbors)
                {
                    //Finding occupant that's been selected among neighboring tiles.
                    if (x.occupant != null && x.occupant.selected)
                    {
                        //Goes to tile,(Temporary, in future will check if valid move first and all that jazz.
                        enterTile(x.occupant);
                        break;
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //Because not sure how else Tiles will know of Occupants initially, just writing this temporarily for testing.
            if (other.CompareTag("Unit") && other.GetComponent<IOccupant>().tile == null)
            {
                //Only for start because swapping occupants via another method other ways, and OnTrigger is unreliable
                //since Units will overlap inbetween tiles as it traverses to destination tile, don't want to execute
                //any lines don't need to execute. Changing occupants of tiles when not staying on that tile for that movement
                //is pointless.
                IOccupant occupant = other.GetComponent<IOccupant>();
                currentOccupant = occupant;
                other.GetComponent<Unit>().tile = this;
            }

        }

        public void enterTile(Entity.IOccupant newOccupant)
        {
            newOccupant.gameObject.GetComponent<Unit>().destination = this;
            newOccupant.gameObject.GetComponent<Unit>().readyToMove = true;  
            currentOccupant = newOccupant;
            //TODO
        }

        public void exitTile()
        {
            //TODO
            currentOccupant = null;
        }

        public List<Tile> getNeighbors()
        {
            //TODO
            return neighbors;
        }
    }
}
