using System;
using UnityEngine;
using FlyingFlurry.Player;
using FlyingFlurry.Gameplay;

namespace FlyingFlurry.GameLoop
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameState State;

        PlayerController Player;
        ObstacleSpawner ObstacleSpawner;

        private void Start()
        {
            Player = FindObjectOfType<PlayerController>();
            ObstacleSpawner = FindObjectOfType<ObstacleSpawner>();

            UpdateGameState(GameState.MainMenu);
        }

        private void Update()
        {
            UIManager.Instance.SetScoreText(Player.Score);

            if(Player.IsDead)
            {
                UpdateGameState(GameState.GameOver);
            }
        }

        public void UpdateGameState(GameState newState)
        {
            State = newState;

            switch(newState)
            {
                case GameState.InGame:
                    HandleInGame();
                    break;

                case GameState.Pause:
                    HandlePause();
                    break;

                case GameState.MainMenu:
                    HandleMainMenu();
                    Player.Score = 0;

                    break;

                case GameState.GameOver:
                    HandleGameOver();

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }

        void HandleInGame()
        {
            Time.timeScale = 1;

            UIManager.Instance.EnableInGamePanel();
        }

        void HandlePause()
        {
            Time.timeScale = 0;

            UIManager.Instance.EnablePausePanel();
        }

        void HandleMainMenu()
        {
            Time.timeScale = 1;

            UIManager.Instance.EnableMainMenuPanel();
            ObstacleSpawner.SpawnActive = false;
            Player.gameObject.SetActive(false);
        }

        void HandleGameOver()
        {
            Time.timeScale = 0;

            UIManager.Instance.EnableGameOverPanel();
        }

        public void StartGame()
        {
            UpdateGameState(GameState.InGame);

            ObstacleSpawner.SpawnActive = true;
            ObstacleSpawner.ResetObstacles();
            Player.Respawn();
            Player.gameObject.SetActive(true);
        }

        public void BackMainMenu()
        {
            UpdateGameState(GameState.MainMenu);

            ObstacleSpawner.ResetObstacles();
            Player.gameObject.SetActive(false);
            Player.IsDead = false;
        }
    }
}

public enum GameState
{
    InGame,
    Pause,
    GameOver,
    MainMenu
}