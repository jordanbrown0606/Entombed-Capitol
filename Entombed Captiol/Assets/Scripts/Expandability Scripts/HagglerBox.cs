using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagglerBox : MonoBehaviour
{
    [SerializeField] private Transform _gateKey;

    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == _gateKey)
        {
            objective.Invoke();
        }
    }
}
