using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public GameObject upgradedText;
        public Image LevelUpImage;

        public void Upgrade()
        {
            upgradedText.SetActive(true);
            LevelUpImage.gameObject.SetActive(true);
        }

    }
}