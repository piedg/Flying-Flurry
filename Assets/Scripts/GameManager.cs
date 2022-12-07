using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using FlyingFurry.Player;

namespace FlyingFurry.GameLoop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject StartPanel;
        [SerializeField] GameObject GameOverPanel;

        [SerializeField] TextMeshProUGUI scoreText;

        PlayerController player;
        bool isPlaying;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        private void Start()
        {
            //Time.timeScale = 0;
            isPlaying = false;
            //  StartPanel.SetActive(true);
            //  GameOverPanel.SetActive(false);
            //  scoreText.gameObject.SetActive(false);
        }

        private void Update()
        {
            //scoreText.text = player.Score.ToString();
            if (player.IsDead)
            {
                GameOver();
            }
        }

        public void PlayButton()
        {
            Time.timeScale = 1;
            isPlaying = true;
            // StartPanel.SetActive(false);
            // scoreText.gameObject.SetActive(true);
        }

        public void RestartGame()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene("MainMenu");
        }

        void GameOver()
        {
            Time.timeScale = 0;
            isPlaying = false;
            //GameOverPanel.SetActive(true);
        }
    }
}
