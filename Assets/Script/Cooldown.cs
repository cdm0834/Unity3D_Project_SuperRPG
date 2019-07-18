using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {

    public Image[] imageCooldown;
    public float cooldown = 1;
    public bool iscoolDown;
    public bool SkillcoolDown;
    public bool thisobject;
    //bool isAttack;
    private void Start()
    {
        thisobject = true;
    }

    private void Update()
    { 
        if(thisobject==false)
        {
            this.gameObject.SetActive(false);
        }else
        {
            this.gameObject.SetActive(true);
        }

        if(iscoolDown)
        {
            imageCooldown[0].fillAmount += 1 / cooldown * Time.deltaTime;

            if(imageCooldown[0].fillAmount>=1)
            {
                imageCooldown[0].fillAmount = 0;
                iscoolDown = false;
            }
        }else if(SkillcoolDown)
        {
            imageCooldown[1].fillAmount += 1 / (float)5 * Time.deltaTime;

            if (imageCooldown[1].fillAmount >= 1)
            {
                imageCooldown[1].fillAmount = 0;
                SkillcoolDown = false;
            }
        }
        
    }
    
}
