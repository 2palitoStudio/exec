// Goblin.cs
using UnityEngine;

public class Goblin : Enemy
{
    protected override void Start()
    {
        base.Start();
        Hp = 50; // Goblins are weaker
        AttackPower = 5; // Goblins deal less damage
        MovementSpeed = 3f;
        Debug.Log("A Goblin has spawned!");
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Goblin Attacks");
    }

    protected override void Die()
    {
        base.Die();
    }

    public override void OnPlayerInRange(GameObject player)
    {
        MovementSpeed = 4.5f;
        base.OnPlayerInRange(player);
        Debug.Log("Goblin growls and starts following the player!");
    }


}
