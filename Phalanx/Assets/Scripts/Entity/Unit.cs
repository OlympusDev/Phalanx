using UnityEngine;
using System.Collections;
using Olympus.Phalanx.Map;
using System;

namespace Olympus.Phalanx.Entity
{
    public class Unit : MonoBehaviour, IOccupant
    {
        //need time since last moved.
        //Need destination Tile .

        private float timeStartedMovement;
        private float distanceToNextTile;
        private bool canMove;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (canMove)
                move();
        }

        public void move()
        {
            //Why does is it giving me null reference? I break pointed to it and clearly is there and correct val
            if (transform.position != destination.transform.position)
            {
                Debug.Log("Moving");
                float timeSinceLastMovement = Time.time - timeStartedMovement;
                float distanceToMovePerFrame = timeSinceLastMovement / distanceToNextTile;
                transform.position = Vector3.Lerp(tile.transform.position, destination.transform.position, distanceToMovePerFrame);
            }
            else
            {
                //Switch to currently occupying tile to this one
                canMove = false;
                selected = false;
                tile.exitTile();
                tile = destination;
                destination = null;
            }
        }
        public bool readyToMove
        {
            //This set is only for outsiders when rdy to move.
            set
            {
                canMove = value;
                timeStartedMovement = Time.time;
                distanceToNextTile = (tile.transform.position - destination.transform.position).magnitude;
            }
           
        }
        void OnMouseOver()
        {
            //Select the unit
            if (Input.GetMouseButtonDown(0))
            {
                selected = true;
            }
        }

       
        public Tile destination { set; get;}
        //Occupant Implementation

        #region Occupant
        public int team
        {
            get
            {  //TODO
                return 0;
            }
        }
        public bool selected { set; get; }

        //Tile occupying
        public Tile tile
        {
            get;

            set;
        }
    
        public AttackInfo attack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Skill this[int index] { get { return null; } }

        public Skill[] getSkills()
        {
            //TODO
            return null;
        }
        public void dealDamage(AttackInfo info)
        {
            //TODO
        }
        public void addEffect()
        {
            //TODO
        }

        public void damage(AttackInfo info)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
