using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SideWalls : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball")
        {
            GetComponent<AudioSource>().Play();
            string wallName = transform.name;
            GameManagement.score(wallName);
            if(GameManagement.getScore(0) == 15)
            {
                print("Player 1 Wins");
                SceneManager.LoadScene("GameOver");
            }
            else if(GameManagement.getScore(1) == 15)
            {
                print("Player 2 Wins");
                SceneManager.LoadScene("GameOver");
            }

            collision.gameObject.SendMessage("Reset");
        }
    }
}
