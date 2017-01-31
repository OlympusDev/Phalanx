using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Olympus.Phalanx.Map;
using System;
using StatSystem = Systems.StatSystem;

namespace Olympus.Phalanx.Entity
{
    [RequireComponent(typeof(Stats.StatCollection))]
    public class Unit : Systems.EntitySystem.Entity, IOccupant
    {
        private Tile occupying;

        protected override void Awake()
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

        public void move(IList<Tile> moveOrder)
        {
            foreach(Tile t in moveOrder)
                Debug.Log("moving to "+ t.position.ToString());
            //TODO: method for moving units
        }


        //To upgrade for movement:
        //Take in a collection of tiles that shows movement path.
        //Possibly call MapManager for the path.
        private IEnumerator move(Vector3 startingPos,
            Vector3 endingPos,
            float timeStartedTravelling,
            float timeToTravel)
        {
            while (transform.position != endingPos)
            {
                UnityEngine.Debug.Log("Moving");
                float timeSinceLastMovement = Time.time - timeStartedTravelling;
                float fractionTravelled = timeSinceLastMovement / timeToTravel;
                transform.position = Vector3.Lerp(startingPos, endingPos, fractionTravelled);
                yield return new WaitForEndOfFrame();
            }
        }

        public override string ToString()
        {
            string text = base.ToString();
            text += "\nStats: \n" + Stats.ToString();
            return text;
        }

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
                    StartCoroutine(move(
                        occupying.transform.position,
                        value.transform.position,
                        Time.time,
                        5.0f));
                    occupying.occupant = null;
                }
                else
                {
                    transform.position = value.transform.position;
                }
                occupying = value;
                occupying.occupant = this;
            }
        }

        //TODO
        //Returns info about the "basic" attack that a character makes
        public AttackInfo attack
        {
            get
            {
                return new AttackInfo(
                    GetStat<StatSystem.Stat>(StatSystem.StatType.AttackDice).Value,
                    GetStat<StatSystem.Stat>(StatSystem.StatType.AttackBase).Value,
                    0,//TODO get Height From Tile
                    0,//TODO define Attack Types
                    null);
            }
        }

        public OccupantInfo info
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

        public void addEffect()
        {
            //TODO
        }

        public void damage(AttackInfo info)
        {
            int damage = info.attackBase;
            int defenseRolls = GetStat<Systems.StatSystem.Stat>(Systems.StatSystem.StatType.DefenseDice).Value;
            damage -= GetStat<Systems.StatSystem.Stat>(Systems.StatSystem.StatType.DefenceBase).Value;

            for (int i = 0; i < info.attackRoll; i++)
            {
                if (UnityEngine.Random.Range(1, 6 + 1) >= 5)
                {
                    damage++;
                }
            }
            for (int i = 0; i < defenseRolls; i++)
            {
                if (UnityEngine.Random.Range(1, 6 + 1) >= 4)
                {
                    damage--;
                }
            }
            GetStat<Systems.StatSystem.StatVital>(Systems.StatSystem.StatType.Health).Value -= (damage > 0 ? damage : 0);
        }
        #endregion
    }
}
