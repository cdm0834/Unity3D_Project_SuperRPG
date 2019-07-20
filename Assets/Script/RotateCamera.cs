using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    float time = 0;

    public float speed;
    public float width;
    public float height;
    public bool rotatesw;
    public bool ChoiseCharacter;
    public bool ChiefCamera;
    public bool BattleCamera;
    public GameObject Character;
    public Vector3 CharacterPos;
    private void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true); // 16:9 로 개발시
    }

    private void Start()
    {
        Character = GameObject.Find("Character");
        ChoiseCharacter = false;
        rotatesw = true;
        ChiefCamera = false;
        speed = 0.1f;
        width = 20;
        height = 20;
    }

    void rotate()
    {

        if (ChoiseCharacter == false)
        {
            if (rotatesw == true)
            {
                time += Time.deltaTime * speed;

                float x = Mathf.Cos(time) * width;
                float y = 12.5f;
                float z = Mathf.Sin(time) * height;

                transform.position = new Vector3(x, y, z);
                transform.LookAt(new Vector3(0, 12.5f, 0));
            }
            else
            {
                transform.position = new Vector3(-25.9f, 1.6f, 9);
            }

            if (ChiefCamera == true)
            {
                transform.position = new Vector3(-5.7f, 2.4f, 49);
                transform.rotation = Quaternion.Euler(23.722f, -93.192f, 0);
            }
            else if (BattleCamera == true)
            {
                CharacterPos = new Vector3(Character.transform.position.x - 3f, Character.transform.position.y + 3.5f, Character.transform.position.z - 4);
                transform.rotation = Quaternion.Euler(23f, 35f, 0);
                //transform.position = Vector3.Lerp(transform.position, CharacterPos, Time.deltaTime * 2f);
                transform.position = CharacterPos;
                //transform.LookAt(Character.transform);
            }
        }
        else
        {
            CharacterPos = new Vector3(Character.transform.position.x + 3, Character.transform.position.y + 8, Character.transform.position.z + 4);
            transform.position = Vector3.Lerp(transform.position, CharacterPos, Time.deltaTime * 2f);
            transform.LookAt(Character.transform);
        }
    }

    void Update ()
    {
        rotate();   
    }
}
