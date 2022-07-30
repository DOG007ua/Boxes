using System.Collections.Generic;

namespace Project.Core
{
    public interface ITypeSpawnUnitSystem
    {
        List<DataSpawnUnit> GetUnitsInLevel(int level);
    }
}