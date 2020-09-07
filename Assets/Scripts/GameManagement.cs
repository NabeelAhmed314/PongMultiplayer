using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    static int PlayerScore01 = 0 , PlayerScore02 = 0;
    public GUISkin theSkin;
    
    public static void score(string WallName)
    {
        if(WallName == "rightWall")
        {
            PlayerScore01 += 1;
        }
        else
        {
            PlayerScore02 += 1;
        }
    }
    public static int getScore(int player)
    {
        if(player == 0)
        {
            return PlayerScore01;
        }
        else 
        {
            return PlayerScore02;
        }
    }


    private void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 80 -12, 10, 80, 80), "" + PlayerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 80 -12, 10, 80, 80), "" + PlayerScore02);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
