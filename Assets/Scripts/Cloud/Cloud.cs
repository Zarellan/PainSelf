using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public string from;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.0f,2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo(from);
    }


    void MoveTo(string direction)
    {
        if (direction == "right")
        {
            transform.position = new Vector2(transform.position.x + -speed*Time.deltaTime,transform.position.y);
            if (transform.position.x < -13)
                Destroy(gameObject);

        }
        else if (direction == "left")
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,transform.position.y);

            if (transform.position.x > 13)
                Destroy(gameObject);
        }
    }
}
