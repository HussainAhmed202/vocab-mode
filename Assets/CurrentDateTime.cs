using UnityEngine;
using System;
using System.Collections;
using TMPro; 

public class CurrentDateTime : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI largeText;
    void Start()
    {
        string currentDate = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy");
        string currentTime = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm");

        // Formatting the text output
        largeText.text = $"Order Date : {currentDate}\nOrder Time : {currentTime}";


        
        
    }
}
