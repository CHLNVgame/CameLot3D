using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopDefend : TroopManager {

    private float nextActtack = 0f;
    // Update is called once per frame
    void Update()
    { 
        if (isRun)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
