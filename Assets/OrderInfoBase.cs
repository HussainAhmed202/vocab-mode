using UnityEngine;
using TMPro;

public abstract class OrderInfoBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI largeText; 

    // Method to calculate the price of an item
    protected float CalculateItemPrice(float basePrice, int quantity)
    {
        return basePrice * quantity;
    }

    // Method to calculate the subtotal
    protected float CalculateSubtotal(float[] itemPrices)
    {
        float subtotal = 0f;
        foreach (var price in itemPrices)
        {
            subtotal += price;
        }
        return subtotal;
    }

    // Method to calculate the tax
    protected float CalculateTax(float subtotal, float taxRate)
    {
        return subtotal * taxRate;
    }

    // Method to calculate the total
    protected float CalculateTotal(float subtotal, float tax)
    {
        return subtotal + tax;
    }

    // Method to format the receipt text
    protected void SetReceiptText(string orderNumber, string tableNumber, string[] itemNames, int[] quantities, float[] basePrices, float taxRate)
    {
        string currentDate = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");
        string currentTime = System.DateTime.UtcNow.ToLocalTime().ToString("hh:mm tt");

        // Formatting the receipt output
        string receiptText = "=============================================\n" +
                             "                 BurgerBlitz\n" +
                             "=============================================\n" +
                             $"Bestell-Nr.: {orderNumber}     Tisch: {tableNumber}\n" +
                             $"Datum: {currentDate}   Uhrzeit: {currentTime}\n\n" +
                             "Artikel                    Menge   Preis  \n" +
                             "-----------------------------------------------------------------------\n";

        // Calculate item prices and subtotal
        float[] itemPrices = new float[itemNames.Length];
        for (int i = 0; i < itemNames.Length; i++)
        {
            itemPrices[i] = CalculateItemPrice(basePrices[i], quantities[i]);
            receiptText += $"{i + 1}. {itemNames[i],-20} {quantities[i],-6} {itemPrices[i]:F2} €\n";
        }

        // Calculate subtotal, tax, and total
        float subtotal = CalculateSubtotal(itemPrices);
        float tax = CalculateTax(subtotal, taxRate);
        float total = CalculateTotal(subtotal, tax);

        receiptText += "-----------------------------------------------------------------------\n" +
                       $"Zwischensumme:            {subtotal,8:F2} €\n" +
                       $"Steuer ({(taxRate * 100):F0}%):            {tax,8:F2} €\n" +
                       "-----------------------------------------------------------------------\n" +
                       $"Gesamt:                        {total,8:F2} €";

        // Set the text to the TextMeshProUGUI component
        largeText.text = receiptText;
    }
}