using System.Collections.Generic;

namespace Project.Core
{
    public class TypeSpawnUnitSystem
    {
        private int maxUnits = 10;
        private List<int> listAmountUnits = new List<int>()
        {
            3,4,5,6,6,7
        };
        
        public List<TypeUnits> GetUnitsInLevel(int level)
        {
            List<TypeUnits> listUnits = new List<TypeUnits>();
            int amountUnits = 0;
            if (level < listAmountUnits.Count)
            {
                amountUnits =  listAmountUnits[level];
            }
            else
            {
                amountUnits = maxUnits;
            }

            for (int i = 0; i < amountUnits; i++)
            {
                listUnits.Add(TypeUnits.Default);
            }
            
            return listUnits;
        }
    }


    public enum TypeUnits
    {
        Default
    }
}