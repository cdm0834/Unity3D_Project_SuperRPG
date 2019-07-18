using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue; //dialogue ��� �޾Ƽ� �̸��ϰ� ���� ����
    GameObject DialogueUI; //��ȭ ui

    private void Start()
    {
        DialogueUI = GameObject.Find("Canvas").transform.Find("TalkUI").gameObject;
    }
    public void TriggerDialogue () //��ȭ 
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue); //��ȭ ����
        DialogueUI.transform.localPosition = new Vector3(0, -390, 0); //��ȭ ���۽� ��ȭ UI���� �ø���
    }
}
