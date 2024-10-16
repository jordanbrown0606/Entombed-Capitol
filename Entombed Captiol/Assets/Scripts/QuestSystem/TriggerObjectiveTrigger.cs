using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectiveTrigger : MonoBehaviour
{
    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        objective.Invoke();
    }
}
