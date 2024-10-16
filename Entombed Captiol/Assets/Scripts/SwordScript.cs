using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private GameObject _hitbox;

    public void ActivateHitbox()
    {
        _hitbox?.SetActive(true);
    }

    public void DeactivateHitbox()
    {
        _hitbox?.SetActive(false);
    }
}
