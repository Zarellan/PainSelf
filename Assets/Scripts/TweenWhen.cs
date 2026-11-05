using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
public class TweenWhen : MonoBehaviour
{

    [SerializeField]
    float appearOn;

    [SerializeField]
    float x,y,duration;

    [SerializeField]
    Ease ease;

    
    enum PosType
    {
        uiPosition,
        position
    }

    [SerializeField]
    PosType posType;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer.timer(appearOn,()=>
        {
            switch(posType)
            {
                case PosType.uiPosition:Tween.UIAnchoredPosition(GetComponent<RectTransform>(),new Vector2(x,y),duration,ease);break;
                case PosType.position:Tween.Position(transform,new Vector2(x,y),duration,ease);break;

            }

        }));
    }


}
