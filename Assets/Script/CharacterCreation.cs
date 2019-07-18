using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour {

    private List<GameObject> Characters;
    private int SelectionIndex = 0;
    public int index;

	// Use this for initialization
	void Start () {
        index = 0;
        Characters = new List<GameObject>();

        foreach(Transform t in transform)
        {
            Characters.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        Characters[SelectionIndex].SetActive(true);
	}

    public void SelectindexPlus()//다음캐릭터
    {
        ++index;
        Select(index);
        SoundManager.Smanager.PlaySE("NextSound");
        if (index>=4)//3보다 커지면 0으로 초기화
        {
            index = 0;
            Select(index);
        }
    }

    public void SelectindexMinus()//이전캐릭터
    {
        --index;
        Select(index);
        SoundManager.Smanager.PlaySE("NextSound");
        if (index < 0)//0보다 작아지면 3으로 초기화
        {
            index = 3;
            Select(index);
        }
    }

    public void Select(int index)
    {
        if (index < 0 || index >= Characters.Count)
        {
            return; 
        }

        Characters[SelectionIndex].SetActive(false);
        SelectionIndex = index;
        Characters[SelectionIndex].SetActive(true);
    }
}
