using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButtonHandler : MonoBehaviour
{
    public GameObject screenPanel;

    public void OnVolumeOffClicked()
    {
        
        foreach (Transform question in screenPanel.transform)
        {
            if (question.gameObject.activeSelf)
            {
                
                TMP_Text sentenceTextBox = question.GetComponentInChildren<TMP_Text>();
                if (sentenceTextBox != null)
                {
                    Debug.Log(sentenceTextBox.text);
                }
                else
                {
                    Debug.LogWarning("SentenceTextbox (TMP) not found in active question!");
                }

                // Since only one question is active at a time, break after finding
                break;
            }
        }
    }
}
