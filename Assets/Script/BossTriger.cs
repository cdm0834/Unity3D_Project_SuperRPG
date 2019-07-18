using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriger : MonoBehaviour
{
    Boss BossFight;
    GameObject boss;
    public GameObject BossCanvas;
    public GameObject BossCamera;
    public GameObject PlayerCanvas;
    public float ShakeTimer;
    public float shakeAmount;
    bool TigerOnoff;
    private void Start()
    {
        BossFight = GameObject.Find("GoblinKing").GetComponent<Boss>();
        boss = GameObject.Find("GoblinKing");
        ShakeTimer = 3f;
        shakeAmount = 0.1f;
        TigerOnoff = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (TigerOnoff == false)
        {
            StartCoroutine(Bossmit());
        }
    }

    //void ShakeCamera()
    //{

    //}

 
    public IEnumerator Bossmit()
    {
        PlayerCanvas = GameObject.Find("Player_Canvas");
        CharacterUI joystick = GameObject.Find("Player_Canvas").transform.Find("JoyStick").GetComponent<CharacterUI>();
        joystick.rect_JoyStck.localPosition = Vector3.zero;
        joystick.isTouch = false;
        GameObject.Find("Character").transform.position = GameObject.Find("Character").transform.position;
        GameObject.Find("Character").transform.GetChild(0).gameObject.GetComponent<Animation>().Play("Idle");
        PlayerCanvas.SetActive(false);
        BossCamera.SetActive(true);
        TigerOnoff = true;

        yield return new WaitForSeconds(3f);

        BossCamera.GetComponent<Animator>().enabled = false;

        BossCamera.transform.GetChild(0).GetComponent<Cameratest>().SW = true;

          
        boss.GetComponent<Animator>().Play("PowerUp");
        SoundManager.Smanager.PlaySE("Boss_PowerUp");
        yield return new WaitForSeconds(3f);
        SoundManager.Smanager.BgmNum += 1;
        SoundManager.Smanager.bgmOn = true;
        boss.GetComponent<Animator>().SetBool("Idle", true);
        BossFight.BossFight = true;
        BossCanvas.SetActive(true);
        BossCamera.SetActive(false);
        PlayerCanvas.SetActive(true);
        yield return null;
    }
}
