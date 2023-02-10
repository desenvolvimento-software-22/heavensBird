using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadLevelScene()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("cutscene", LoadSceneMode.Additive);
    }
}
