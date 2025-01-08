// Enemy.cs
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    public float AttackPower { get; set; } = 10;
    public float MovementSpeed { get; set; } = 2f;
    public float Hp { get; set; } = 100;
    public bool IsDead { get; set; } = false;

    protected EnemyMovement movement;

    public Transform target; // Target to follow

    protected virtual void Start()
    {
        // Attach or get the EnemyMovement script
        movement = GetComponent<EnemyMovement>();
        if (movement == null)
        {
            movement = gameObject.AddComponent<EnemyMovement>();
        }
    }

    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining HP: {Hp}");

        if (Hp <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()
    {
        Debug.Log($"{gameObject.name} attacks with {AttackPower} power!");
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} Died");
        IsDead = true;
        Destroy(gameObject);
    }

    public virtual void OnPlayerInRange(GameObject player)
    {
        Debug.Log($"{gameObject.name} detected the player: {player.name}");
        target = player.transform; // Set the player as the target
    }
}
