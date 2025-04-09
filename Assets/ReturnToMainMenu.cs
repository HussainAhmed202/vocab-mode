using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Returning to main menu...");
            StartCoroutine(LoadMainMenuAsync());
        }
    }

    private System.Collections.IEnumerator LoadMainMenuAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        while (!asyncLoad.isDone)
        {
            // Optionally, add a loading screen or progress bar update here
            yield return null;
        }
    }
}
