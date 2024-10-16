using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _guardPosition;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<NPCScript>()?.spoken == true && GetComponent<NPCScript>()?._panel.activeSelf == false)
        {
            _anim.SetBool("Open", true);
            Vector3 direction = _guardPosition.position - transform.position;
            transform.position += (direction * 1 * Time.deltaTime);
        }
    }
}
