using Tilia.Visuals.Tooltip;
using UnityEngine;

public class ReadLabel : MonoBehaviour
{
    [Tooltip("The GameObject that contains the TooltipFacade component.")]
    [SerializeField]
    private TooltipFacade tooltipObject;

    // private void Start()
    // {
    //     if (tooltipObject == null)
    //     {
    //         Debug.LogError("Tooltip object is not assigned.");
    //         return;
    //     }
    

    //     // tooltip = tooltipObject.GetComponent<TooltipFacade>();

    //     // if (tooltip == null)
    //     // {
    //     //     Debug.LogError("TooltipFacade component not found on the assigned GameObject.");
    //     //     return;
    //     // }

    
    //     string tooltipText = tooltipObject.TooltipText;
    //     Debug.Log("Tooltip Text: " + tooltipText);
    // }


    public void GetTooltipText()
    {
        if (tooltipObject != null)
        {
            string tooltipText = tooltipObject.TooltipText;
            Debug.Log(tooltipText);
        }

    }


}
