using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    void Start()
    {
        // Assuming you have your own logic to define the points of the polygon
        Vector2[] points = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };

        // Add PolygonCollider2D component if not already added
        PolygonCollider2D polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
        if (polygonCollider == null)
            polygonCollider = gameObject.AddComponent<PolygonCollider2D>();

        // Set the points of the collider
        polygonCollider.points = points;
    }
}
