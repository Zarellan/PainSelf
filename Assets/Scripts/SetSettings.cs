using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioUtil.Volume(PlayerPrefs.GetFloat("Volume",1));
        SoundtrackUtil.SetVolume(PlayerPrefs.GetFloat("Volume",1));

        Application.targetFrameRate = Mathf.FloorToInt(PlayerPrefs.GetFloat("FPS",60));
    }

    // Update is called once per frame
    void Update()
    {
        AudioUtil.Volume(PlayerPrefs.GetFloat("Volume",1));
        SoundtrackUtil.SetVolume(PlayerPrefs.GetFloat("Volume",1));
        Application.targetFrameRate = Mathf.FloorToInt(PlayerPrefs.GetFloat("FPS",60));
    }

    public void CheckPointCheck(bool cond)
    {
        string condo;
        condo = cond == true?"true":"false";
        PlayerPrefs.SetString("AllowCheckpoints",condo);
    }
}
