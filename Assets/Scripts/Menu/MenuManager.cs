using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private int SceneIndex;

    [SerializeField] private GameObject MainMenuScene;

    [SerializeField] private GameObject OptionsScene;

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneIndex);
    }

    public void OpenOptions()
    {
        MainMenuScene.SetActive(false);
        OptionsScene.SetActive(true);
    }


    public void CloseOptions()
    {
        OptionsScene.SetActive(false);
        MainMenuScene.SetActive(true);
    }


    public void CloseGame()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
    






}

