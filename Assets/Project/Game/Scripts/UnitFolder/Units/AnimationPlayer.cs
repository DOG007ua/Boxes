using UnityEngine;

namespace Project.Game.Scripts.UnitFolder.Units
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animation animations;

        public void Reload()
        {
            animations.Play("Reload");
        }

        public void FinishReload()
        {
            animations.Play("FinishReload");
        }
    }
}