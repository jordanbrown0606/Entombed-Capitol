using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerObjectiveOnKeypress : MonoBehaviour
{
    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            objective.Invoke();

            this.enabled = false;
        }
    }
}
