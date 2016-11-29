using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour, Occupant
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

    public Skill this[int index] { get { return null; } }

    public Skill[] getSkills()
    {
        //TODO
        return null;
    }
    public void dealDamage(AttackInfo info)
    {

    }
    public void addEffect()
    {

    }
    #endregion
}
