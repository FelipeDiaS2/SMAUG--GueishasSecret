using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] Transform pauseMenu;
    
    private GameObject music;

    public GameObject gameOverMenu;

    private void Update()
    {
        if (gameOverMenu.activeSelf ==  false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseMenu.gameObject.activeSelf)
                {
                    pauseMenu.gameObject.SetActive(false);
                    Time.timeScale = 1f;
                }
                else
                {
                    pauseMenu.gameObject.SetActive(true);
                    Time.timeScale = 0f;

                }
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void QuitGame()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }

    public void SceneMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            music = GameObject.Find("BG Music");
            GameObject.Destroy(music);
        }

        music = GameObject.Find("BG Music");
        music.GetComponent<AudioSource>().Play();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
    }
}
