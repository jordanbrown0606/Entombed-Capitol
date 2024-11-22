using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptiolTriggerScript : MonoBehaviour
{
    [SerializeField] private Transform _gatePosition;
    [SerializeField] private GameObject _gateText;


    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.hasKey == false && other.CompareTag("Player"))
        {
            other.transform.position = _gatePosition.position;
            other.transform.rotation = _gatePosition.rotation;
            StartCoroutine(GateText());
        }
    }

    IEnumerator GateText()
    {
        _gateText.SetActive(true);
        yield return new WaitForSeconds(2f);
        _gateText.SetActive(false);
    }
}
