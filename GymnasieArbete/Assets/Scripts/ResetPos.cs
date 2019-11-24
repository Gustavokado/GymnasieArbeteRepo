using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetPos : RaycastController
{

    public LayerMask passengerMask;

    public Vector3 resetPosition;

    public float faceX;
    public float faceY;
    
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
        if (faceY != 0)
        {
            float rayLength = skinWidth;

            for (int i = 0; i < verticalRayCount; i++)
            {
                Vector2 rayOrigin = (faceY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
                rayOrigin += Vector2.right * (verticalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * faceY, rayLength, passengerMask);

                if (hit && hit.distance != 0)
                {
                    hit.transform.position = resetPosition;
                }
            }
        }

        // Horizontally facing spikes
        if (faceX != 0)
        {
            float rayLength = skinWidth;

            for (int i = 0; i < horizontalRayCount; i++)
            {
                Vector2 rayOrigin = (faceX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
                rayOrigin += Vector2.up * (horizontalRaySpacing * i);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * faceX, rayLength, passengerMask);

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