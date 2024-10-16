using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] private Transform _respawn;
    [SerializeField] private Animator _anim;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Image _sliderFill;
    public void TakeDamage(int amount)
    {
        _health -= amount;
        UpdateHealthBar();
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(_health <= 0)
        {
            transform.position = _respawn.position;
            _health = 5;
        }

        if(Input.GetMouseButtonDown(0))
        {
            _anim.SetBool("isAttacking", true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            _anim.SetBool("isAttacking", false);
        }
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _health;

        if (_healthBar.value <= 3)
        {
            _sliderFill.color = Color.red;
        }
    }
}
