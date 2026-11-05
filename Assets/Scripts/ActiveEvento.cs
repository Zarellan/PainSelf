using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ActiveEvento : MonoBehaviour
{
    [SerializeField]
    UnityEvent eventer;

    [SerializeField]
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        if (start)
            ActEvent();
    }



    void ActEvent()
    {
        eventer.Invoke();
    }
}
