using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        public GameObject upgradedText;
        public Image LevelUpImage;
        private bool upgraded;

        void Start()
        {

        }

        public void Upgrade()
        {
            upgraded = true;
            upgradedText.SetActive(true);
            LevelUpImage.gameObject.SetActive(true);
        }

    }
}