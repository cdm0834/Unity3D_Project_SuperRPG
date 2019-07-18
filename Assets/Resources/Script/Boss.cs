using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public bool BossFight;
    List<GameObject> AttackObjectList;
    public GameObject Character;
    [SerializeField] float distance;
    bool move;
    public GameObject EnemyAttackObject;
    [SerializeField] GameObject BossSkill;
    [SerializeField] GameObject BossCamera;
    [SerializeField] bool PowerUp;
    bool swich;
    bool DeadTriger;
    private void Start()
    {
        DeadTriger = true;
        PowerUp = false;
        Character = GameObject.Find("Character");
        move = false;
        EnemyAttackObject = Resources.Load<GameObject>("Effect/EnemyHitEffect");
        AttackObjectList = new List<GameObject>();
        swich = true;
    }

    private void Update()
    {
        CharacterFind();
        BossPowerUp();
    }

    void CharacterFind()
    {

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Character.transform.position, 2.5f * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }

        distance = Vector3.Distance(Character.transform.position, this.transform.position);
        if (BossFight && distance < 20)
        {
            move = true;
            GetComponent<Animator>().SetBool("Run", true);

            if (distance < 4f)
            {
                transform.LookAt(Character.transform);
                move = false;
                GetComponent<Animator>().SetBool("Run", false);
                if(PowerUp == false)
                {
                    GetComponent<Animator>().SetBool("Attack", true);
                }else
                {
                    GetComponent<Animator>().SetBool("Attack", false);
                    GetComponent<Animator>().SetBool("ComboSkill", true);
                }

            }
            else
            {
                move = true;
                transform.LookAt(Character.transform);
                GetComponent<Animator>().SetBool("Run", true);
                if (PowerUp == false)
                {
                    GetComponent<Animator>().SetBool("Attack", false);
                }
                else
                {

                    GetComponent<Animator>().SetBool("ComboSkill", false);
                }

            }
        }
    }

    public GameObject AttackObjectInstance()
    {
        for (int i = 0; i < AttackObjectList.Count; ++i)
        {
            if (AttackObjectList[i].activeSelf == false)
            {
                return AttackObjectList[i];
            }
        }
        GameObject target = Instantiate(EnemyAttackObject, new Vector3(0, 0, 0), Quaternion.identity);
        AttackObjectList.Add(target);
        return target;
    }

    public void EnemyAttackspawn()
    {
        var _obj = AttackObjectInstance();
        _obj.transform.parent = this.transform;
        _obj.transform.localPosition = new Vector3(0, 0.45f, 0.8f);
        _obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        SoundManager.Smanager.PlaySE("HitSound1");
        _obj.SetActive(true);
    }

    public void BossAttack()
    {
        SoundManager.Smanager.PlaySE("BossAttack");
        EnemyAttackspawn();
    }

    public void BossAttack2()
    {
        StartCoroutine(BossSkillObject());
    }
    void BossPowerUp()
    {
        if(this.transform.GetComponent<State>().HP<=200)
        {
            StartCoroutine(BossPowerUpCamera());
            PowerUp = true;
        }
    }

    IEnumerator BossSkillObject()
    {
        BossSkill.transform.position = GameObject.Find("SkillPosition").transform.position;
        BossSkill.SetActive(true);
        SoundManager.Smanager.PlaySE("AttackGround");
        yield return new WaitForSeconds(1f);
        BossSkill.SetActive(false);
    }

    IEnumerator BossPowerUpCamera()
    {
        if (swich == true)
        {
            BossFight = false;
            BossCamera.transform.position = GameObject.Find("CameraPosition").transform.position;
            BossCamera.transform.rotation = GameObject.Find("CameraPosition").transform.rotation;
            BossCamera.SetActive(true);
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().Play("PowerUp");
            SoundManager.Smanager.PlaySE("Boss_PowerUp");
            yield return new WaitForSeconds(2f);
            BossCamera.SetActive(false);
            BossFight = true;
            swich = false;
        }
    }


    public IEnumerator BossDead()
    {
        if (DeadTriger)
        {
            DeadTriger = false;
            GameObject.Find("BossCanvas").SetActive(false);
            GetComponent<Boss>().BossFight = false;
            GetComponent<Animator>().SetBool("ComboSkill", false);
            BossCamera.SetActive(true);
            GetComponent<Animator>().SetBool("Dead", true);
            SoundManager.Smanager.PlaySE("Boss_Dead");
            yield return new WaitForSeconds(3f);
            FindObjectOfType<State>().DeadBoomspawn();
            this.gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
            yield return new WaitForSeconds(1f);
            BossCamera.SetActive(false);
            ; QuestScript.Quest.Iq2 += 1;
            Destroy(this.gameObject);
            SoundManager.Smanager.BgmNum += 1;
            SoundManager.Smanager.bgmOn = true;
        }
    }
}
