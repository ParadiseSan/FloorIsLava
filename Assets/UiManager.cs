using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           
            Destroy(gameObject);
        }
    }
    public void OnStartButtonClicked()
    {
        GameManager.Instance.StartGame(SceneManager.GetActiveScene().buildIndex+1); // lobby scene next
    }

    public void OnPauseButtonClicked()
    {
        GameManager.Instance.PauseGame();
    }

    public void OnResumeButtonClicked()
    {
        GameManager.Instance.ResumeGame();
    }

    public void OnGameOver()
    {
        GameManager.Instance.EndGame();
    }

    public void OnMainMenuButtonClicked()
    {
        GameManager.Instance.LoadScene("MainMenu");
    }
}
