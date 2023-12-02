using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float fltLevelLoadDelay = 1f;




    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
        
        


    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(fltLevelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int intNextSceneIndex = currentSceneIndex + 1;

        if(intNextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            intNextSceneIndex = 0;
        }

        SceneManager.LoadScene(intNextSceneIndex);
    }

    
}
