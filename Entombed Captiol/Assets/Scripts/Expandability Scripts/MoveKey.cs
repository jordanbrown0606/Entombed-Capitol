using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKey : MonoBehaviour
{
    [SerializeField] private Transform _trueBox;
    [SerializeField] private GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            gameObject.transform.position = _trueBox.position;
        }
    }
}
