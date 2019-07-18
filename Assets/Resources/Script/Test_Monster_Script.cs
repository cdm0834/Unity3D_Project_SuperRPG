﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Test_Monster_Script : MonoBehaviour {

    public GameObject[] Monsters;
    float HP;
    float MP;
    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    bool triger;
    [SerializeField] bool Looktriger;
    Vector3[] monsterpos;
    State PlayerState;
    [SerializeField] float distance;
    [SerializeField] float[] Monsterdis;

    private void Update()
    {
        MoveToTarget();
    }


    private void Start()
    {
        int MonsterCount = 5;
        Monsters = new GameObject[MonsterCount];
        triger = false;
        float J = 0;
        for (int i=0; i< MonsterCount; i++)
        {
            int random = Random.Range(1, 6);
            GameObject Monster = Resources.Load("Goblin/Goblin" + random) as GameObject;
            GameObject obj = Instantiate(Monster);
            Monsters[i] = obj;
            Monsters[i].name = i.ToString();
        }

        for (int i = 0; i < Monsters.Length; i++)
        {
            if (Monsters[i] != null)
            {
                Monsters[i].transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
  


        for(int i = 0; i< Monsters.Length; i++)
        {
            if (Monsters[i] != null)
            {
                Monsters[i].transform.position = new Vector3(J, 0, 0);
                J += 1.5f;
                //Monsters[i].transform.position = monsterpos[i];
                Monsters[i].transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }

        //Monsters[0].transform.position = new Vector3(115f, 10f, 113f);
        //Monsters[1].transform.position = new Vector3(113f, 10f, 115f);
        //Monsters[2].transform.position = new Vector3(117f, 10f, 114f);
        //Monsters[3].transform.position = new Vector3(117f, 10f, 116f);
        //Monsters[4].transform.position = new Vector3(115f, 10f, 117f);

       
    }

  

    public void MoveToTarget()
    {
        float J = 0;
        target = GameObject.Find("Character").transform;
        GameObject position = GameObject.Find("Position");
        distance = Vector3.Distance(target.position,position.transform.position);
        Monsterdis = new float[Monsters.Length];


        for (int i = 0; i < Monsters.Length; i++)
        {
            if (Monsters[i] != null)
            {
                Monsterdis[i] = Vector3.Distance(target.position, Monsters[i].transform.position);
            }
        }

        if (Looktriger==true)
        {
            for (int i = 0; i < Monsters.Length; i++)
            {
                if (Monsters[i] != null)
                {
                    // Monsters[i].transform.rotation = Quaternion.Lerp(Monsters[i].transform.rotation,Quaternion.LookRotation(target.transform.position),10f * Time.deltaTime);
                    // Monsters[i].transform.rotation = Quaternion.Lerp(Monsters[i].transform.rotation,target.transform.rotation,Time.deltaTime * 5f);
                    Monsters[i].transform.LookAt(target.transform);
                    Monsterdis[i] = Vector3.Distance(target.position, Monsters[i].transform.position);
                }
            }
        }else
        {
            for (int i = 0; i < Monsters.Length; i++)
            {
                Monsters[i].transform.rotation = Monsters[i].transform.rotation;
            }
        }

        if (distance <= 40f)
        {
            Looktriger = true;

            if (distance<=10)
            {
                triger = true;
            }
        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            //velocity = 0.0f;
            triger = false;
            Looktriger = false;
        }


        if(triger==true&&Looktriger==true)
        {
            for (int i = 0; i < Monsters.Length; i++)
            {
                if (Monsters[i] != null)
                {
                    if (Monsterdis[i] <= 1.5f)
                    {
                        Monsters[i].transform.LookAt(target.transform);
                        //Monsters[i].transform.rotation = Quaternion.Lerp(Monsters[i].transform.rotation, Quaternion.LookRotation(target.transform.position), 10f * Time.deltaTime);
                        Monsters[i].transform.position = Monsters[i].transform.position;
                        Monsters[i].GetComponent<Animator>().SetBool("Run", false);
                        Monsters[i].GetComponent<Animator>().SetBool("Attack", true);


                    }
                    else
                    {

                        Monsters[i].transform.position = Vector3.MoveTowards(Monsters[i].transform.position, target.position, 2.5f * Time.deltaTime);
                        Monsters[i].GetComponent<Animator>().SetBool("Attack", false);
                        Monsters[i].GetComponent<Animator>().SetBool("Run", true);

                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < Monsters.Length; i++)
            {
                if (Monsters[i] != null)
                {
                    Monsters[i].transform.position = Vector3.MoveTowards(Monsters[i].transform.position, new Vector3(J, 0, 0), 2.5f * Time.deltaTime);
                    Monsters[i].GetComponent<Animator>().SetBool("Run", true);
                    Monsters[i].transform.LookAt(new Vector3(J, 0, 0));
                    if (Monsters[i].transform.position == new Vector3(J, 0, 0))
                    {
                        Monsters[i].transform.rotation = Quaternion.Euler(0, -90, 0);
                        Monsters[i].GetComponent<Animator>().SetBool("Run", false);
                    }
                    J += 1.5f;
                }
            }

        }
    }


}

