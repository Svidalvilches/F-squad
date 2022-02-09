using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float attackCooldown;
    private float range;
    private int damage;
    private BoxCollider2D boxCollider;
    private LayerMask playerLayer;
    private float cooldownTimer = Math.Infinity;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //Atack
            }
        }
    }
        

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * range * transform.localScale.x, 
            new Vector3(boxCollider.bounds.size.x *range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
