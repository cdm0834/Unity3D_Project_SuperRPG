using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    public GameObject HelthBarCanvas;
    Image HealthBar;
    public float HelthBarTime;
    public bool Dead;
	// Use this for initialization
	void Start () {
        HelthBarTime = 3f;
        HealthBar = HelthBarCanvas.transform.Find("HealthBar").GetComponent<Image>();
        Dead = false;
    }
	
	// Update is called once per frame
	void Update () {
        HealthBar.fillAmount = (float)GetComponent<State>().HP / (float)GetComponent<State>().MaxHP;
        HealthBarTriger();
    }


    public void HealthBarTriger()
    {
        if (Dead == false)
        {
            HelthBarTime -= Time.deltaTime;
            if (HelthBarTime >= 0)
            {
                HelthBarCanvas.SetActive(true);
            }
            else
            {
                HelthBarCanvas.SetActive(false);
            }
        }
    }
}
