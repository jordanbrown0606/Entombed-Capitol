using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerObjectiveOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();


    public void OnPointerClick(PointerEventData eventData)
    {
        objective.Invoke();

        this.enabled = false;
    }
}
