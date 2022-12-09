using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FlyingFlurry.GameLoop;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("Pause Buttons")]
    [SerializeField] Button ResumeBtn;
    [SerializeField] Button MuteBtn;
    [SerializeField] Button PauseMainMenuBtn;

    [Header("InGame Buttons")]
    [SerializeField] Button PauseBtn;
    [SerializeField] TextMeshProUGUI ScoreText;

    [Header("Main Menu Buttons")]
    [SerializeField] Button PlayBtn;
    [SerializeField] Button SettingsBtn;
    [SerializeField] Button ExitGameBtn;

    [Header("GameOver Buttons")]
    [SerializeField] Button PlayAgainBtn;
    [SerializeField] Button GameOverMainMenuBtn;
    [SerializeField] TextMeshProUGUI LastScore;

    [Header("Panels")]
    [SerializeField] GameObject InGamePanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject GameOverPanel;


    private void Start()
    {
        ScoreText.text = "0";

        // Pause Panel
        ResumeBtn.onClick.AddListener(() => GameManager.Instance.UpdateGameState(GameState.InGame));
        // Sound Button
        PauseMainMenuBtn.onClick.AddListener(() => GameManager.Instance.BackMainMenu());

        // InGame Panel
        PauseBtn.onClick.AddListener(() => GameManager.Instance.UpdateGameState(GameState.Pause));

        // Main Menu
        PlayBtn.onClick.AddListener(() => GameManager.Instance.StartGame());
        // Settings Button
        ExitGameBtn.onClick.AddListener(() => Application.Quit());

        // Game Over Panel
        PlayAgainBtn.onClick.AddListener(() => GameManager.Instance.StartGame());
        GameOverMainMenuBtn.onClick.AddListener(() => GameManager.Instance.BackMainMenu());
    }

    public void EnableInGamePanel()
    {
        InGamePanel.SetActive(true);

        PausePanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void EnablePausePanel()
    {
        PausePanel.SetActive(true);

        InGamePanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void EnableMainMenuPanel()
    {
        MainMenuPanel.SetActive(true);

        PausePanel.SetActive(false);
        InGamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void EnableGameOverPanel()
    {
        GameOverPanel.SetActive(true);

        PausePanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        InGamePanel.SetActive(false);
    }

    public void SetScoreText(int score)
    {
        ScoreText.text = score.ToString();
        LastScore.text = ScoreText.text;
    }
}
