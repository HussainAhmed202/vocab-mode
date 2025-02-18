using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using Tilia.Interactions.Interactables.Interactables; // Ensure this using directive is added

public class SnapZoneLogger2 : MonoBehaviour
{
    public TextMeshProUGUI logText; // Assign this in the Unity Inspector
    private OrderVerifier orderVerifier;

    private void Start()
    {
        // Find OrderVerifier in the scene (Make sure the Tray has this script)
        orderVerifier = Object.FindFirstObjectByType<OrderVerifier>();
    }

    public void LogSnappedObject(GameObject snappedObject)
    {
        if (snappedObject != null)
        {
            string layerName = LayerMask.LayerToName(snappedObject.layer);
            string objectName = snappedObject.name;
            string message = $"{gameObject.name} Snapped, Object Snapped = {objectName}, Layer = {layerName}";
            
            // Display message in TextMeshPro UI
            if (logText != null)
            {
                logText.text = message;
            }
            else
            {
                Debug.LogWarning("TextMeshProUGUI component is not assigned in the inspector!");
            }

            // Disable grab for the snapped object
            DisableGrab(snappedObject);

            // Notify OrderVerifier about the snapped object
            if (orderVerifier != null)
            {
                orderVerifier.OnItemSnapped(snappedObject);
            }
            else
            {
                Debug.LogWarning("OrderVerifier not found in the scene!");
            }
        }
    }

    private void DisableGrab(GameObject snappedObject)
    {
        // Check if the object has an InteractableFacade component
        var interactableFacade = snappedObject.GetComponent<InteractableFacade>();

        if (interactableFacade != null)
        {
            // Disable primary and secondary grab actions
            interactableFacade.DisablePrimaryGrabAction();
            interactableFacade.DisableSecondaryGrabAction();
            
            if (logText != null)
            {
                logText.text += $"\n{snappedObject.name} grab disabled.";
            }
        }
        else
        {
            if (logText != null)
            {
                logText.text += $"\nNo InteractableFacade found on {snappedObject.name}";
            }
        }
    }
}
