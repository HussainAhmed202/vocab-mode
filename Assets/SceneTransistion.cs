using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTransition : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 5f; 

    private void Start()
    {
        StartCoroutine(LoadNextSceneAsyncAfterDelay());
    }

    private IEnumerator LoadNextSceneAsyncAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneIndex);
            asyncLoad.allowSceneActivation = true;

            while (!asyncLoad.isDone)
            {
                Debug.Log($"Loading progress: {asyncLoad.progress}");
                yield return null;
            }
        }
        else
        {
            Debug.LogError("Next scene index is out of range. Make sure the next scene is added to Build Settings.");
        }
    }
    
}