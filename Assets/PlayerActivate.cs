using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActivate : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.sceneCount == 1)
        {
            player.SetActive(true);
        }
    }
}
