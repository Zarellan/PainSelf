using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class MoveObject : MonoBehaviour
{

    Tween tweenObj;
    
    [SerializeField]
    float x;

    [SerializeField]
    float y;

    [SerializeField]
    float duration;


    [SerializeField]
    Ease eases;

    [SerializeField]
    GameObject objectToMove;

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
                tweenObj = Tween.Position(objectToMove.transform,new Vector2(x,y),duration,eases);

                actived = true;
            }
    }

}
