using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializedField] private float attackCooldown;
    [SerializedField] private float range;
    [SerializedField] private int damage;
    [SerializedField] private BoxCollider2D boxCollider;
    [SerializedField] private LayerMask playerLayer;
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
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localSclae.x,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * range * transform.localSclae.x, 
            new Vector3(boxCillider.bounds.size.x *range, boxCillider.bounds.size.y, boxCillider.bounds.size.z));
    }
}
