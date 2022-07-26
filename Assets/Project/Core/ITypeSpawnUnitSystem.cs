using System.Collections.Generic;

namespace Project.Core
{
    public interface ITypeSpawnUnitSystem
    {
        List<TypeUnits> GetUnitsInLevel(int level);
    }
}