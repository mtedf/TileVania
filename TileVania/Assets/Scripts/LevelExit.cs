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
        if(other.tag == "Player")
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.DeactivatePowerup();
            }


            StartCoroutine(LoadNextLevel());
        }
        
        


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

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(intNextSceneIndex);
    }

    
}
