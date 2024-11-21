using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private Camera _mCamera;

    // Start is called before the first frame update
    void Start()
    {
        _mCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = _mCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Vector3 forward = transform.TransformDirection(Vector3.forward) * 5;
            Debug.DrawRay(transform.position, forward, Color.red, 5f);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask))
            {
                if(hit.transform.gameObject.GetComponent<NPCScript>()?.spoken == false)
                {
                    hit.transform.gameObject.GetComponent<ISpeakable>()?.StartDialogue();
                }
                else if(hit.transform.gameObject.GetComponent<IInteractable>() != null)
                {
                    hit.transform.gameObject.GetComponent < IInteractable>()?.Interact();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
