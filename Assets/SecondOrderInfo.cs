using UnityEngine;
using System;
using TMPro;

public class SecondOrderInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI largeText;

    void Start()
    {
        string currentDate = System.DateTime.UtcNow.ToLocalTime().ToString("dd.MM.yyyy");
        string currentTime = System.DateTime.UtcNow.ToLocalTime().ToString("hh:mm tt");
        TMP_Text tmpText = GameObject.Find("SecondOrderTextMessageDisplay").GetComponent<TMP_Text>();


        // Formatting the receipt output
        tmpText.text = "=============================================\n" +
                         "                 BurgerBlitz\n" +
                         "=============================================\n" +
                         "Bestell-Nr.: #1023     Tisch: #2\n" +
                         $"Datum: {currentDate}   Uhrzeit: {currentTime}\n\n" +
                         "Artikel                    Menge   Preis  \n" +
                         "-----------------------------------------------------------------------\n" +
                         "1. Hamburger             30     110,97 €  \n" +
                         "2. Pommes Frites       25      50,98 €  \n" +
                         "-----------------------------------------------------------------------\n" +
                         "Zwischensumme:            20,44 €  \n" +
                         "Steuer (8%):                   1,64 €  \n" +
                         "-----------------------------------------------------------------------\n" +
                         "Gesamt:                        22,08 €  ";
    }
}
