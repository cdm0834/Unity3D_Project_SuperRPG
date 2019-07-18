using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Camera : MonoBehaviour {
    public GameObject Character;
    public Vector3 CharacterPos;

    private void Start()
    {
        Character = GameObject.Find("Character");
       
    }
    private void Update()
    {
        CharacterPos = new Vector3(Character.transform.position.x + 3, Character.transform.position.y + 8, Character.transform.position.z + 4);
        transform.position = Vector3.Lerp(transform.position, CharacterPos, Time.deltaTime * 2f);
        transform.LookAt(Character.transform);
    }
}
