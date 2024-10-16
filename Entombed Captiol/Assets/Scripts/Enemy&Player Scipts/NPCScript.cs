using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, ISpeakable
{
    [SerializeField] AudioSource _source;
    [SerializeField] public GameObject _panel;

    public bool spoken = false;

    public void StartDialogue()
    {
        _source.Play();
        GetComponent<NPCConversation>().enabled = true;
        _panel.SetActive(true);
        spoken = true;
    }
}
