using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{

    public new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.volume = PlayerData.volume;
    }
}
