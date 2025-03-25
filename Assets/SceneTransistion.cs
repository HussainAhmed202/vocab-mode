using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public float delay = 5f; // Set the delay time in seconds

    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }

}
