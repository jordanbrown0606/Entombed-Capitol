using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _questBox;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        _player.GetComponent<PlayerMovement>().enabled = false;
        _player.GetComponent<PlayerScript>().enabled = false;
    }

    public void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _player.GetComponent<PlayerMovement>().enabled = true;
        _player.GetComponent<PlayerScript>().enabled = true;
        _questBox.SetActive(true);
    }

}
