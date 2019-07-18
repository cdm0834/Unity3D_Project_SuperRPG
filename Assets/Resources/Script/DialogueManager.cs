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

	public void StartDialogue (Dialogue dialogue)//매개변수로 Dialogue 불러오기
	{
		nameText.text = dialogue.name; //이름 불러와서 입력

		sentences.Clear(); 

		foreach (string sentence in dialogue.sentences)//Dialogue에서 문장값 입력받기
        {
			sentences.Enqueue(sentence); //큐에 입력받은 문장값 넣어주기
		}

		DisplayNextSentence(); 
	}

	public void DisplayNextSentence ()
    {
		if (sentences.Count == 0) //하나씩 빠진 큐값이 0이 될시 대화종료
        {
			EndDialogue();
            return;
		}

		string sentence = sentences.Dequeue(); //큐에서 하나씩 받은 문장값으로 초기화
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)//한글자씩 나오게 출력시켜주는 코루틴 
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())//문장불러서 char형으로 하나씩 출력
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
        dialogueUI.transform.localPosition = new Vector3(0, -810, 0); //대화창 밑으로 내리기
    }

}
