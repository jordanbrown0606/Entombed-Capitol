using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteController : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _note;
    [SerializeField] private ObjectiveTrigger _objective;

    public void Interact(GameObject interactor)
    {
        _note.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(_note.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _objective.Invoke();
                _note.SetActive(false);
            }
        }
    }
}
