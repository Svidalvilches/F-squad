using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float range;

    private bool alive;
    


    // Follow Player
    void FollowPlayer()
    {
        alive = true;
        transform.position = player.transform.position;
        if (alive = true)
        {
            Transform.Translate(Vector3, transform.position * speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour 
{
   public AIPath aiPath;
   
   void update()
   {
      if(aiPath.desiredVelocity.x >= 0.01f)
      {
      transform.localScale = new Vector3(-1f, 1f, 1f);
      } else if (aiPath.desiredVelocity.x >= -0.01f)
      {
        transform.localScale = new Vector3(1f, 1f, 1f);
      }
   }
 }  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : monobehaviour 
{

     public Transform target;
     
     public float speed = 200f;
     public float nextWaypointDistance = 3f;
     
     pulbic Transform enemyGFX;
     
     path path;
     int currentWaypoint = 0;
     bool reachedEndOfPath = false;
     
    Seeker seeker;
    Rigidbody2D rb;
    
    void start()
     {
       seeker = GetComponent<Seeker>();
       rb = GetComponent<Rigidbody2D>();
       
       InvokeRepeating("UpdatePath", 0f, .5f);
      }
     
   void UpdatePath()
   {
      if (seeker.IsDone())
      seeker.StartPath(rb.position, target.position, OnPathComplete);
   }
   
   void OnPathComplete(Path p)
     {
        if(!p.error)
        {
           path = p;
           currentWaypoint = 0;
        }
     }
   
   void fixedUpdate()
     {
       if (path == null)
          return;
          
       if(currentWaypoint >= path.vectorPath.Count)   
       {
          reachedEndOfPath = true;
          return; 
       }  else
       {
         reachedEndOfPath = false;
       }
      
       Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb. position).normalized;
       Vector2 force = direction * speed * Time.deltaTime;
       
       rb.AddForce(force);
     
       float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
       
       if (distance < nextWaypointDistance)
       {
         currentWaypoint++;
       }
    
       if(force.x >= 0.01f)
      {
        enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
      } else if (force.x >= -0.01f)
      {
        enemyGFX.localScale = new Vector3(1f, 1f, 1f);
      }
    
    }
 }    
