using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SimpleFlick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SimpleFlicko();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SimpleFlicko()
    {
        Tween.Alpha(GetComponent<TMP_Text>(),0.2f,1,Ease.Linear,cycles:-1,cycleMode: CycleMode.Yoyo);
        
    }
    
}
