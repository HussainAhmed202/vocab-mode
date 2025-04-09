using UnityEngine;
using System;
using TMPro;

public class ThirdOrderInfo : OrderInfoBase
{
    void Start()
    {
               // Define order details
        string orderNumber = "#1023";
        string tableNumber = "#2";
        string[] itemNames = { "ChocolateDonutWithSprinklesSpawn", "UbeDonutSpawn", "Lemonade"};
        int[] quantities = { 1, 1, 1 };
        float[] basePrices = { 3.99f, 4.99f, 2.99f }; // Base prices for each item
        float taxRate = 0.08f;

        // Set the receipt text
        SetReceiptText(orderNumber, tableNumber, itemNames, quantities, basePrices, taxRate);
}
}
