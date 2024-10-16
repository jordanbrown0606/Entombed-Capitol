using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaMove : MonoBehaviour
{
    [SerializeField] private Transform _dungeonSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = _dungeonSpawn.position;
            other.transform.rotation = _dungeonSpawn.rotation;
            RenderSettings.fog = false;
        }
    }
}
