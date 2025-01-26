using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Assets.Scripts
{
    public class StartMenuManager : MonoBehaviour
    {
        public GameObject Panel;

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void OpenCredits()
        {
            Panel.SetActive(true);
        }

        public void CloseCredits()
        {
            Panel.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}