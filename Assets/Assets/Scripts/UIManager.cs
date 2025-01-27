using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public GameObject upgradedText;
        public Image LevelUpImage;
        public AudioClip levelUpSound;
        public AudioSource audioSource;

        public void Upgrade()
        {
            upgradedText.SetActive(true);
            LevelUpImage.gameObject.SetActive(true);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(levelUpSound);
        }

    }
}