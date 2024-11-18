using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairTeleport : MonoBehaviour
{
    public GameObject stairLower;
    public GameObject stairUpper;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        if (stairLower)
        {
            Debug.Log("You touched the lower stairs!");
        }
        if (stairUpper)
        {
            Debug.Log("You touched the upper stairs!");
        }
    }
}
