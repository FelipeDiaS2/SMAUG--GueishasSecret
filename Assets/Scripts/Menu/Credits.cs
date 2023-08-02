using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private float timeElapsed;

    private GameObject music;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > 6f)
        {
            SceneManager.LoadScene("Menu");
            music.GetComponent<AudioSource>().Pause();

        }
    }
}
