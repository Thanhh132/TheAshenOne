using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButton()
    {
        // Đổi "Game" thành tên scene gameplay của bạn
        SceneManager.LoadScene("GamePlayScene");
        Debug.Log("Start Game");
    }

    public void OnSettingButton()
    {
        // Hiện panel setting nếu có
        Debug.Log("Open Setting Panel");
    }

    public void OnQuitButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
        Debug.Log("Quit Game");
    }
}
