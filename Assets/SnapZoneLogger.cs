using UnityEngine;

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

            // Debug.Log($"{zoneName} Snapped, Object Snapped = {objectName}, Layer = {layerName}");
            Debug.Log($"{gameObject.name} Snapped, Object Snapped = {objectName}, Layer = {layerName}");

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
}
