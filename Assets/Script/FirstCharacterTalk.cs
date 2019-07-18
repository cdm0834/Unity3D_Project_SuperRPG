using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstCharacterTalk : MonoBehaviour {
     Vector3 MovePoint;
     Vector3 GoBackPoint;
    public bool MTriger;
    public bool EndTriger;
    DialogueTrigger dialogueTrigger;
    public float distance;
    public GameObject text;
    public GameObject CharacterUI;
    // Use this for initialization
    private void Start()
    {
        EndTriger = false;
        MTriger =false;
        dialogueTrigger = GameObject.Find("Canvas").transform.Find("TalkUI").GetComponent<DialogueTrigger>();
        text = GameObject.Find("Canvas").transform.Find("TalkUI").gameObject;
    }

    private void Update()
    {
        FirstCharacterTriger(MTriger);
        CharacterEnd(EndTriger);
    }

    public void FirstCharacterTriger(bool Triger)
    {
        if (Triger == true)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2.75f, 0, this.gameObject.transform.position.z), Time.deltaTime * 3f);
            this.gameObject.GetComponent<Animator>().SetBool("Run", true);
            distance = Vector3.Distance(this.gameObject.transform.position, new Vector3(-2.75f, 0, this.gameObject.transform.position.z));
            if (distance < 0.01f)
            {
                this.gameObject.GetComponent<Animator>().SetBool("Run", false);
                //대화 및 지워지는 코루틴
            }
        }
    }  

       public void FirstTalk()
    {
        dialogueTrigger.dialogue.name = "마을주민";
        dialogueTrigger.dialogue.sentences = new string[1];
        dialogueTrigger.dialogue.sentences[0] = "어-이 거기 너!";
        dialogueTrigger.TriggerDialogue();
    }

    public void SecondTalk()
    {
        dialogueTrigger.dialogue.name = "마을주민";
        dialogueTrigger.dialogue.sentences = new string[4];
        dialogueTrigger.dialogue.sentences[0] = "휴우 힘들어 죽겠네..너를 얼마나 찾아다닌줄 알아 ?";
        dialogueTrigger.dialogue.sentences[1] = "너가 이번에 우리 마을을 위해 왕국에서 파견된 용사구나! 왔으면 왔다고 알려주면 어디 덧나니?";
        dialogueTrigger.dialogue.sentences[2] = "쨋든 촌장님 께서 너를 찾고 계셔. 저기 동상앞에 계실꺼야!.";
        dialogueTrigger.dialogue.sentences[3] = "그럼 나는 바빠서 먼저간다!";
        dialogueTrigger.TriggerDialogue();
    }

    public void CharacterEnd(bool Triger)
    {
        if (Triger == true&&text.transform.localPosition == new Vector3(0,-810,0))
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-16.07f, 0, this.gameObject.transform.position.z), Time.deltaTime * 3f);
            this.transform.LookAt(GameObject.Find("TownScreenshot").transform.Find("SM_Bld_House_Foundation_19"));
            this.gameObject.GetComponent<Animator>().SetBool("Run", true);
            Destroy(this.gameObject, 5f);
            CharacterUI.SetActive(true);
        }
    }
}

