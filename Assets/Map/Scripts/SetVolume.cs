using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{

    public new AudioSource audio;

    // Start is called before the first frame update
    void Update()
    {
        audio.volume = PlayerData.volume;
    }
}
