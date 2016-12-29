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
        private Tile occupying;
        private float timeStartedMovement;
        private float distanceToNextTile;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (target != null)
                move();
        }

        public void move()
        {
            if (transform.position != target.transform.position)
            {
                Debug.Log("Moving");
                float timeSinceLastMovement = Time.time - timeStartedMovement;
                float fractionTravelled = timeSinceLastMovement / distanceToNextTile;
                transform.position = Vector3.Lerp(tile.transform.position, target.transform.position, fractionTravelled);
            }
            else
            {
                //Switch to currently occupying tile to this one
                //tile.selected = false;
                tile.exitTile();
                tile = target;
                target = null;
            }
        }
       
        void OnMouseOver()
        {
            //Select the unit
            if (Input.GetMouseButtonDown(0))
            {
                //Tile needs a selected property, that will be set when mouse over occupant on tile or tile.
                //Then once selected, Tile needs to check for the occupant on it(if there is one)
                //Then enterTile and exitTile need to be implemented to give destination value and swap what tile occupant
                //is currently occupying.

                //With this call Tile is selected, checks for occupant and transfers the instructions for occupant to do.
                //occupying.selected = true
            }
        }

       
        //Tile targeting for action, attacking/movement
        public Tile target { set; get;}
        //Occupant Implementation

        #region Occupant
        public int team
        {
            get
            {  //TODO
                return 0;
            }
        }

        //Tile occupying
        public Tile tile
        {
            get
            {
                return occupying;
            }
            set
            {
                //Doesn't need to move from tile to another tile if there is no current tile.
                if (occupying != null)
                {
                    timeStartedMovement = Time.time;
                    distanceToNextTile = (occupying.transform.position - target.transform.position).magnitude;
                }
                occupying = value;
            }
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
