using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoopDaWoop : MonoBehaviour
{
    public static bool wooped = false;
    bool trapped = false;

    [SerializeField]
    GameObject shoopWoop;


    [SerializeField]
    GameObject lazer;

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
        if (GameObject.FindWithTag("Player").name == other.name && !trapped)
            {
                wooped = true;
                GetComponent<AudioSource>().Play();
                shoopWoop.SetActive(true);

                trapped = true;

                StartCoroutine(Timer.timer(2.49f,()=>{lazer.SetActive(true);}));
                StartCoroutine(Timer.timer(2.89f,()=>{lazer.SetActive(false);}));

            }
    }

}
