using Tilia.Visuals.Tooltip;
using UnityEngine;

public class ReadLabel : MonoBehaviour
{
    [Tooltip("The GameObject that contains the TooltipFacade component.")]
    [SerializeField]
    private TooltipFacade tooltipObject;

    public void GetTooltipText()
    {
        if (tooltipObject != null)
        {
            string tooltipText = tooltipObject.TooltipText;
            Debug.Log(tooltipText);
        }

    }


}
