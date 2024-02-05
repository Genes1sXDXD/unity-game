using System.Collections;
using System.Collections.Generic;
// PlayerController.cs

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float miningRange = 1f;
    public LayerMask mineralLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Mine();
        }
    }

    private void Mine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, mineralLayer);

        if (hit.collider != null)
        {
            MineralScript mineral = hit.collider.GetComponent<MineralScript>();
            if (mineral != null)
            {
                float distance = Vector2.Distance(transform.position, hit.point);

                if (distance <= miningRange)
                {
                    int damage = GetToolDamage();
                    mineral.Mine(damage);
                }
            }
        }
    }

    private int GetToolDamage()
    {
        // Implement logic to determine tool damage based on equipped tool (axe, pickaxe).
        // For simplicity, you can return a constant value for now.
        return 10;
    }
}
