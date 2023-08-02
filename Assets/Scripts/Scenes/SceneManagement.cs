using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public int sceneIndex;

    public Animator transition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LevelTransition());
        }
    }


    IEnumerator LevelTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);

    }
    //SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);

    
}