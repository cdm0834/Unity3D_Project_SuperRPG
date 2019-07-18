using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
    GameObject dialogueUI;

	//public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        dialogueUI = GameObject.Find("Canvas").transform.Find("TalkUI").gameObject;
        sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)//�Ű������� Dialogue �ҷ�����
	{
		nameText.text = dialogue.name; //�̸� �ҷ��ͼ� �Է�

		sentences.Clear(); 

		foreach (string sentence in dialogue.sentences)//Dialogue���� ���尪 �Է¹ޱ�
        {
			sentences.Enqueue(sentence); //ť�� �Է¹��� ���尪 �־��ֱ�
		}

		DisplayNextSentence(); 
	}

	public void DisplayNextSentence ()
    {
		if (sentences.Count == 0) //�ϳ��� ���� ť���� 0�� �ɽ� ��ȭ����
        {
			EndDialogue();
            return;
		}

		string sentence = sentences.Dequeue(); //ť���� �ϳ��� ���� ���尪���� �ʱ�ȭ
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)//�ѱ��ھ� ������ ��½����ִ� �ڷ�ƾ 
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())//����ҷ��� char������ �ϳ��� ���
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
        dialogueUI.transform.localPosition = new Vector3(0, -810, 0); //��ȭâ ������ ������
    }

}
