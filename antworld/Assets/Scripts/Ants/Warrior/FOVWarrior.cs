using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVWarrior : MonoBehaviour
{
    public float radius = 1f;

    bool threatSeeing = false;
    List<Collider2D> threats = new List<Collider2D>();

    CircleCollider2D circleCollider;

    public bool isThreatSeeing()
    {
        return threatSeeing;
    }
    public void notThreatSeeing()
    {
        threatSeeing = false;
    }
    public void removeThreatFromList()
    {
        threats.RemoveAt(0);
    }
    public Collider2D getThreat()
    {
        if (threats.Count > 0)
        {
            return threats[0];
        }
        else return null;
    }

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = radius;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (circleCollider.IsTouching(other))
        {
            if (other.CompareTag("Threat"))
            {
                threatSeeing = true;
                if (!threats.Contains(other))
                {
                    threats.Add(other);
                }
            }
        }
    }
}
