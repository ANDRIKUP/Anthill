using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyAboutThreat : MonoBehaviour
{
    private bool threatSeeing = false;
    private Collider2D threat;

    //коэффициент для бега
    [SerializeField]
    private float koefSpeed;

    private ExploreWorld expW;

    void Start()
    {
        expW = GetComponent<ExploreWorld>();
    }
    public bool isThreatSeeing()
    {
        return threatSeeing;
    } 

    public void setThreatSeeing(Collider2D target)
    {
        threatSeeing = true;
        threat = target;
    }

    public void notThreatSeeing()
    {
        threatSeeing = false;
    }

    private List<GameObject> foundWarrior()
    {
        List<GameObject> availableWarr = new List<GameObject>();
        GameObject[] warriors = GameObject.FindGameObjectsWithTag("AntWarrior");
        for (int i = 0; i < warriors.Length; i++)
        {
            if (!warriors[i].transform.root.gameObject.GetComponent<FOVWarrior>().isThreatSeeing())
            {
                availableWarr.Add(warriors[i].transform.root.gameObject);
            }
        }
        if (availableWarr.Count == 0)
        {
            return null;
        }
        // упорядоченный по возрастанию расстояния от текущего муравья
        availableWarr = nearestWarrior(availableWarr);
        return availableWarr;
    }

    private List<GameObject> nearestWarrior(List<GameObject> lst)
    {
        Vector2 current = transform.position;
        List<float> differ = new List<float>();
        for (int i = 0; i < lst.Count; i++)
        {
            float val = Mathf.Sqrt(Mathf.Pow(lst[i].transform.position.x - current.x, 2) + Mathf.Pow(lst[i].transform.position.y - current.y, 2));
            differ.Add(val);
        }
        //Сортировка вставками
        for (int i = 1; i < differ.Count; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (differ[j] < differ[j - 1])
                {
                    float temp = differ[j];
                    differ[j] = differ[j - 1];
                    differ[j - 1] = temp;

                    GameObject tempV = lst[j];
                    lst[j] = lst[j - 1];
                    lst[j - 1] = tempV;
                }
            }
        }
        return lst;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (threatSeeing && threat != null)
        {
            if (foundWarrior() != null)
            {
                GameObject warrior = foundWarrior()[0];
                //для смены направления спрайта
                expW.moveTarget = warrior.transform.position - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, warrior.transform.position, expW.speed * koefSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, warrior.transform.position) < .5f)
                {
                    notThreatSeeing();
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, HomeReturn.home) > 1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, HomeReturn.home, expW.speed * koefSpeed * Time.deltaTime);
                }
            }
        }
        else if (threat == null)
        {
            notThreatSeeing();
        }
    }

    void OnTriggerEnter2D(Collider2D warrior)
    {
        if (warrior.CompareTag("AntWarrior") && threatSeeing && threat != null)
        {
            Debug.Log("Im here");
            notThreatSeeing();
            warrior.GetComponentInParent<FOVWarrior>().setThreat(threat);
        }
    }
}
