using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Card
{
    private float clickTime = 0;

    public override void OnStart()
    {

    }

    public override void OnDie()
    {

    }

    public void OnMouseDown()
    {
        clickTime = Time.time;
    }

    public void OnMouseUp()
    {
        if(Time.time - clickTime <= ONUITIME)
        {
            
        }
        else
        {

        }
    }
}
