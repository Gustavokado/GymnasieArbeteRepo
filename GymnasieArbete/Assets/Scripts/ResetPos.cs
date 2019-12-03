using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetPos : RaycastController
{

    public LayerMask passengerMask;

    public Vector3 resetPosition;

    public bool faceX;
    public bool faceY;
    
    public override void Start()
    {
        base.Start();
        UpdateRaycastOrigins();
    }

    void Update()
    {
        TransferPlayer();
    }  

    void TransferPlayer()
    {
        
        // Vertically facing spikes
        if (faceY)
        {
            float rayLength = skinWidth * 2;

            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = raycastOrigins.bottomLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * -1, rayLength, passengerMask);

                if (hit && hit.distance != 0)
                {
                    hit.transform.position = resetPosition;
                }

                rayOrigin = raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                hit = Physics2D.Raycast(rayOrigin, Vector2.up, rayLength, passengerMask);

                if (hit && hit.distance != 0)
                {
                    hit.transform.position = resetPosition;
                }                
            }
        }

        // Horizontally facing spikes
        if (faceX)
        {
            float rayLength = skinWidth * 2;

            for (int i = 0; i < horizontalRayCount; i++)
            {
                Vector2 rayOrigin = raycastOrigins.bottomLeft;
                rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * -1, rayLength, passengerMask);

                if (hit && hit.distance != 0)
                {
                    hit.transform.position = resetPosition;
                }
                rayOrigin = raycastOrigins.bottomRight;
                rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                hit = Physics2D.Raycast(rayOrigin, Vector2.right, rayLength, passengerMask);

                if (hit && hit.distance != 0)
                {
                    hit.transform.position = resetPosition;
                }
            }
        }      
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float size = .3f;
        
        Gizmos.DrawLine(resetPosition - Vector3.up * size, resetPosition + Vector3.up * size);
        Gizmos.DrawLine(resetPosition - Vector3.left * size, resetPosition + Vector3.left * size);
    }
}