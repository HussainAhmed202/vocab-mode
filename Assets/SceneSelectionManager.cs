using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Tilia.Interactions.SpatialButtons;
using System.Collections;

public class SceneSelectionManager : MonoBehaviour
{
    [SerializeField] private SpatialButtonGroupManager locationButtonManager;
    [SerializeField] private SpatialButtonGroupManager lessonButtonManager;
    private string sceneToLoad;


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
       int locationIndex = locationButtonManager.ActiveButtonIndex;
       int lessonIndex = lessonButtonManager.ActiveButtonIndex;
       if (locationIndex != -1 && lessonIndex != -1)
       {
            sceneToLoad = sceneDictionary[locationIndex]  + lessonDictionary[lessonIndex];
            Debug.Log($"Loading Scene: {sceneToLoad}");

            StartCoroutine(LoadSceneAsync());     
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

    private IEnumerator LoadSceneAsync()
       {
           
            // Start loading the new scene in the background
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
            asyncLoad.allowSceneActivation = false; // Don't switch immediately

            // Wait until the scene is loaded
            while (asyncLoad.progress < 0.9f)
            {
                Debug.Log("Looping");
        
                yield return null;
            }

            Debug.Log("Scene ready, waiting additional delay");

            // ✅ Wait for a short time before switching
            yield return new WaitForSeconds(20f); 
        
            // Finally allow scene activation
            asyncLoad.allowSceneActivation = true;
                  
        }
}


