using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOver : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    
    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
        _group.alpha = 0;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
    }

    private void OnEnable()
    {
        _player.HasDied += OnPlayerDeath;
        _restartButton.onClick.AddListener(OnRestartButton);
        _exitButton.onClick.AddListener(OnExitButton);
    }

    private void OnDisable()
    {
        _player.HasDied -= OnPlayerDeath;
        _restartButton.onClick.RemoveListener(OnRestartButton);
        _exitButton.onClick.RemoveListener(OnExitButton);
    }

    private void OnPlayerDeath()
    {
        _restartButton.interactable = true;
        _exitButton.interactable = true;
        _group.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButton()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
