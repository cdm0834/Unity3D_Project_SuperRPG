using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town_Chief_Talking : MonoBehaviour {
    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    DialogueTrigger dialogueTrigger;
    GameObject text;
    public GameObject CharacterUI;
    RotateCamera camera;
    bool Triger;

    private void Start()
    {
        dialogueTrigger = GameObject.Find("Canvas").transform.Find("TalkUI").GetComponent<DialogueTrigger>();
        text = GameObject.Find("Canvas").transform.Find("TalkUI").gameObject;
        camera = Camera.main.gameObject.GetComponent<RotateCamera>();
        Triger = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(Triger);
    }

    public void MoveToTarget(bool triger)
    {
        if (Triger == false)
        {
            // Player의 현재 위치를 받아오는 Object
            target = GameObject.Find("Character").transform;
            // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
            direction = (target.position - transform.position).normalized;
            // 가속도 지정 (추후 힘과 질량, 거리 등 계산해서 수정할 것)
            accelaration = 0.1f;
            // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
            velocity = (velocity + accelaration * Time.deltaTime);
            // Player와 객체 간의 거리 계산
            float distance = Vector3.Distance(target.position, transform.position);
            // 일정거리 안에 있을 시, 해당 방향으로 무빙
            if (distance <= 5.0f)
            {
                CharacterUI joystick = GameObject.Find("Player_Canvas").transform.Find("JoyStick").GetComponent<CharacterUI>();
                joystick.rect_JoyStck.localPosition = Vector3.zero;
                camera.ChoiseCharacter = false;
                camera.ChiefCamera = true;
                GetComponent<Animator>().SetBool("Talking", true);
                joystick.isTouch = false;
                CharacterUI.SetActive(false);
                Triger = true;
                test(Triger);
                target.gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>().Play("Idle");
                
            }
            // 일정거리 밖에 있을 시, 속도 초기화 
            else
            {
                test(false);
            }

        }

        if (text.transform.localPosition == new Vector3(0, -810, 0)&& Triger==true)
        {
            camera.ChoiseCharacter = true;
            camera.ChiefCamera = false;
            GetComponent<Animator>().SetBool("Talking", false);
            CharacterUI.SetActive(true);
            enabled = false;
            CharacterUI.transform.GetChild(4).gameObject.SetActive(true);
        }
        //Debug.Log("Test");
    }

    void test(bool triger)
    {
        if (triger == true)
        {
            dialogueTrigger.dialogue.name = "촌장";
            dialogueTrigger.dialogue.sentences = new string[5];
            dialogueTrigger.dialogue.sentences[0] = "오오.. 자네가 우리마을을 위해 힘쓰러 와준 용사로군..";
            dialogueTrigger.dialogue.sentences[1] = "왕국에선 이야기를 들었네. 자네의 손이 필요한 일들이 많아.";
            dialogueTrigger.dialogue.sentences[2] = "지금 마을 밖에서도 마을 사람들은 괴물들에 의해 고통을 받고 있다네.";
            dialogueTrigger.dialogue.sentences[3] = "일단 당장 그들을 좀 처리해주고 오게나. 나가는 길은 내 뒤에 철문앞에 서면 열어줄거야.";
            dialogueTrigger.dialogue.sentences[4] = "오자마자 쉬지도 못하고 바로 일을 시켜 미안하네.";
            dialogueTrigger.TriggerDialogue();

        }
    }
}


