using UnityEngine;

public class DoorMove : MonoBehaviour
{
    [SerializeField] private Vector3 _move;
    [SerializeField] private GameObject _alchemist;
    [SerializeField] private GameObject _prisoner;

    // Update is called once per frame
    void Update()
    {
        if(_alchemist.activeSelf == false)
        {
            transform.localPosition += _move;
            _prisoner?.SetActive(false);
        }
    }
}
