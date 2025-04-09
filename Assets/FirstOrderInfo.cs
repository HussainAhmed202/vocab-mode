
using UnityEngine;

public class FirstOrderInfo : OrderInfoBase
{
    void Start()
    {
        // Define order details
        string orderNumber = "#1023";
        string tableNumber = "#2";
        string[] itemNames = { "Hamburger", "Pommes Frites", "Cola (Groß)" };
        int[] quantities = { 1, 2, 1 };
        float[] basePrices = { 3.99f, 2.99f, 2.49f }; // Base prices for each item
        float taxRate = 0.08f;

        // Set the receipt text
        SetReceiptText(orderNumber, tableNumber, itemNames, quantities, basePrices, taxRate);
    }
}