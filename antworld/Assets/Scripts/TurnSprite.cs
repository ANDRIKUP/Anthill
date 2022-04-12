using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSprite : MonoBehaviour
{
    ExploreWorld scr;
    public Sprite spriteLeft, spriteRight;
    void Start()
    {
        scr = GetComponent<ExploreWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= scr.getMoveTarget().x)
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteLeft;
        } 
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = spriteRight;
        }
    }
}
