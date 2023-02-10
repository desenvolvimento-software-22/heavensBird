using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    PlayableDirector director;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
    }
    void Update()
    {
        if (director.state != PlayState.Playing)
        {  
            SceneManager.UnloadSceneAsync("cutscene");
        }
    }
}
