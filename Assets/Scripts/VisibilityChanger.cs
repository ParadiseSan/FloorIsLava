using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityChanger : MonoBehaviour
{
    // The radius of the sphere cast
    public float sphereRadius = 1.0f;
    // The maximum distance of the sphere cast
    public float maxDistance = 10.0f;
    // The layer mask to filter which objects the sphere cast will detect
    public LayerMask layerMask;
    // The new alpha value to set on the collided objects
    public float newAlpha = 0.5f;

    private HashSet<Renderer> affectedRenderers = new HashSet<Renderer>();

    void Update()
    {
        // Perform the sphere cast
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, sphereRadius, transform.forward, maxDistance, layerMask);
        HashSet<Renderer> currentFrameRenderers = new HashSet<Renderer>();


        // Iterate through all the hits
        foreach (RaycastHit hit in hits)
        {
            // Get the renderer of the hit object
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Change the alpha value of the material
                ChangeAlpha(renderer.material, newAlpha);
                currentFrameRenderers.Add(renderer);
            }
        }

        foreach (Renderer renderer in affectedRenderers)
        {
            if (!currentFrameRenderers.Contains(renderer))
            {
                ChangeAlpha(renderer.material, 1.0f);
            }
        }

        // Update the affected renderers set
        affectedRenderers = currentFrameRenderers;
    }

    void ChangeAlpha(Material material, float alpha)
    {
        if (material.HasProperty("_Color"))
        {
            Color color = material.color;
            color.a = alpha;
            material.color = color;
        }
        else if (material.HasProperty("_BaseColor")) // For HDRP or URP materials
        {
            Color color = material.GetColor("_BaseColor");
            color.a = alpha;
            material.SetColor("_BaseColor", color);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, sphereRadius);


        Vector3 endPosition = transform.position + transform.forward * maxDistance;
        Gizmos.DrawWireSphere(endPosition, sphereRadius);
        Gizmos.DrawLine(transform.position, endPosition);
    }
}
