using System.Collections;
using System.Collections.Generic;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
public class TripMine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActiveMine()
    {
        StartCoroutine(Timer.timer(0.5f,()=>{
            GameObject.FindWithTag("TrapMine").GetComponent<Image>().color = new Color(1,0,0.9284806f,1);
            GameOverUtil.Over("“Ú|Æ-ÛAEUŒ”\n-Subspace Tripmine","",4);
            AudioUtil.Play("Subspace Tripmine");
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ChangeAnimation("Dust",true);
            StartCoroutine(Timer.timer(1,()=>{Tween.Alpha(GameObject.FindWithTag("TrapMine").GetComponent<Image>(),0,1,Ease.Linear);gameObject.SetActive(false);}));
            
            

        }));
    }
}
