using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagementForScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GetComponent<AudioSource>());
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayArea");
    }

}
