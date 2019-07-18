using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue; //dialogue 상속 받아서 이름하고 문장 쓰기
    GameObject DialogueUI; //대화 ui

    private void Start()
    {
        DialogueUI = GameObject.Find("Canvas").transform.Find("TalkUI").gameObject;
    }
    public void TriggerDialogue () //대화 
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue); //대화 시작
        DialogueUI.transform.localPosition = new Vector3(0, -390, 0); //대화 시작시 대화 UI위로 올리기
    }
}
