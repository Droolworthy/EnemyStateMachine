using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0 )
            Destroy(gameObject);
    }
}
