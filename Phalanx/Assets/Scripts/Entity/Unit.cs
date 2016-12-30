using UnityEngine;
using System.Collections;
using Olympus.Phalanx.Map;
using System;

namespace Olympus.Phalanx.Entity
{
    //To upgrade for movement: Make it so if moves diagonal, keeps track and counts as two moves, though think MoveInfo
    //already does that, what's set up is just set to move it to spot when all the checking has been done, also needs to be fixed
    // if moving to block in distances doesn't go through obstacles/walls, but again that's more checking that needs to be finished
    //first.
    public class Unit : MonoBehaviour, IOccupant
    {
        private Tile occupying;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            
        }


      

        //If they have to click tile to select tile and selecting character won't select it then feel free to remove this
        void OnMouseOver()
        {
            //Selecting Unit image will set to selecting Tile and tile will get occupant's info to show.
            if (Input.GetMouseButtonDown(0))
            {

                //Tile needs a selected property, that will be set when mouse over occupant on tile or tile.
                //Then once selected, Tile needs to check for the occupant on it(if there is one)
                //Then enterTile and exitTile need to be implemented to what tile occupant
                //is currently occupying.

                //With this call Tile is selected, checks for occupant and transfers the instructions for occupant to do.
                //occupying.selected = true
            }
            //Guessing just hovering will also show info so Todo: need to add that.
        }

       
        //Tile targeting for action, attacking/movement
        //Edit: With changes made, don't need target property for moving
        //Leaving here just incase need for attacking, from what I've gathered for what we have, we attack tiles
        //the attack transfers to occupant of attaccked tile accordingly if one exists.
        public Tile target { set; get;}
        //Occupant Implementation
        public IEnumerator move(Vector3 startingPos, Vector3 endingPos, float distanceToTravel, float timeStartedTravelling)
        {
            while (transform.position != endingPos)
            {
                Debug.Log("Moving");
                float timeSinceLastMovement = Time.time - timeStartedTravelling;
                float fractionTravelled = timeSinceLastMovement / distanceToTravel;
                transform.position = Vector3.Lerp(startingPos, endingPos, fractionTravelled);
                yield return new WaitForEndOfFrame();
            }
        }
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
                    float distanceToTargetTile = (occupying.transform.position -value.transform.position).magnitude;
                    StartCoroutine(move(occupying.transform.position, value.transform.position, distanceToTargetTile, Time.time));
                }
                occupying = value;
            }
        }
    
        //Why is attack a property? Doesn't it fit more as a method, since it's something it does, not has.
        //Unless this is attacks it can do, and Tile gets this info to deal appropriate damage, then okay that makes sense
        //Then since both have deal damage, Guessing Tile's dealDamage has extra logic with checking target tile, then Unit's dealDamage method
        //handles the effect on Unit.
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
