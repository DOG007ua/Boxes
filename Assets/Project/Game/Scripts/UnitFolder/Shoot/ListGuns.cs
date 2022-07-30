using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Shoot
{
    [CreateAssetMenu(fileName = "DataGuns", menuName = "ScriptableObjects/DataGuns", order = 2)]
    public class ListGuns : ScriptableObject
    {
        public List<DataGun> Gun;
    }
}