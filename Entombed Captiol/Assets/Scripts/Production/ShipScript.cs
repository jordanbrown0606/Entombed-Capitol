using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField] private ObjectiveTrigger _objectiveOne;
    [SerializeField] private ObjectiveTrigger _objectiveTwo;
    [SerializeField] private Transform _boxOne;
    [SerializeField] private Transform _boxTwo;
    private Collider _storageBox;

    // Start is called before the first frame update
    void Start()
    {
        _storageBox = GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_storageBox != null)
        {
            if(_storageBox.bounds.Contains(_boxOne.position))
            {
                _objectiveOne.Invoke();
            }

            if (_storageBox.bounds.Contains(_boxTwo.position))
            {
                _objectiveTwo.Invoke();
            }
        }
    }
}
