using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockMasterScript : MonoBehaviour
{
    [SerializeField] private GameObject _dockMasterTwo;
    [SerializeField] private ObjectiveTrigger _objective;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _shipBox;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NPCScript>()?.spoken == true && _panel.activeSelf == false && _dockMasterTwo != null)
        {
            _dockMasterTwo.SetActive(true);
            _shipBox.GetComponent<MeshRenderer>().enabled = true;
            gameObject.SetActive(false);
        }
        else if (GetComponent<NPCScript>()?.spoken == true && _objective != null)
        {
            _objective.Invoke();
            _shipBox.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
