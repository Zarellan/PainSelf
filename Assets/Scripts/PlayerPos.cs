using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerPosDef(string pos)
    {
        string[] poss = pos.Split(',');
        PlayerMovement.defaultPosX = float.Parse(poss[0]);
        PlayerMovement.defaultPosY = float.Parse(poss[1]);

    }
}
