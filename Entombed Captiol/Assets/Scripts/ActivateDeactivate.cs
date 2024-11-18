using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateDeactivate : MonoBehaviour
{
    public GameObject canvas;
    public GameObject fire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("e key was pressed");
            canvas.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
        {
            canvas.SetActive(false);
        }
    }

    private void OnTriggerEnter()
    {
        fire.SetActive(true);
    }
}
