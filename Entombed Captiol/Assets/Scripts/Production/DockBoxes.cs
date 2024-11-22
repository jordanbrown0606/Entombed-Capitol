using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockBoxes : MonoBehaviour, IInteractable
{
    [SerializeField] ObjectiveTrigger _objective;
    public void Interact(GameObject interactor)
    {
        if(gameObject.transform.IsChildOf(interactor.transform))
        {
            gameObject.transform.parent = null;
        }
        else
        {
            gameObject.transform.SetParent(interactor.transform, true);
            _objective.Invoke();
        }
    }

    private void Update()
    {
        if (gameObject.transform.parent != null)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
