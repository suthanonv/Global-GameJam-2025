using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineRendererCollider : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<BoxCollider2D> colliders = new List<BoxCollider2D>();

    [Header("Collider Settings")]
    public float colliderWidthMultiplier = 1.1f; // Multiplies the LineRenderer width for collider thickness
    public bool isTrigger = true; // Should the colliders act as triggers?

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateColliders();
    }

    public void UpdateColliders()
    {
        ClearColliders();

        int pointsCount = lineRenderer.positionCount;
        if (pointsCount < 2)
        {
            Debug.LogWarning("LineRenderer must have at least 2 points to create colliders.");
            return;
        }

        for (int i = 0; i < pointsCount - 1; i++)
        {
            Vector3 start = lineRenderer.GetPosition(i);
            Vector3 end = lineRenderer.GetPosition(i + 1);

            CreateColliderBetweenPoints(start, end);
        }
    }

    private void CreateColliderBetweenPoints(Vector3 start, Vector3 end)
    {
        GameObject colliderObject = new GameObject("LineCollider2D");
        colliderObject.transform.SetParent(transform);

        BoxCollider2D boxCollider = colliderObject.AddComponent<BoxCollider2D>();
        colliders.Add(boxCollider);

        // Calculate collider position, size, and rotation
        Vector2 midPoint = (start + end) / 2;
        float length = Vector2.Distance(start, end);
        float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * Mathf.Rad2Deg;

        colliderObject.transform.position = midPoint;
        colliderObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        boxCollider.size = new Vector2(length, lineRenderer.startWidth * colliderWidthMultiplier);

        // Configure collider properties
        boxCollider.isTrigger = isTrigger;
    }

    private void ClearColliders()
    {
        foreach (BoxCollider2D collider in colliders)
        {
            if (collider != null)
            {
                Destroy(collider.gameObject);
            }
        }
        colliders.Clear();
    }

}
