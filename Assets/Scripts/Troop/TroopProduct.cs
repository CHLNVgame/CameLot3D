using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopProduct : TroopManager
{
    private float timeCountDown;

    private void Start()
    {
        timeCountDown = timeProductFood;
    }
    // Update is called once per frame
    void Update()
    {
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
