using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorScript : MonoBehaviour
{
    [SerializeField] private GameObject _mayorTwo;
    [SerializeField] private ObjectiveTrigger _objective;
    [SerializeField] private GameObject _panel;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NPCScript>()?.spoken == true && _panel.activeSelf == false && _mayorTwo != null)
        {
            _mayorTwo.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(GetComponent<NPCScript>()?.spoken == true && _objective != null)
        {
            _objective.Invoke();
        }
    }
}
