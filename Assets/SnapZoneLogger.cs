using UnityEngine;

public class SnapZoneLogger : MonoBehaviour
{
    public string snapZoneName; // Set this in the Unity Inspector or dynamically

    public void LogSnappedObject(GameObject snappedObject)
    {
        if (snappedObject != null)
        {
            string layerName = LayerMask.LayerToName(snappedObject.layer);
            string objectName = snappedObject.name;
            string zoneName = string.IsNullOrEmpty(snapZoneName) ? gameObject.name : snapZoneName; // Use GameObject name if not set

            Debug.Log($"{zoneName} Snapped, Object Snapped = {objectName}, Layer = {layerName}");
        }
    }
}
