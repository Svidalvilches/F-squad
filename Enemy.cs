using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializedField] private float attackCooldown;
    [SerializedField] private int damage;
    private float cooldownTimer = Math.Infinity;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attactCooldown)
            {
                //Atack
            }
        }
    }
        

    private bool PlayerInSight()
    {
        return false;
    }
}