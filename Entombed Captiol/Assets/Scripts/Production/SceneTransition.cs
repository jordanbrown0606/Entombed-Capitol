using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Transform _scenePosition;
    [SerializeField] private Transform _player;
    private void OnTriggerEnter(Collider other)
    {
        _player.position = _scenePosition.position;
        _player.rotation = _scenePosition.rotation;
    }
}
