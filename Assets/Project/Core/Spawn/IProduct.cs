using Project.Game.Scripts.UnitFolder;
using UnityEngine;

namespace Project.Core.Spawn
{
    public interface IProduct
    {
        Unit Spawn();
    }
}