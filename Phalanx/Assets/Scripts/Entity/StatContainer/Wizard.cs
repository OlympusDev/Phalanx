
namespace Olympus.Phalanx.Entity.Stats
{
    public class Wizatd : StatCollection
    {
        protected override void ConfigureStats()
        {
            base.ConfigureStats();
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.AttackDice]).Base = 4;
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.AttackDice]).Base = 4;
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.AttackBase]).Base = 1;
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.DefenseDice]).Base = 0;
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.DefenceBase]).Base = 0;
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.Move]).Base = 2;
            ((Systems.StatSystem.StatAttribute)this[Systems.StatSystem.StatType.Range]).Base = 2;

        }
    }
}
