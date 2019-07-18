using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour {

    GameObject player;
    NavMeshAgent nav;
    bool isHit;
    GameObject Enemy;
    State state;
    private void Update()
    {
        Gizmo();
    }


    void Gizmo()
    {
        float maxDistance = 1;
        Vector3 LayPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Vector3 BoxScale = new Vector3(1, 1, 1);
        RaycastHit hit;
        //Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절판 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
        isHit = Physics.BoxCast(LayPos, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance);

        Gizmos.color = Color.red;
        if (isHit && (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Boss"))
        {
            Enemy = hit.transform.gameObject;
        }
    }


    public void Attack()
    {
        state = GameObject.Find("Character").GetComponent<State>();
        if (isHit && Enemy.tag=="Enemy")
        {
            StartCoroutine(Effect());
            StartCoroutine(color());
            Enemy.GetComponent<State>().HP -= 100;
            SoundManager.Smanager.PlaySE("Enemy_hit");
            Enemy.GetComponent<EnemyHealthBar>().HelthBarTime = 3;
            Enemy.GetComponent<EnemyHealthBar>().Dead = false;
            //state.PlayerAttack();
        }
        else if(isHit && Enemy.tag == "Boss")
        {
            StartCoroutine(Effect());
            StartCoroutine(color());
            Enemy.GetComponent<State>().HP -= 100;
        }
        else
        {
            Debug.Log("miss");
        }
    }

    public void Skill1()
    {
        StartCoroutine(SkillEffect());
    }

    IEnumerator Effect()
    {
        transform.Find("HitEffect").gameObject.SetActive(true);
        SoundManager.Smanager.PlaySE("HitSound1");
        yield return new WaitForSeconds(1f);
        transform.Find("HitEffect").gameObject.SetActive(false);
    }

    IEnumerator SkillEffect()
    {
        GameObject Skill1 = GameObject.Find("SkillObject").transform.Find("Skill1").gameObject;
        Skill1.SetActive(true);
        Skill1.transform.position = this.transform.position;
        yield return new WaitForSeconds(2f);
        Skill1.SetActive(false);
    }

    IEnumerator color()
    {
        if (Enemy.GetComponent<State>().HP > 100 && Enemy.transform.GetChild(0) != null)
        {
            int countTime = 0;
            while (countTime < 3)
            {
                if (countTime % 2 == 0)
                {
                    Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Color.red;
                }
                else
                    Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = new Color(255, 255, 255, 255);
                yield return new WaitForSeconds(0.05f);
                countTime++;
            }
            Enemy.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = new Color32(255, 255, 255, 255);
            yield return null;
        }
    }
}      



