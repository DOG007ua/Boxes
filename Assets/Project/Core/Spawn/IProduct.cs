using Project.Game.Scripts.UnitFolder;
using Project.Game.Scripts.UnitFolder.Units;
using UnityEngine;

namespace Project.Core.Spawn
{
    public interface IProduct
    {
        Unit Spawn(TypeUnits typeUnit);
    }
}