using UnityEngine;
using Tilia.Interactions.SpatialButtons;

public class ResultVerifier : MonoBehaviour
{
    [Tooltip("Reference to the SpatialButtonGroupManager component.")]
    [SerializeField] private SpatialButtonGroupManager buttonGroupManager;

 //   private int correctAnswerIndex = 1;
    public void CheckAnswer(int correctAnswerIndex)
    {
        if (buttonGroupManager != null)
        {
            int selectedButtonIndex = buttonGroupManager.ActiveButtonIndex; 
            Debug.LogWarning($"{selectedButtonIndex} button selected");
            if (selectedButtonIndex == correctAnswerIndex)
            {
                Debug.LogWarning($"Correct Answer selected");
                // load next question 

                
            }
            else
            {
                Debug.LogWarning($"Incorrect Answer");
                
            }

           
        }

        Debug.LogWarning("SpatialButtonGroupManager reference not set.");
        
    }

}
