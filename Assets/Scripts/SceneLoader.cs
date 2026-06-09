using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
   
    public void LoadGameScene()
    {         
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); 
    }
     public void LoadMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void LoadMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
    public void LoadMeetingScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MeetingScene");
    }
    public void LoadEatingScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EatingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
