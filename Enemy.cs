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
