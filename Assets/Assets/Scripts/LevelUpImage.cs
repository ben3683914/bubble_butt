using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class LevelUpImage : MonoBehaviour
    {

        Animator animator;

        private string triggerName = "levelUp";
        // Use this for initialization
        void Start()
        {
            Animator animator = GetComponent<Animator>();

        }

        void OnEnable()

        {
            animator.SetTrigger(triggerName); // Set the trigger when the GameObject is enabled

        }
    }
}