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
        { 1, "Restaurant" },
        { 2, "House" },
        { 3, "School" },
        { 4, "Library" },
        { 5, "Train" }
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
        if (locationButtonManager != null && lessonButtonManager != null)
        {
            int locationIndex = locationButtonManager.ActiveButtonIndex;
            int lessonIndex = lessonButtonManager.ActiveButtonIndex;

            if (sceneDictionary.ContainsKey(locationIndex) && lessonDictionary.ContainsKey(lessonIndex))
            {
                string sceneName = sceneDictionary[locationIndex]  + lessonDictionary[lessonIndex];
                Debug.Log($"Loading Scene: {sceneName}");
                SceneManager.LoadScene(sceneName);
            }
            else if (locationButtonManager == null)
            {
                Debug.Log("Location not found");
            }
            else if (lessonButtonManager == null)
            {
                Debug.Log("Lesson not found ");
            }
        }
        else
        {
            Debug.LogError("ButtonGroupManagers are not assigned.");
        }
    }
}
