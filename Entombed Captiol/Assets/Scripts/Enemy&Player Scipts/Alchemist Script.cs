using UnityEngine;
using UnityEngine.UI;

public class AlchemistScript : MonoBehaviour, IDamageable
{
    [SerializeField] ObjectiveTrigger objective = new ObjectiveTrigger();
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _endingTrigger;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private Image _sliderFill;

    [SerializeField, Range(0f, 360f)] protected float _fov = 60f;       //Field of view
    [SerializeField, Range(0f, 1f)] protected float _sightRange = 1f;   //Normalised value for the "sensor" child object's sphere collider

    [SerializeField] protected Sensor _sensor;  //A collider that helps dictate how far the character can see and hear

    [SerializeField] protected Color _lineOfSightColour;    //Sets the gizmo colour allowing the user to see what the line of sight is

    private float timer = 0.5f;

    public void TakeDamage(int amount)
    {
        _health -= amount;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (_health <= 0)
        {
            this.gameObject.SetActive(false);
        }

        if(GetComponent<NPCConversation>().enabled == true && GetComponent<NPCConversation>().panel.activeSelf == false)
        {
            _healthBar.gameObject.SetActive(true);
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                if(IsColliderVisible(_target.GetComponent<Collider>()))
                {
                    InitiateAttack();
                    timer = 0.5f;
                }                
            }
        }

        transform.LookAt(_target.transform);
    }

    private void OnDisable()
    {
        objective.Invoke();
        _endingTrigger.SetActive(true);
    }

    private void InitiateAttack()
    {
        GameObject curFireball = Instantiate(_fireballPrefab, transform.position, transform.rotation);
        Vector3 force = _target.transform.position - transform.position;

        curFireball.GetComponent<Rigidbody>().AddForce(force * _speed, ForceMode.Impulse);
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _health;

        if (_healthBar.value <= 3)
        {
            _sliderFill.color = Color.red;
        }
    }

    /// <summary>
    /// Get the true position of the sensor
    /// When an object is a child of another object and its parent's scale is changed
    /// this will change the "true" scale of the child even if the scale does not change in the inspector
    /// This will always return the most accurate version of the position
    /// </summary>
    public Vector3 GetSensorPosition
    {
        get
        {
            if (_sensor == null)
            {
                return Vector3.zero;
            }

            Vector3 pos = _sensor.transform.position;
            pos.x += _sensor.GetSphereCollider.center.x * _sensor.transform.lossyScale.x;
            pos.y += _sensor.GetSphereCollider.center.y * _sensor.transform.lossyScale.y;
            pos.z += _sensor.GetSphereCollider.center.z * _sensor.transform.lossyScale.z;

            return pos;
        }
    }

    /// <summary>
    /// Get the true radius of the sensor
    /// When an object is a child of another object and its parent's scale is changed
    /// this will change the "true" scale of the child even if the scale does not change in the inspector
    /// This will always return the most accurate version of the radius
    /// </summary>
    public float GetSensorRadius
    {
        get
        {
            if (_sensor == null)
            {
                return 0f;
            }

            float sensorRadius = _sensor.GetSphereCollider.radius;

            float radius = Mathf.Max(sensorRadius * _sensor.transform.lossyScale.x, sensorRadius * _sensor.transform.lossyScale.y);
            radius = Mathf.Max(radius, sensorRadius * _sensor.transform.lossyScale.z);

            return radius;
        }
    }



    /// <summary>
    /// If something of interest enters the radius of our sensor we can start to evaluate things about it.
    /// </summary>
    public void OnSensorEvent(TriggerEventType triggerEvent, Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        if (other != null && (triggerEvent == TriggerEventType.Enter || triggerEvent == TriggerEventType.Stay))
        {
            if (IsColliderVisible(other))
            {
                Debug.Log("Player Found");
                _target = other.gameObject;
            }
        }

        //Remove player as target if sensor is exited.
        if (other == null || triggerEvent == TriggerEventType.Exit)
        {
            _target = null;
        }
    }

    /// <summary>
    /// Determines if the object of question is within the field of view
    /// If so, then determine if it is behind a wall or something similar
    /// If the object is within the field of view and is not blocked from line of sight
    /// The agent can see them, and therefore return true
    /// </summary>
    protected bool IsColliderVisible(Collider other)
    {
        Vector3 direction = other.transform.position - GetSensorPosition;
        float angle = Vector3.Angle(transform.forward, direction);

        if (angle > _fov * 0.5f)
        {
            return false;
        }

        RaycastHit hit;

        Debug.DrawRay(GetSensorPosition, direction.normalized * GetSensorRadius * _sightRange);

        if (Physics.Raycast(GetSensorPosition, direction.normalized, out hit, GetSensorRadius * _sightRange))
        {
            Debug.Log(hit.collider.gameObject.name);
            return hit.collider == other;
        }

        return false;
    }

    /// <summary>
    /// Draws an in engine representation of the agent's line of sight
    /// </summary>
    private void OnDrawGizmos()
    {
        if (_sensor == null)
        {
            return;
        }
#if UNITY_EDITOR
        UnityEditor.Handles.color = _lineOfSightColour;
        Vector3 rotatedForward = Quaternion.Euler(0f, -_fov * 0.5f, 0f) * transform.forward;
        UnityEditor.Handles.DrawSolidArc(GetSensorPosition, Vector3.up, rotatedForward, _fov, GetSensorRadius * _sightRange);
#endif
    }
}
