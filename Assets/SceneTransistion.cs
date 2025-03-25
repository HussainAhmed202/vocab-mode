using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad; 
    public float transitionTime = 1f; // Time for fade effect
    public CanvasGroup fadeCanvas; // Assign a UI CanvasGroup for fade effect

    public void LoadNextScene()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        if (fadeCanvas != null)
        {
            // Start fading out
            float elapsedTime = 0f;
            while (elapsedTime < transitionTime)
            {
                fadeCanvas.alpha = Mathf.Lerp(0, 1, elapsedTime / transitionTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            fadeCanvas.alpha = 1;
        }

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
