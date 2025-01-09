// EnemyMovement.cs
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Enemy enemy;

    public bool isFacingRight = true;
    private Rigidbody2D rb;

    [Header("Patrol Settings")]
    public float patrolRange = 5f; // Distance the enemy moves left and right
    private float leftEdge;
    private float rightEdge;

    [Header("Player Detection")]
    public float aggroRange = 5f; // Range size
    public string playerTag = "Player"; // Tag for player detection
    private GameObject rangeObject;
    public Color rangeBorderColor = Color.red;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();

        rangeObject = DetectionRangeUtils.CreateDetectionRange(
           gameObject,
           aggroRange,
           rangeBorderColor,
           playerTag,
           OnPlayerDetected
       );

        // Define patrol boundaries based on the enemy's starting position
        leftEdge = transform.position.x - patrolRange;
        rightEdge = transform.position.x + patrolRange;
    }
    void Update()
    {
        if (!enemy.IsDead && !enemy.target)
        {
            Patrol();
        }
        if (!enemy.IsDead && enemy.target)
        {
            FollowTarget();
        }
    }

    protected virtual void FollowTarget()
    {

        Vector3 direction = (enemy.target.position - transform.position).normalized;
        transform.position += direction * enemy.MovementSpeed * Time.deltaTime;

        // Flip sprite based on movement direction
        if (direction.x > 0 && !IsFacingRight())
        {
            Flip();
        }
        else if (direction.x < 0 && IsFacingRight())
        {
            Flip();
        }
    }


    void Patrol()
    {
        // Move the enemy horizontally
        float moveDirection = isFacingRight ? 1 : -1;
        rb.velocity = new Vector2(moveDirection * enemy.MovementSpeed, rb.velocity.y);

        // Check if the enemy has reached the patrol edges
        if (isFacingRight && transform.position.x >= rightEdge)
        {
            Flip();
        }
        else if (!isFacingRight && transform.position.x <= leftEdge)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Flip the direction
        isFacingRight = !isFacingRight;

        // Flip the enemy's sprite by scaling it negatively on the X-axis
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }


    void OnPlayerDetected(GameObject player)
    {
        if (!enemy.IsDead)
        {
            Debug.Log($"{gameObject.name} detected the player: {player.name}");
            enemy.OnPlayerInRange(player);
        }
    }

}
