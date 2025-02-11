using UnityEngine;
using System;
using TMPro;

public class CurrentDateTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI largeText;

    void Start()
    {
        string currentDate = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");
        string currentTime = System.DateTime.UtcNow.ToLocalTime().ToString("hh:mm tt");

        // Formatting the receipt output
        largeText.text = "=============================================\n" +
                         "                 BurgerBlitz\n" +
                         "=============================================\n" +
                         "Bestell-Nr.: #1023     Tisch: #2\n" +
                         $"Datum: {currentDate}   Uhrzeit: {currentTime}\n\n" +
                         "Artikel                    Menge   Preis  \n" +
                         "-----------------------------------------------------------------------\n" +
                         "1. Hamburger             3     11,97 €  \n" +
                         "2. Pommes Frites       2      5,98 €  \n" +
                         "3. Cola (Groß)            1      2,49 €  \n" +
                         "-----------------------------------------------------------------------\n" +
                         "Zwischensumme:            20,44 €  \n" +
                         "Steuer (8%):                   1,64 €  \n" +
                         "-----------------------------------------------------------------------\n" +
                         "Gesamt:                        22,08 €  ";
    }
}
