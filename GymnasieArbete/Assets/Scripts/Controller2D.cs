using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Controller2D : MonoBehaviour
{
    const float skinWidth = .015f;

    BoxCollider2D collider;
    RaycastOrigins raycasyOrigins;
    
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand(skinWidth * -2);

        raycasyOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycasyOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycasyOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycasyOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }


  
}
