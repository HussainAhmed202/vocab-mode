using UnityEngine;
using System.Collections.Generic;
using Tilia.Interactions.SpatialButtons;

public class LocationSelectionManager : MonoBehaviour
{
    [SerializeField] private SpatialButtonGroupManager buttonGroupManager;
    private Dictionary<int, string> sceneDictionary = new Dictionary<int, string>();

    void Start()
    {
        // Populate the dictionary with scene mappings
        sceneDictionary.Add(0, "Restaurant");
        sceneDictionary.Add(1, "House");
        sceneDictionary.Add(2, "School");
        sceneDictionary.Add(3, "Library");
        sceneDictionary.Add(4, "Train");
    }

    void Update()
    {
        if (buttonGroupManager != null)
        {
            int activeIndex = buttonGroupManager.ActiveButtonIndex;
            if (sceneDictionary.ContainsKey(activeIndex))
            {
                Debug.Log($"Active Scene: {sceneDictionary[activeIndex]}");
            }
            else
            {
                Debug.Log("No scene mapped to the active button index.");
            }
        }
        else
        {
            Debug.LogError("ButtonGroupManager is not assigned.");
        }
    }
}
