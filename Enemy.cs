using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private Player _target;

    public Player Target => _target;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }
}
