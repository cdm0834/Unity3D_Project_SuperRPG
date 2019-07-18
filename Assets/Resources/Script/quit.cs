using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {

    float time;
    private void Start()
    {
        time = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
    }

}
