using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : RaycastController
{
    float faceX;
    public Player player;
    public float speed;

    public LayerMask obstaclesMask;

    public override void Start()
    {
        base.Start();
        player = GameObject.Find("player").GetComponent<Player>();
        faceX = player.GetFaceDir();
    }

    void Update()
    {
        UpdateRaycastOrigins();

        Vector3 velocity = Move();
       
        CheckIfHit(velocity);

        transform.Translate(velocity);
    }

    Vector3 Move()
    {
        Vector3 newPos = transform.position;
        newPos.x += speed * Time.deltaTime * faceX;
        return newPos - transform.position;
    }

    void CheckIfHit(Vector3 velocity)
    {
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (faceX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * faceX, rayLength, obstaclesMask);

            if (hit && hit.distance != 0)
            {
                Destroy(gameObject);

                if (hit.collider.tag == "Destructible")

                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
