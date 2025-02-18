using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderVerifier : MonoBehaviour
{


     [SerializeField] private TextMeshProUGUI largeText;




    // hardcoded order
    private Dictionary<string, int> requiredOrder;


    private Dictionary<string, int> requiredOrder1 = new Dictionary<string, int>
    {
        { "Burger", 1 },
        { "Fries", 2 },
        { "Soda", 1 }
    };

    private Dictionary<string, int> requiredOrder2 = new Dictionary<string, int>
    {
        { "Burger", 4 }
    };


    private string currentOrderNumber = "Empty";

  
        
    
    private Dictionary<string, int> currentOrder = new Dictionary<string, int>();

    public void OnItemSnapped(GameObject snappedObject, String trayNumber)
    {
        if (snappedObject != null)
        {
            string layerName = LayerMask.LayerToName(snappedObject.layer);
            currentOrderNumber = trayNumber;

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
        TMP_Text tmpText = GameObject.Find("ResultDisplay").GetComponent<TMP_Text>();
        if (currentOrderNumber == "Empty") // no object snapped i.e tray is empty when button is pressed
            {
                Debug.Log($"❌ Empty Tray. Order Empty");
                tmpText.text = "You forgot to add all the items in the tray. Do not forget that";
                return;               
            }

        if (currentOrderNumber == "Order1Tray")
        {
            requiredOrder = requiredOrder1;
            
        }
        else  if (currentOrderNumber == "Order2Tray")
        {
            requiredOrder = requiredOrder2;
            
        }

        
        foreach (var item in requiredOrder)
        {
            string itemName = item.Key;
            int requiredAmount = item.Value;
            int currentAmount = currentOrder.ContainsKey(itemName) ? currentOrder[itemName] : 0;

            if (currentAmount != requiredAmount) // check if order contains the required item and if it contains the correct amount
            {
                Debug.Log($"❌ Order Incorrect! {itemName} -> Required: {requiredAmount}, Current: {currentAmount}");
                tmpText.text = "Incorrect but nice effort";
                return;
            }
        }

        Debug.Log($"✅ {currentOrderNumber} Order is Complete! Ready to be Served! ✅");
        tmpText.text = "Excellent Job";

        // flush the currentorder dict so new dictionary for new order
        currentOrder.Clear();
    }


}
