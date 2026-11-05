using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject cloud;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCloud()
    {
        GameObject cloudo = Instantiate(cloud);
        cloudo.name = "Cloud";

        cloudo.GetComponent<Cloud>().from = (Random.Range(0,2) == 0)?"left":"right";
        float randomY = Random.Range(0.74f,3.81f);
        if (cloudo.GetComponent<Cloud>().from == "right")
            cloudo.transform.position = new Vector2(11,randomY);
        else if (cloudo.GetComponent<Cloud>().from == "left")
            cloudo.transform.position = new Vector2(-11,randomY);

        float scale = Random.Range(4f,5.71f);

        cloudo.transform.localScale = new Vector2(scale,scale); 
        

        StartCoroutine(Timer.timer(Random.Range(5,8),SpawnCloud));


    }
}
