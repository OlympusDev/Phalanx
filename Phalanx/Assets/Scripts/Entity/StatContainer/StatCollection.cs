using Attribute = Systems.StatSystem.StatAttribute;
using Type = Systems.StatSystem.StatType;

namespace Olympus.Phalanx.Entity.Stats
{
    public abstract class StatCollection : Systems.StatSystem.StatCollection
    {
        protected override void ConfigureStats()
        {
            CreateStat<Systems.StatSystem.StatVital>(Type.Health).Name = "Health";
            CreateStat<Attribute>(Type.AttackDice).Name = "Attack";
            CreateStat<Attribute>(Type.AttackBase).Name = "Base Attack";
            CreateStat<Attribute>(Type.DefenseDice).Name = "Defense";
            CreateStat<Attribute>(Type.DefenceBase).Name = "Base Defense";
            CreateStat<Attribute>(Type.Move).Name = "Move";
            CreateStat<Attribute>(Type.Range).Name = "Range";

            ((Systems.StatSystem.StatVital)this[Type.Health]).Value = 5;
            ((Systems.StatSystem.StatVital)this[Type.Health]).Max = 5;
        }
    }
}
