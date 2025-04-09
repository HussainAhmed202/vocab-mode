using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{

    private AsyncOperation preloadOperation;

    void Start()
    {
        //  Preload main menu for faster transisition
        preloadOperation = SceneManager.LoadSceneAsync("MainMenu");
        preloadOperation.allowSceneActivation = false; // Don't switch yet
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Returning to main menu...");
            preloadOperation.allowSceneActivation = true; // Now activate it

        }
    }
}