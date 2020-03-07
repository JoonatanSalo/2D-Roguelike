using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform LaserFirePoint;

    public float laserAttackRate = 2f;
    float nextAttackTime = 0f;

    public float laserTime = 0.2f;
    float nextLaserTime = 0f;

    public int laserEnergy = 1;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
    }

    
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && GetComponentInParent<EnergyManager>().HasEnoughEnergy(laserEnergy))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
                Debug.DrawLine(transform.position, hit.point);
                LaserFirePoint.position = hit.point;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, LaserFirePoint.position);

                nextAttackTime = Time.time + 1f / laserAttackRate;

                lineRenderer.enabled = true;
                nextLaserTime = Time.time + 1f / laserTime;

                GetComponentInParent<EnergyManager>().GainEnergy(-laserEnergy);
            }
        }

        if (Time.time >= nextLaserTime) 
        {
            lineRenderer.enabled = false;
        }
    }
}
