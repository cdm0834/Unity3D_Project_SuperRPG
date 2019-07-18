using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public static ObjectPool instance;
    public List<GameObject> ObjectList;
    public List<GameObject> AttackObjectList;
    public GameObject DeadObject;
    public GameObject EnemyAttackObject;

    private void Start()
    {
        EnemyAttackObject = Resources.Load<GameObject>("EnemyHitEffect");
        DeadObject = Resources.Load<GameObject>("DeadBoom");
        ObjectList = new List<GameObject>();
        AttackObjectList = new List<GameObject>();
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


    public GameObject ObjectInstance()
    {
        for (int i = 0; i < ObjectList.Count; ++i)
        {
            if (ObjectList[i].activeSelf == false)
            {
                return ObjectList[i];
            }
        }
        var target = Instantiate(DeadObject, new Vector3(0, 0, 0), Quaternion.identity);
        ObjectList.Add(target);
        return target;
    }


    public void DeadBoomspawn()
    {
        var _obj = ObjectInstance();
        _obj.transform.position = this.transform.position;
        _obj.SetActive(true);
    }

    public void EnemyAttackspawn()
    {
        var _obj = AttackObjectInstance();
        _obj.transform.position = new Vector3(0,1,0.6f);
        _obj.SetActive(true);
    }
}
