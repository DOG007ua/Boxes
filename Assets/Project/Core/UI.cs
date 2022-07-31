using UnityEngine;
using UnityEngine.UI;

namespace Project.Core
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Text Level;

        
        public void ChangeLevel(int level)
        {
            Level.text = $"Level: {level + 1}";
        }
    }
}