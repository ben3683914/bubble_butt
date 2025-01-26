using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        public GameObject Panel;

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void GameOver()
        {
            SceneManager.LoadScene(2);
        }

        public void Congratulations()
        {
            SceneManager.LoadScene(3);
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