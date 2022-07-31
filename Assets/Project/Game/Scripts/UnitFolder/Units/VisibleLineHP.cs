using UnityEngine;
using UnityEngine.UI;

namespace Project.Game.Scripts.UnitFolder.Units
{
    public class VisibleLineHP : MonoBehaviour, IVisibleHP
    {
        [SerializeField] private Image bar;
        private float maxHP;

        public void Initialize(float maxHP)
        {
            this.maxHP = maxHP;
        }

        public void ChangeHP(float value, float HP)
        {
            bar.fillAmount = HP / maxHP;
        }
    }
}