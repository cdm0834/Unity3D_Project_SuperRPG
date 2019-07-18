using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
    public int HP;
    public int MaxHP;
    State PlayerState;
    Monster_Script MonsScript;
    Test_Monster_Script TestMonsScript;
    int ThisgameObj;
    public List<GameObject> ObjectList;
    public List<GameObject> AttackObjectList;
    public GameObject DeadObject;
    public GameObject EnemyAttackObject;
    GameObject Player;
    [SerializeField] GameObject BossCamera;
   
    // Use this for initialization

    void Start()
    {
        Player = GameObject.Find("Character");
        EnemyAttackObject = Resources.Load<GameObject>("Effect/EnemyHitEffect");
        DeadObject = Resources.Load<GameObject>("Effect/DeadBoom");
        ObjectList = new List<GameObject>();
        AttackObjectList = new List<GameObject>();

        if (this.tag == "Player")
        {
            HP = 3500;
            MaxHP = 3500;
        }
        else if(this.tag=="Boss")
        {
            HP = 1000;
            MaxHP = 1000;
        }
        else
        {
            HP = 500;
            MaxHP = 500;
        }
        PlayerState = GameObject.Find("Character").GetComponent<State>();
        MonsScript = GameObject.Find("MapObject").GetComponent<Monster_Script>();
        //TestMonsScript = GameObject.Find("Plane").GetComponent<Test_Monster_Script>();

        if (this.tag != "Player" && tag != "Boss")
        { 
            ThisgameObj = int.Parse(this.name);
        }
    }

    public void EnemyAttack()
    {
        EnemyAttackspawn();
        PlayerState.HP -= 50;
    }


    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && MonsScript.Monsters[ThisgameObj] != null && this.tag != "Player" && tag != "Boss")
        {
            DeadBoomspawn();
            QuestScript.Quest.Iq1+=1;
            Destroy(MonsScript.Monsters[ThisgameObj]);
            MonsScript.Monsters[ThisgameObj] = null;
        }
        else if (HP <= 0 && this.tag == "Player")
        {
            GetComponent<EnemyHealthBar>().Dead = true;
            Destroy(this.gameObject);
        }else if(HP <= 0 && this.tag == "Boss")
        {
            StartCoroutine(FindObjectOfType<Boss>().BossDead());
        }
    }


    public GameObject AttackObjectInstance()//타격시 피격 이펙트
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


    public GameObject DeadObjectInstance() //죽을때 폭발 이펙트 오브젝트풀
    {
        for (int i = 0; i < ObjectList.Count; ++i)//배열의 i번째 오브젝트가 비활성화 되있으면 그 오브젝트 리턴 없으면 새로 생성
        {
            if (ObjectList[i].activeSelf == false)
            {
                return ObjectList[i];
            }
        }
        GameObject target = Instantiate(DeadObject, new Vector3(0, 0, 0), Quaternion.identity);
        ObjectList.Add(target);
        return target;
    }


    public void DeadBoomspawn() //죽을때 폭발 이펙트 생성
    { 
        GameObject _obj = DeadObjectInstance();
        _obj.transform.position = this.transform.position;
        _obj.SetActive(true);
        int random = Random.Range(1, 3);
        SoundManager.Smanager.PlaySE("Boom" + random);
    }

    public void EnemyAttackspawn()
    {
        var _obj = AttackObjectInstance();
        _obj.transform.parent = this.transform;
        _obj.transform.localPosition = new Vector3(0,0.8f,0.8f);
        SoundManager.Smanager.PlaySE("HitSound1");
        _obj.SetActive(true);
    }
}
