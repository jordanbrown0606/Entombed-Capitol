using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendScript : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform _defeatPosition;
    [SerializeField] private GameObject _alchemist;
    [SerializeField] private GameObject _textBox;
    [SerializeField] private Transform _player;

    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();

    private int _health = 1;

    public void TakeDamage(int amount)
    {
        _health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
        if(_alchemist.activeSelf == false)
        {
            transform.position = _defeatPosition.position;
            _textBox.SetActive(true);
        }

        if(_health <= 0)
        {
            gameObject.SetActive(false);
            objective.Invoke();
        }

        _textBox.transform.rotation = Quaternion.LookRotation((_textBox.transform.position - Camera.main.transform.position).normalized);
    }
}
