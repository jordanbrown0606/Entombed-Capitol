using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKey : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private ObjectiveTrigger _objective;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player)
        {
            GameManager.Instance.hasKey = true;
            _objective.Invoke();
            gameObject.SetActive(false);
        }
    }
}
