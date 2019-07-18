using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamage : MonoBehaviour {
    Collider Enemy;

    private void OnTriggerEnter(Collider other)
    {
        Enemy = other;
        if (Enemy.tag=="Enemy")
        {
            Enemy.GetComponent<State>().HP -= 100;
            Enemy.GetComponent<EnemyHealthBar>().HelthBarTime = 3;
            Enemy.GetComponent<EnemyHealthBar>().Dead = false;
        }


    }

    IEnumerator color()
    {
        if (Enemy.GetComponent<State>().HP > 100 && Enemy.transform.childCount > 0)
        {
            int countTime = 0;
            while (countTime < 1)
            {
                if (countTime % 2 == 0)
                {
                    Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
                }
                else
                    Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = new Color(255, 255, 255, 255);
                yield return new WaitForSeconds(0.2f);
                countTime++;
            }
            Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = new Color32(255, 255, 255, 255);
            yield return null;
        }
    }

}
