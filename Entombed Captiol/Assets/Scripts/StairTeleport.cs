using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StairTeleport : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (this.transform.position.y < 10)
        {
            Debug.Log("You touched the lower stairs!");
            player.transform.position = new Vector3(-1.6f, 28.34f, -4.34f);
        }
        if (this.transform.position.y > 10)
        {
            Debug.Log("You touched the upper stairs!");
            player.transform.position = new Vector3(2.39f, 1.1f, 5.56f);
        }
    }
}
