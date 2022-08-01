using UnityEngine;
using UnityEngine.UI;

namespace Project.Core
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Text Level;

        /*void Update()
        {
            UpdateText(GameStatusInstance.Instance.Level);
        }*/
        
        public void ChangeLevel(int level)
        {
            UpdateText(level);
        }

        private void UpdateText(int level)
        {
            Level.text = $"Level: {level + 1}";
        }
    }
}