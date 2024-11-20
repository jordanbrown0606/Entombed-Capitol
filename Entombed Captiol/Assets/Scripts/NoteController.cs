using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    public GameObject note;
    public int distanceThreshold;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (player.transform.position, note.transform.position);

        if (Input.GetKeyDown("e") && distance < distanceThreshold)
        {
            Debug.Log("e key was pressed");
            canvas.SetActive(true);
        }

        if (Input.GetKeyDown("escape"))
        {
            canvas.SetActive(false);
        }
    }
}
