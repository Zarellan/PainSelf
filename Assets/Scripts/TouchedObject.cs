using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchedObject : MonoBehaviour
{


    public UnityEvent events;

    public bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableInteraction()
    {
        canInteract = false;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (GameObject.FindWithTag("Player").name == other.gameObject.name && canInteract)
            {
                events.Invoke();
            }

    }

}
