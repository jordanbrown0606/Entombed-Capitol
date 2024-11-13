using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagglerScript : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    [SerializeField] ObjectiveTrigger secondaryObjective = new ObjectiveTrigger();

    public Transform falseBox;
    public Transform trueBox;

    public GameObject gateKey;
    public void MoveFalse()
    {
        gateKey.transform.position = falseBox.position;
    }

    public void MoveTrue()
    {
        gateKey.transform.position = transform.position + new Vector3(-2, 0, 0);
        secondaryObjective.Invoke();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            gameObject.SetActive(false);
            objective.Invoke();
        }
    }

    private void OnDisable()
    {
        if(gateKey.transform.position != trueBox.position)
        {
            gateKey.transform.position = transform.position;
        }
    }
}
