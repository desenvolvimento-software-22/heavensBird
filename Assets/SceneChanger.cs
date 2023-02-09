using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int index;
    public string levelName;

    void OnTriggerEnter2D(Collider2D player)
    {
        Debug.Log("Teste");
        //Debug.Log("Está em contato");
        if(player.CompareTag("Player"))
        {
            // Loading level with build index
            SceneManager.LoadScene(index);

            Debug.Log("Está em contato");

            // Loading level with scene name
            SceneManager.LoadScene(levelName);

            // Restart the level
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
