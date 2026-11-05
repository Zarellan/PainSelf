using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ValueFromSlide : MonoBehaviour
{
    TMP_Text text;


    [SerializeField]
    Slider slider;

    [SerializeField]
    string isFor;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(isFor)
        {
            case "Volume":text.text = (Mathf.Floor(slider.value*10000)/100).ToString();break;
            default :text.text = slider.value.ToString();break;

        }
    }
}
