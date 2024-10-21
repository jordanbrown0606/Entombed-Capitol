using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagglerBox : MonoBehaviour
{
    [SerializeField] private Transform _gateKey;

    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    private Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_collider.bounds.Contains(_gateKey.position))
        {
            objective.Invoke();
            this.enabled = false;
        }
    }
}
