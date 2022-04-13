using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirrectSprite : MonoBehaviour
{
    ExploreWorld scr;
    void Start()
    {
        scr = GetComponent<ExploreWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scr.getMoveTarget().x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (scr.getMoveTarget().x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
