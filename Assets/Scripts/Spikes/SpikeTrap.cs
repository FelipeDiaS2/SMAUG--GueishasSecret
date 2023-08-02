using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    PlayerBasisMovement playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerBasisMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript.moveCounter -= 2;
            print("Perdeu 2 vidas");
        }
    }

}
