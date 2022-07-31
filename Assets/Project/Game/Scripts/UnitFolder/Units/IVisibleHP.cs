namespace Project.Game.Scripts.UnitFolder.Units
{
    public interface IVisibleHP
    {
        void Initialize(float maxHP);
        void ChangeHP(float value, float HP);
    }
}