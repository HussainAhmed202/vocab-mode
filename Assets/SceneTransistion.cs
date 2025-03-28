using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName; 

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogError($"Scene '{nextSceneName}' cannot be loaded. Check the name and ensure it's added to build settings.");
            }
        }
        else
        {
            Debug.LogError("No scene name provided. Please set the next scene name in the inspector.");
        }
    }
}