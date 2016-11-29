using UnityEngine;
using System.Collections;

public interface Occupant {
    
    Tile occupying{ get; set; }
    int team { get; }

    Skill this[int index]{get;}

    Skill[] getSkills();
    void dealDamage(AttackInfo info);
    void addEffect();

}
