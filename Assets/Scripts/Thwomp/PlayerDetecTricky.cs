using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerDetecTricky : MonoBehaviour
{

    [SerializeField]
    TrickyThwomp thwomp;
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
            if (GameObject.FindWithTag("Player").name == other.name && !thwomp.thwomped)
                {
                    thwomp.detected = true;
                }
        }
}
