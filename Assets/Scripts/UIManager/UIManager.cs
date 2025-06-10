using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject interactMessageObj;

    // Thêm các panel cho pause menu và setting
    public GameObject pauseMenuPanel;
    public GameObject settingPanel;
    public GameObject respawnPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
    }

    public void ShowInteractMessage(string message)
    {
        interactMessageObj.SetActive(true);
    }

    public void HideInteractMessage()
    {
        interactMessageObj.SetActive(false);
    }

    // ====== Pause Menu ======
    public void TogglePauseMenu()
    {
        bool isActive = pauseMenuPanel.activeSelf;
        pauseMenuPanel.SetActive(!isActive);
        Time.timeScale = isActive ? 1f : 0f;
    }

    public void OnResumeButton()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnSettingButton()
    {
        pauseMenuPanel.SetActive(false);
        if (settingPanel != null)
            settingPanel.SetActive(true);
    }

    public void OnBackFromSettingButton()
    {
        if (settingPanel != null)
            settingPanel.SetActive(false);
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(true);
    }

    public void OnBackToMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Đổi tên scene cho đúng
    }

    public void OnQuitButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    // ====== Respawn Panel ======
    public void ShowRespawnPanel()
    {
        if (respawnPanel != null)
            respawnPanel.SetActive(true);
    }

    public void HideRespawnPanel()
    {
        if (respawnPanel != null)
            respawnPanel.SetActive(false);
    }

    public void OnRespawnButton()
    {
        // Hồi sinh player
        var player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.transform.position = player.LastCheckpointPosition;
            var stats = player.GetComponentInChildren<Stats>();
            if (stats != null)
                stats.RestoreFullHealth();
            player.gameObject.SetActive(true);
        }
        HideRespawnPanel();
    }
}