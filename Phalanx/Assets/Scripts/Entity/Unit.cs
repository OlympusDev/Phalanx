using UnityEngine;
using System.Collections;
using Olympus.Phalanx.Map;
using System;

namespace Olympus.Phalanx.Entity
{
    public class Unit : MonoBehaviour, IOccupant
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Occupant Implementation
        #region Occupant
        public Tile occupying { get; set; }
        public int team
        {
            get
            {  //TODO
                return 0;
            }
        }

        public Tile tile
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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
