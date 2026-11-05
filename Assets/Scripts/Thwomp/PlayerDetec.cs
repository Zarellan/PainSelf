using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetec : MonoBehaviour
{

    [SerializeField]
    Thwomp thwomp;
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
            if (GameObject.FindWithTag("Player").name == other.name && !thwomp.thwomped && !ShoopDaWoop.wooped)
                {
                    thwomp.detected = true;
                }
        }
}
