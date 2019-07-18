using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratest : MonoBehaviour {
    float ShakeTimer;
    public bool SW;
    // Use this for initialization
    void Start()
    {
        SW = false;
           ShakeTimer = 3;

    }

    private void Update()
    {
        shit();
    }

    void shit()
    {
        
        if (ShakeTimer >= 0&&SW==true)
        {
            this.transform.localPosition = (Vector3)Random.insideUnitCircle * 0.1f;

            ShakeTimer -= Time.deltaTime;
        }
    }

}
