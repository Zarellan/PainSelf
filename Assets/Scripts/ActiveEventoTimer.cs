using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActiveEventoTimer : MonoBehaviour
{
    [SerializeField]
    UnityEvent eventer;
    [SerializeField]
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Timer.timer(timer,ActEvent));
    }



    void ActEvent()
    {
        eventer.Invoke();
    }
}
