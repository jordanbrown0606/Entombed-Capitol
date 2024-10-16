using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    [SerializeField] GameObject _endingCanvas;

    private void OnTriggerEnter(Collider other)
    {
        _endingCanvas.SetActive(true);
    }
}
