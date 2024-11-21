using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HagglerScript : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    [SerializeField] ObjectiveTrigger secondaryObjective = new ObjectiveTrigger();

    public GameObject gateKey;
    public void MoveTrue()
    {
        gateKey.transform.position = transform.position + new Vector3(-1, 0, 2);
        secondaryObjective.Invoke();
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            objective.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if(GameManager.Instance.hasKey == false)
        {
            gateKey.transform.position = transform.position;
        }
    }
}
