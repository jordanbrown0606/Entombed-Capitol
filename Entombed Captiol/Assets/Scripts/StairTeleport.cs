using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StairTeleport : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _stairsTarget;

    private void OnTriggerEnter(Collider other)
    {
        _player.transform.position = _stairsTarget.position;
        _player.transform.rotation = _stairsTarget.rotation;
    }
}
