using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerifiedText : MonoBehaviour
{
    bool done = false;

    [SerializeField]
    UnityEvent eventso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextVerification(Vector2 vect)
    {
        if (vect.y <= 0 && !done)
        {
            eventso.Invoke();
            done = true;
        }

    }
}
