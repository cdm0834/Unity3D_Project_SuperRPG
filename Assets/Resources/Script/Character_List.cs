using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_List : MonoBehaviour {
    public GameObject Knight;
    public GameObject Thief;
    public GameObject Magician;
    public GameObject Archer;
	// Use this for initialization
	void Start ()
    {
        Knight = Resources.Load("Character/Swordman") as GameObject;
        Thief = Resources.Load("Character/Thief") as GameObject;
        Magician = Resources.Load("Character/Magician") as GameObject;
        Archer = Resources.Load("Character/Archer") as GameObject;
	}
}
