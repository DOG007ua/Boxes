using UnityEngine;

namespace Project.Core.Spawn
{
    [CreateAssetMenu(fileName = "DataBots", menuName = "ScriptableObjects/DataBots", order = 1)]
    public class DataBotsSpawn : ScriptableObject
    {
        public GameObject prefabBots;
    }
}