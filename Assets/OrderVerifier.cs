using System.Collections.Generic;
using UnityEngine;

public class OrderVerifier : MonoBehaviour
{

    // hardcoded order
   private Dictionary<string, int> requiredOrder = new Dictionary<string, int>
    {
        { "Burger", 1 },
        { "Fries", 2 },
        { "Soda", 1 }
    };

    private Dictionary<string, int> currentOrder = new Dictionary<string, int>();

    public void OnItemSnapped(GameObject snappedObject)
    {
        if (snappedObject != null)
        {
            string layerName = LayerMask.LayerToName(snappedObject.layer);

            if (currentOrder.ContainsKey(layerName)) // checks if layer already exists
            {
                currentOrder[layerName]++;   // if it exists then increment the layer
            }
            else
            {
                currentOrder[layerName] = 1; // it does not exist. this is the first layer so set to 1
            }

            Debug.Log($"Item Added: {snappedObject.name}, Layer: {layerName}");
        }
    }

    public void VerifyOrder()
    {
        foreach (var item in requiredOrder)
        {
            string itemName = item.Key;
            int requiredAmount = item.Value;
            int currentAmount = currentOrder.ContainsKey(itemName) ? currentOrder[itemName] : 0;

            if (currentAmount != requiredAmount) // check if order contains the required item and if it contains the correct amount
            {
                Debug.Log($"❌ Order Incorrect! {itemName} -> Required: {requiredAmount}, Current: {currentAmount}");
                return;
            }
        }

        Debug.Log("✅ Order is Complete! Ready to be Served! ✅");
    }





}
