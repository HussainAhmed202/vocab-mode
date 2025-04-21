using Tilia.Interactions.SpatialButtons;
using UnityEngine;
using TMPro; 

public class SentenceManager : MonoBehaviour
{
    
    public TMP_Text sentenceText;
    [SerializeField] private SpatialButtonGroupManager choiceIndex ;
    
   
    private string[] sentences = {
        "Was fragt der Kellner, wenn er Ihnen die Karte zeigt?",
        "Wie sagt man auf Deutsch Can I take your order?",
        "Was bedeutet Wie möchten Sie Ihr Steak gebraten?",
        "Was fragt der Kellner, wenn er Ihnen Getränke anbietet?",
        "Was fragt der Kellner, wenn er das Essen bringt?"
    };

  
    private int currentSentenceIndex = 0;

   
    void Start()
    {
        DisplaySentence();

    }

    private void DisplaySentence()
    {
        sentenceText.text = sentences[currentSentenceIndex];
    }

    public void NextSentence()
    {
        int buttonIndex = choiceIndex.ActiveButtonIndex;
        if (buttonIndex != -1)
        {
            currentSentenceIndex = (currentSentenceIndex + 1) % sentences.Length;
            DisplaySentence();           
        }
    }

   
}
