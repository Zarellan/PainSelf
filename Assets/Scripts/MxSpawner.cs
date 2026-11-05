using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MxSpawner : MonoBehaviour
{
    [SerializeField]
    MxAppears mx;

    bool actived = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (GameObject.FindWithTag("Player").name == other.name)
            {
                if (!actived)
                StartCoroutine(Timer.timer(2,()=>mx.Appear()));

                actived = true;
            }
    }

}
