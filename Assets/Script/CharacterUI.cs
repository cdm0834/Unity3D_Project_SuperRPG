using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform rect_Background;
    public RectTransform rect_JoyStck;

    private float radius;

    public GameObject Player;
    public float moveSpeed;

    public bool isTouch = false;
    Vector3 movePosition;
    public GameObject Character;
    public bool Battle;

    private void Start()
    {
        Battle = false;
        radius = rect_Background.rect.width * 0.5f;
        moveSpeed = 3f;
        Character = Player.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (isTouch && Battle == false)
        {
            Player.transform.position -= movePosition;
        }else if(isTouch && Battle == true)
        {
            Player.transform.position += movePosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Battle)
        {
            Vector2 value = eventData.position - (Vector2)rect_Background.position;

            value = Vector2.ClampMagnitude(value, radius);

            rect_JoyStck.localPosition = value;

            value = value.normalized;

            movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime, 0f, value.y * moveSpeed * Time.deltaTime);

            //Player.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0);

            Player.transform.eulerAngles = new Vector3(0, Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg, 0);

            // Character.GetComponent<Character_Anim>().Triger = AnimTriger.Run;
            Character.GetComponent<Character_Anim>().anim.Play("Run");
        }else
        {
             Vector2 value = eventData.position - (Vector2)rect_Background.position;

            value = Vector2.ClampMagnitude(value, radius);

            rect_JoyStck.localPosition = value;

            value = value.normalized;

            movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime, 0f, value.y * moveSpeed * Time.deltaTime);

            //Player.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0);

            Player.transform.eulerAngles = new Vector3(0, Mathf.Atan2(-value.x, -value.y) * Mathf.Rad2Deg, 0);

            // Character.GetComponent<Character_Anim>().Triger = AnimTriger.Run;
            Character.GetComponent<Character_Anim>().anim.Play("Run");
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)

    {
        isTouch = false;
        rect_JoyStck.localPosition = Vector3.zero;

        //Character.GetComponent<Character_Anim>().Triger = AnimTriger.Idle;
        Character.GetComponent<Character_Anim>().anim.Play("Idle");
    }

    public void Attack()

    {
        StartCoroutine(AttackStart());
    }

    public void Skill1()

    {
        StartCoroutine(SkillStart());
    }

    IEnumerator AttackStart()
    {
        Cooldown cooldown = GameObject.Find("Player_Canvas").GetComponent<Cooldown>();
        isTouch = false;
        if (cooldown.iscoolDown == false)
        {
            int random = Random.Range(1, 3);
            SoundManager.Smanager.PlaySE("Player_Attack" + random);
            cooldown.iscoolDown = true;
            rect_JoyStck.localPosition = Vector3.zero;
            int iAttack = Random.Range(1, 3);
            Character.GetComponent<Character_Anim>().anim.Play("Attack" + iAttack);

            //if (!Character.GetComponent<Character_Anim>().anim.IsPlaying("Attack1")||!Character.GetComponent<Character_Anim>().anim.IsPlaying("Attack2"))
            //{
            //    Character.GetComponent<Character_Anim>().anim.Play(null);
            //}
        }
        yield return null;
    }

    IEnumerator SkillStart()
    {
        Cooldown cooldown = GameObject.Find("Player_Canvas").GetComponent<Cooldown>();
        isTouch = false;
        if (cooldown.SkillcoolDown == false)
        {
            cooldown.SkillcoolDown = true;
            rect_JoyStck.localPosition = Vector3.zero;
            Character.GetComponent<Character_Anim>().anim.Play("AttackCritical");
            SoundManager.Smanager.PlaySE("AttackGround");
        }
        yield return null;
    }


}