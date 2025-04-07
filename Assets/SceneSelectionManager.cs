using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Tilia.Interactions.SpatialButtons;

public class SceneSelectionManager : MonoBehaviour
{
    [SerializeField] private SpatialButtonGroupManager locationButtonManager;
    [SerializeField] private SpatialButtonGroupManager lessonButtonManager;

    private Dictionary<int, string> sceneDictionary = new Dictionary<int, string>
    {
        { 0, "FastFoodRestaurant" },
        { 1, "House" },
        { 2, "School" },
        { 3, "Library" },
        { 4, "Train" }
    };

    private readonly Dictionary<int, string> lessonDictionary = new Dictionary<int, string>
    {
        { 0, "VocabLearn"},
        { 1, "VocabTest"},
        { 2, "Immersive"},
        { 3, "Sentence" }
    };

    public void HandleSceneSelection()
    {
        Debug.Log("This is running");
        if (locationButtonManager != null || lessonButtonManager != null)
        {
            int locationIndex = locationButtonManager.ActiveButtonIndex;
            int lessonIndex = lessonButtonManager.ActiveButtonIndex;

            if (locationIndex != -1 && lessonIndex != -1)
            {
                string sceneName = sceneDictionary[locationIndex]  + lessonDictionary[lessonIndex];
                Debug.Log($"Loading Scene: {sceneName}");
                SceneManager.LoadScene(sceneName);   
            }
            else if (locationIndex != -1)
            {
                Debug.Log("Location not selected");
            }
            else if (lessonIndex  != -1)
            {
                Debug.Log("Lesson not selected");
            }
        }
        else
        {
            Debug.Log("ButtonManager not assigned.");
        }
    }
}
