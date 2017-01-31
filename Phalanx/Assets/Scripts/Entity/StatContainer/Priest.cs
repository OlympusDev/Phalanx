using Attribute = Systems.StatSystem.StatAttribute;
using Type = Systems.StatSystem.StatType;

namespace Olympus.Phalanx.Entity.Stats
{
    public class Priest : StatCollection
    {
        protected override void ConfigureStats()
        {
            base.ConfigureStats();
            ((Attribute)this[Type.AttackDice]).Base = 3;
            ((Attribute)this[Type.AttackBase]).Base = 0;
            ((Attribute)this[Type.DefenseDice]).Base = 0;
            ((Attribute)this[Type.DefenceBase]).Base = 0;
            ((Attribute)this[Type.Move]).Base = 2;
            ((Attribute)this[Type.Range]).Base = 1;

        }
    }
}
