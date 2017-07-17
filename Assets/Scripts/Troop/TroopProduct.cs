using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopProduct : TroopManager
{
    private float timeCountDown = -1;

    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(timeCountDown == -1)
            timeCountDown = timeProductFood;

        if (isDie)
            return;

        if (isRun)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        timeCountDown -= Time.deltaTime;

        if (timeCountDown <= 0)
        {
            timeCountDown = timeProductFood;
            Shop.instance.RegendFood((int)foodProduct);
        }


    }
}
