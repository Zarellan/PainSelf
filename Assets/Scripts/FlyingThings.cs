using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlyingThings : MonoBehaviour
{
    float defaultPosx;
    float defaultPosY;
    float randomPosY;
    


    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x,defaultPosY + Mathf.Sin(Time.time*10) / 2);
    
    }
}
