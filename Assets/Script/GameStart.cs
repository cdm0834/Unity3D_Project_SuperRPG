using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStart : MonoBehaviour
{
    public GameObject light;
    public GameObject CharacterSelect;
    Image fadeout;
    GameObject camera;
    CharacterCreation index;
    GameObject CharacterSponPos;
    public GameObject Canvas2;
    Character_List Charactes;
    public GameObject PlayerCanvas;
    public GameObject FirstNpc;
    FirstCharacterTalk FirstMove;

    private void Start()
    {
        fadeout = GameObject.Find("Canvas").transform.Find("Fadeout").GetComponent<Image>();
        camera = GameObject.Find("Main_Camera");
        index = GameObject.Find("Character_Select").GetComponent<CharacterCreation>();
        CharacterSponPos = GameObject.Find("Character");
        Charactes = GameObject.Find("Character_Spon").GetComponent<Character_List>();
        FirstNpc = GameObject.Find("FirstNPC");
        //PlayerCanvas = GameObject.Find("Player_Canvas");
        FirstMove = FirstNpc.GetComponent<FirstCharacterTalk>();
    }

    public void StartButton()
    {
        SoundManager.Smanager.PlaySE("GameStart");
        light.SetActive(true);
        gameObject.transform.Find("Particle System").gameObject.SetActive(true);
        StartCoroutine(CharactorCustom());
    }

    public void Option()
    {
        GameObject.Find("Canvas").transform.Find("Option").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("TitleScreen").gameObject.SetActive(false);

    }

    public void Back()
    {
        GameObject.Find("Canvas").transform.Find("TitleScreen").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Option").gameObject.SetActive(false);
     
    }

    public void toggleControl(Toggle toggle)
    {
      if(toggle.name=="OnTogle"&&toggle.isOn)
        {
            SoundManager.Smanager.bgmPlayer.Play();
        }else
        {
            SoundManager.Smanager.bgmPlayer.Stop();
        }
        
    }
  
    public void CharacterChoise()
    {
        CharacterSelect.SetActive(false);
        StartCoroutine(CharacterChoiseCor());
        StartCoroutine(Bgm());
        SoundManager.Smanager.PlaySE("ClickSound");

        switch (index.index)
        {
            case 0:
                Debug.Log("전사");
                GameObject.Instantiate(Charactes.Knight, CharacterSponPos.transform.position, Charactes.Knight.transform.rotation= CharacterSponPos.transform.rotation).transform.parent = CharacterSponPos.transform;
                break;
            case 1:
                Debug.Log("도적");
                GameObject.Instantiate(Charactes.Thief, CharacterSponPos.transform.position, Charactes.Thief.transform.rotation= CharacterSponPos.transform.rotation).transform.parent = CharacterSponPos.transform;
                break;
            case 2:
                Debug.Log("법사");
                GameObject.Instantiate(Charactes.Magician, CharacterSponPos.transform.position, Charactes.Magician.transform.rotation= CharacterSponPos.transform.rotation).transform.parent = CharacterSponPos.transform;
                break;
            case 3:
                Debug.Log("궁수");
                GameObject.Instantiate(Charactes.Archer, CharacterSponPos.transform.position, Charactes.Archer.transform.rotation= CharacterSponPos.transform.rotation).transform.parent = CharacterSponPos.transform;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    IEnumerator Bgm()
    {
        yield return new WaitForSeconds(2f);
        SoundManager.Smanager.BgmNum += 1;
        SoundManager.Smanager.bgmOn = true;
    }
    IEnumerator CharactorCustom()
    {
        StartCoroutine(FadeImage(false));
        yield return new WaitForSeconds(2f);
        GameObject.Find("Canvas").transform.Find("TitleScreen").gameObject.SetActive(false);
        StartCoroutine(FadeImage(true));
        camera.GetComponent<RotateCamera>().rotatesw = false;
        CharacterSelect.SetActive(true);
        camera.transform.rotation = Quaternion.Euler(6.7f,-60,0);
    }

    IEnumerator CharacterChoiseCor()
    {
        StartCoroutine(FadeImage(false));
        yield return new WaitForSeconds(2f);
        Canvas2.SetActive(true);
        Destroy(Canvas2, 1f);
        StartCoroutine(FadeImage(true));
        camera.GetComponent<RotateCamera>().ChoiseCharacter = true;
        yield return new WaitForSeconds(3f);
        FirstMove.FirstTalk();
        yield return new WaitForSeconds(3f);
        FirstMove.MTriger = true;
        yield return new WaitForSeconds(5f);
        if (FirstMove.distance < 0.01f)
        {
            FirstMove.SecondTalk();
            //대화 및 지워지는 코루틴
        }
        yield return new WaitForSeconds(8f);
        FirstMove.MTriger = false;
        FirstMove.EndTriger= true;
    }

  
    public IEnumerator FadeImage(bool fadeAway)
    {
        yield return new WaitForSeconds(1f);
        // fade from opaque to transparent
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeout.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                fadeout.color = new Color(0, 0, 0, i);
                yield return null;
            }

        }
    }
}
