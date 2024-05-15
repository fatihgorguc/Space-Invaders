using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essentials
{
    public class GameSession : MonoBehaviour
    {
        #region Singleton
        
        public static GameSession Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        
            Instance = this;
        }
        
        #endregion
        
        private int _score;
        private TextMeshProUGUI _scoreTitle;

        public void OnSceneChange()
        {
            if (SceneManager.GetActiveScene().name == "EndGameMenu")
            {
                Debug.Log(_score);
                _scoreTitle = GameObject.Find("ScoreTitle").GetComponent<TextMeshProUGUI>();
                _scoreTitle.text = ("Score: \n" + _score);
            }
            else if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                Debug.LogWarning("sıfırla");
                _score = 0;
            }
        }
        public void AddScore(int score)
        {
            _score += score;
            Debug.Log("s:" +_score);
        }

    }
}
