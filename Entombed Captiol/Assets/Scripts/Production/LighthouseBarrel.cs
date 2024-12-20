using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseBarrel : MonoBehaviour, IInteractable
{
    [SerializeField] private ObjectiveTrigger _objective;

    public void Interact(GameObject interactor)
    {
        _objective.Invoke();
    }
}
