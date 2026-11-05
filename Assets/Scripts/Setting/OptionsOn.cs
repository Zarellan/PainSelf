using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;

public class OptionsOn : MonoBehaviour
{
    [SerializeField]
    GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BringOptions()
    {
        Tween.UIAnchoredPositionY(options.GetComponent<RectTransform>(),0,0.25f,Ease.OutCirc);
    }

        public void UnbringOptions()
    {
        Tween.UIAnchoredPositionY(options.GetComponent<RectTransform>(),1000,0.25f,Ease.InCirc);
    }
}
