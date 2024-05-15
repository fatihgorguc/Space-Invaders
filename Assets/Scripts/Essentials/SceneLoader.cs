using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essentials
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
