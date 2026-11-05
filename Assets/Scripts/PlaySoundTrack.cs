using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTrack : MonoBehaviour
{


    [SerializeField]
    string trackName;

    [SerializeField]
    float volume;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer.timer(0.01f,()=>{
            SoundtrackUtil.PlayMusic(trackName);
            SoundtrackUtil.SetVolume(volume);
        }));

    }

}
