using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Required for UI Image

public class ScreenBlinker : MonoBehaviour
{
    private Renderer screenRenderer; // For Renderer components
    private Image screenImage;       // For UI Image components
    private Color originalColor;

    private void Start()
    {
        // Check if the GameObject has a Renderer component
        screenRenderer = GetComponent<Renderer>();

        // Check if the GameObject has an Image component
        screenImage = GetComponent<Image>();

        // Save the original color based on the component found
        if (screenRenderer != null)
        {
            originalColor = screenRenderer.material.color;
        }
        else if (screenImage != null)
        {
            originalColor = screenImage.color;
        }
        else
        {
            Debug.LogWarning("No Renderer or Image component found on the screen GameObject.");
        }
    }

    public void Blink(Color blinkColor, float duration = 0.5f, int blinkCount = 2)
    {
        StartCoroutine(BlinkCoroutine(blinkColor, duration, blinkCount));
    }

    // Coroutine to handle the blinking effect
    private IEnumerator BlinkCoroutine(Color blinkColor, float duration, int blinkCount)
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // Change to blink color
            if (screenRenderer != null)
            {
                screenRenderer.material.color = blinkColor;
            }
            else if (screenImage != null)
            {
                screenImage.color = blinkColor;
            }

            yield return new WaitForSeconds(duration / 2); // Wait for half the duration

            // Revert to original color
            if (screenRenderer != null)
            {
                screenRenderer.material.color = originalColor;
            }
            else if (screenImage != null)
            {
                screenImage.color = originalColor;
            }

            yield return new WaitForSeconds(duration / 2); // Wait for the other half
        }
    }
}