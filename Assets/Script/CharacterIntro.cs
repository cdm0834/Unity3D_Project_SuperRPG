using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterIntro : MonoBehaviour {
    TextMeshProUGUI ClassName;
    TextMeshProUGUI ClassIntro;
    CharacterCreation index;
    
	// Use this for initialization
	void Start () {
        ClassName = this.transform.Find("ClassNameTag").Find("ClassName").GetComponent<TextMeshProUGUI>();
        ClassIntro = this.transform.Find("Character_Menual").Find("Character_Intro").GetComponent<TextMeshProUGUI>();
        index = GameObject.Find("Character_Select").GetComponent<CharacterCreation>();
    }
  
    private void Update()
    {
        CharacterInt();
    }

    void CharacterInt()
    {
        if(index.index==0)
        {
            ClassName.text="전사";
            ClassIntro.text = "강력한 체력과\n투지로 무장\n하여 전방에서\n진두지휘 하는\n전사입니다.";
        }
        else if(index.index == 1)
        {
            ClassName.text = "도적";
            ClassIntro.text = "단검을 사용\n하며 다른직업\n에 비해 빠른\n속도로 적을\n제압하는 도적\n입니다.";
        }
        else if (index.index == 2)
        {
            ClassName.text = "법사";
            ClassIntro.text = "폭팔적인 공격\n으로 적을 혼란\n시키며 강력한\n마법을 사용\n하는 마법사\n입니다.";
        }
        else if (index.index == 3)
        {
            ClassName.text = "궁수";
            ClassIntro.text = "멀리서 빠르게\n공격을 쏟아\n붓고, 민첩한\n동작으로 회피\n하는 궁수\n입니다.";
        }
    }
}
