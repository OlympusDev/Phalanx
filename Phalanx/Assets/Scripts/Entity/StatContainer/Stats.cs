
namespace Olympus.Phalanx.Entity.Stats
{
    public abstract class StatCollection : Systems.StatSystem.StatCollection
    {
        protected override void ConfigureStats()
        {
            CreateStat<Systems.StatSystem.StatVital>(Systems.StatSystem.StatType.Health);
            CreateStat<Systems.StatSystem.StatAttribute>(Systems.StatSystem.StatType.AttackDice);
            CreateStat<Systems.StatSystem.StatAttribute>(Systems.StatSystem.StatType.AttackBase);
            CreateStat<Systems.StatSystem.StatAttribute>(Systems.StatSystem.StatType.DefenseDice);
            CreateStat<Systems.StatSystem.StatAttribute>(Systems.StatSystem.StatType.DefenceBase);
            CreateStat<Systems.StatSystem.StatAttribute>(Systems.StatSystem.StatType.Move);
            CreateStat<Systems.StatSystem.StatAttribute>(Systems.StatSystem.StatType.Range);

            ((Systems.StatSystem.StatVital)this[Systems.StatSystem.StatType.Health]).Value = 6;
            ((Systems.StatSystem.StatVital)this[Systems.StatSystem.StatType.Health]).Max = 6;
        }
    }
}
