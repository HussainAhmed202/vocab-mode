using UnityEngine;
using Tilia.Interactions.Interactables.Interactables; // Ensure this using directive is added

public class SnapZoneLogger : MonoBehaviour
{
    //public string snapZoneName; 
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
            // string zoneName = string.IsNullOrEmpty(snapZoneName) ? gameObject.name : snapZoneName; 

            // get the tray name which tells us the order number
            string trayNumber = transform.parent.name; // Order1Tray, Order2Tray etc

            // Debug.Log($"{zoneName} Snapped, Object Snapped = {objectName}, Layer = {layerName}");
            Debug.Log($"Serving Tray: {trayNumber}, {gameObject.name} Snapped, Object Snapped = {objectName}, Layer = {layerName}");


            // Disable grab for the snapped object
            DisableGrab(snappedObject);


            // Notify OrderVerifier about the snapped object
            if (orderVerifier != null)
            {
                orderVerifier.OnItemSnapped(snappedObject, trayNumber);
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
            Debug.Log($"{snappedObject.name} grab disabled.");
        }
        else
        {
            Debug.LogWarning($"No InteractableFacade found on {snappedObject.name}");
        }
    }

    
}
