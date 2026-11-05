using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameOverUtil
{
    public static void Over(string text,string sound,float duration)
    {
        GameObject.FindWithTag("GameOver").GetComponent<GameOver>().GameOverAdvanced(text,sound,duration);
    }
}
