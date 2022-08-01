using System.Collections.Generic;

namespace Project.Core.Spawn
{
    public interface ITypeSpawnUnitSystem
    {
        List<DataSpawnUnit> GetUnitsInLevel(int level);
    }
}