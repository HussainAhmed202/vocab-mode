using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int maxLives = 3; 
    private int currentLives; 

    public Image[] heartImages; // Array of heart images in the UI

    void Start()
    {
        // Initialize the current lives to the maximum
        currentLives = maxLives;

        // Ensure the heart images array is properly set up
        if (heartImages.Length != maxLives)
        {
            Debug.LogError("The number of heart images does not match the number of lives!");
        }

        // Update the UI to reflect the initial number of lives
        UpdateHearts();
    }

    public void DecrementLife()
    {
        if (currentLives > 0)
        {
            currentLives--; 
            UpdateHearts(); 

            if (currentLives == 0)
            {
                Debug.Log("Game Over!");
            }
        }
    }

    // Update the heart images based on the current number of lives
    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = i < currentLives;
        }
    }

    public void ResetLives()
    {
        currentLives = maxLives;
        UpdateHearts();
    }
}