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
            if (GameManager.Instance.hasKey == true)
            {
                _anim.SetBool("Open", true);
            }
        }
    }
}
