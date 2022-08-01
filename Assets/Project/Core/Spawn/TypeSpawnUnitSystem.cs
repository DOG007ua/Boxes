using System.Collections.Generic;
using Project.Game.Scripts.UnitFolder.Shoot;

namespace Project.Core.Spawn
{
    public class TypeSpawnUnitSystem : ITypeSpawnUnitSystem
    {
        private int maxUnits = 10;

        private List<int> amountUnitsInLevel = new List<int>()
        {
            3, 3, 4, 5, 8, 9
        };

        private List<TypeGun> typeGunInLevel = new List<TypeGun>()
        {
            TypeGun.Green, TypeGun.Green, TypeGun.Blue, TypeGun.Red
        };

        public List<DataSpawnUnit> GetUnitsInLevel(int level)
        {
            var amountUnits = AmountUnits(level);
            var listDataUnits = new List<DataSpawnUnit>();

            for (int i = 0; i < amountUnits; i++)
            {
                var dataUnit = new DataSpawnUnit(TypeUnits.DefaultBot, GunInLevel(level));
                listDataUnits.Add(dataUnit);
            }

            return listDataUnits;
        }

        private int AmountUnits(int level)
        {
            var amountUnits = 
                level < amountUnitsInLevel.Count 
                ? amountUnitsInLevel[level] 
                : maxUnits;

            return amountUnits;
        }

        private TypeGun GunInLevel(int level)
        {
            return 
                level < typeGunInLevel.Count 
                    ? typeGunInLevel[level] 
                    : TypeGun.Red;
        }
    }


    public enum TypeUnits
    {
        DefaultBot,
        Player
    }

    public class DataSpawnUnit
    {
        public TypeUnits TypeUnit;
        public TypeGun TypeGun;

        public DataSpawnUnit(TypeUnits typeUnit, TypeGun typeGun)
        {
            TypeUnit = typeUnit;
            TypeGun = typeGun;
        }
    }
}