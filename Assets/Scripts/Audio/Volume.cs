using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioSource musicMenu;


    public void VolumeMenu(float value)
    {
        musicMenu.volume = value;
    }
}
