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
    public void setThreat(Collider2D threat)
    {
        threatSeeing = true;
        threats.Add(threat);
        checkNearest();
    }
    
    private void checkNearest()
    {
        if (threats.Count == 0)
        {
            return;
        }
        // расстояние между муравьём и первой известной угрозой
        float diffFirst = Mathf.Sqrt(Mathf.Pow(threats[0].transform.position.x - transform.position.x, 2) + Mathf.Pow(threats[0].transform.position.y - transform.position.y, 2));
        // расстояние между муравьём и новой найденной угрозой
        float diffLast = Mathf.Sqrt(Mathf.Pow(threats[threats.Count - 1].transform.position.x - transform.position.x, 2) + Mathf.Pow(threats[threats.Count - 1].transform.position.y - transform.position.y, 2));
        if (diffFirst > diffLast)
        {
            Collider2D temp = threats[0];
            threats[0] = threats[threats.Count - 1];
            threats[threats.Count - 1] = temp;
        }
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
                    checkNearest();
                }
            }
        }
    }
}
