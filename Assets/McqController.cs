using Tilia.Interactions.SpatialButtons;
using UnityEngine;

public class McqController : MonoBehaviour
{
       [SerializeField] private SpatialButtonGroupManager var ;
    public void GetActiveButton()
    {
      int buttonIndex = var.ActiveButtonIndex;

       if (buttonIndex != -1)
       {
            Debug.Log($"button index{buttonIndex}");   
        }  
    }


}
