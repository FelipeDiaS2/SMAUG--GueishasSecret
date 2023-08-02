using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerBasisMovement playerScript;
    
    public Text MovesLeft;

    public GameObject gameOverMenu;

    private GameObject mainMusic;
    [SerializeField] private AudioSource gameOverMusic;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerBasisMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        this.MovesLeft.text = ("" + playerScript.moveCounter);

    }

    public void GameOver()
    {
        mainMusic = GameObject.Find("BG Music");
        mainMusic.GetComponent<AudioSource>().Pause();
        
        gameOverMusic.Play();
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

}

