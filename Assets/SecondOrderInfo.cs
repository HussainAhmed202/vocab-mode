using UnityEngine;
using System;
using TMPro;

public class SecondOrderInfo : OrderInfoBase
{
    void Start()
    {
               // Define order details
        string orderNumber = "#1023";
        string tableNumber = "#2";
        string[] itemNames = { "Hamburger"};
        int[] quantities = { 4 };
        float[] basePrices = { 3.99f }; // Base prices for each item
        float taxRate = 0.08f;

        // Set the receipt text
        SetReceiptText(orderNumber, tableNumber, itemNames, quantities, basePrices, taxRate);
}
}
