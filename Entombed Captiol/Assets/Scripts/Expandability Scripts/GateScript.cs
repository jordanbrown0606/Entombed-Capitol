using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] private Collider _trueBox;
    [SerializeField] private Transform _gateKey;
    [SerializeField] private Animator _anim;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (_trueBox.bounds.Contains(_gateKey.position))
            {
                _anim.SetBool("Open", true);
            }
        }
    }
}
