using UnityEngine;

public class BlinkArrow : MonoBehaviour
{

    private float blinkInterval = 0.5f; // Time interval for blinking

    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component


    void Start()
    {
        
        if (spriteRenderer == null)
        {
            // If the SpriteRenderer is not assigned, try to get it from the same GameObject
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            // Start the blinking coroutine
            StartCoroutine(Blink());
        }
        else
        {
            Debug.LogError("No SpriteRenderer component found!");
        }
        
    }

    private System.Collections.IEnumerator Blink()
    {
        while (true)
        {
            // Toggle the visibility of the sprite
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Wait for the specified interval before the next blink
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
