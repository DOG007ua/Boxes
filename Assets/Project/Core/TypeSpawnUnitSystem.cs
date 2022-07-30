using System.Collections.Generic;
using Project.Game.Scripts.UnitFolder.Shoot;

namespace Project.Core
{
    public class TypeSpawnUnitSystem : ITypeSpawnUnitSystem
    {
        private int maxUnits = 10;
        private List<int> amountUnitsInLevel = new List<int>()
        {
            1,2,3,6,6,7
        };

        private List<TypeGun> typeGunInLevel = new List<TypeGun>()
        {
            TypeGun.Green, TypeGun.Blue, TypeGun.Red
        };
        
        public List<DataSpawnUnit> GetUnitsInLevel(int level)
        {
            var amountUnits = AmountUnits(level);
            List<DataSpawnUnit> listDataUnits = new List<DataSpawnUnit>();
            
            for (int i = 0; i < amountUnits; i++)
            {
                var dataUnit = new DataSpawnUnit(TypeUnits.DefaultBot, GunInLevel(level));
                listDataUnits.Add(dataUnit);
            }
            
            return listDataUnits;
        }

        private int AmountUnits(int level)
        {
            int amountUnits = 0;
            if (level < amountUnitsInLevel.Count)
            {
                amountUnits =  amountUnitsInLevel[level];
            }
            else
            {
                amountUnits = maxUnits;
            }

            return amountUnits;
        }

        private TypeGun GunInLevel(int level)
        {
            TypeGun typeGun = TypeGun.Green;
            if (level < typeGunInLevel.Count)
            {
                typeGun =  typeGunInLevel[level];
            }
            else
            {
                typeGun = TypeGun.Red;
            }

            return typeGun;
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