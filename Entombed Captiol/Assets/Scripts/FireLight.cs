using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public GameObject fire;

    void OnTriggerEnter(Collider other)
    {
        fire.SetActive(true);
    }
}
