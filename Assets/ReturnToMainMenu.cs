using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] private MeshRenderer fadeQuad; 
    [SerializeField] private float fadeDuration = 1f;
    
    private AsyncOperation preloadOperation;
    private bool isTransitioning = false;
    private Material fadeMaterial;
    private Color fadeColor = Color.black;

    private void Start()
    {
        // Initialize fade material
        if (fadeQuad != null)
        {
            fadeMaterial = fadeQuad.material;
            fadeColor.a = 0f; // Start transparent
            fadeMaterial.color = fadeColor;
            fadeQuad.gameObject.SetActive(false);
        }

        // Preload main menu scene
        preloadOperation = SceneManager.LoadSceneAsync("MainMenu");
        preloadOperation.allowSceneActivation = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            StartCoroutine(TransitionToMainMenu());
        }
    }

    private IEnumerator TransitionToMainMenu()
    {
        isTransitioning = true;
        

        if (fadeQuad != null)
        {
            fadeQuad.gameObject.SetActive(true);
            yield return StartCoroutine(Fade(0f, 1f)); // Fade to black
        }

        // Activate the preloaded scene
        preloadOperation.allowSceneActivation = true;

        // // Wait one frame to ensure scene is loaded
        // yield return null;

        // Wait until scene is fully loaded and activated
        yield return new WaitUntil(() => preloadOperation.isDone);

        // Fade back in (optional - remove if you want to stay black until menu loads)
        if (fadeQuad != null)
        {
            yield return StartCoroutine(Fade(1f, 0f)); // Fade to transparent
            fadeQuad.gameObject.SetActive(false);
        }

        isTransitioning = false;
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        fadeColor.a = startAlpha;
        fadeMaterial.color = fadeColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeMaterial.color = fadeColor;
            yield return null;
        }

        fadeColor.a = endAlpha;
        fadeMaterial.color = fadeColor;
    }
}