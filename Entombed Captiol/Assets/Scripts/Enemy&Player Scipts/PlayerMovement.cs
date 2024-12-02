using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _maxForce;
    [SerializeField] private float _lookRotation;
    [SerializeField] private Vector2 _move, _look;
    private Rigidbody _rb;
    private Camera _mCamera;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _mCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");

        Vector3 currentVelocity = _rb.velocity;
        Vector3 targetVelocity = new Vector3(_move.x, 0, _move.y) * _speed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = (targetVelocity - new Vector3(currentVelocity.x, 0, currentVelocity.z));
        Vector3.ClampMagnitude(velocityChange, _maxForce);

        _rb.AddForce(new Vector3(velocityChange.x, 0, velocityChange.z), ForceMode.VelocityChange);

        //Vector3 offset = new Vector3(horizontal, 0, vertical);
        //transform.position += offset * speed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        _look.x = Input.GetAxis("Mouse X");
        _look.y = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * _look.x * _sensitivity);

        _lookRotation += (-_look.y * _sensitivity);
        _lookRotation = Mathf.Clamp(_lookRotation, -90, 90);

        _mCamera.transform.eulerAngles = new Vector3(_lookRotation, _mCamera.transform.eulerAngles.y, _mCamera.transform.eulerAngles.z);
    }
}
