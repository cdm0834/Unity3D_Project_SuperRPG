using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelePort : MonoBehaviour {
    hierachyTriger Statetri;
    public GameObject Loading;


    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(Bgm());
        ChangeScene();
    }


    void ChangeScene()
    {
        Statetri = GameObject.Find("Main_Camera").GetComponent<hierachyTriger>();
        StartCoroutine(LoadAsy("Scene2"));
        GameObject.Find("Character").transform.position = new Vector3(91.7f, 50f, 57.3f);
        GameObject.Find("Character").transform.rotation = Quaternion.Euler(0, 45, 0);
        CharacterUI joystick = GameObject.Find("Player_Canvas").transform.Find("JoyStick").GetComponent<CharacterUI>();
        joystick.rect_JoyStck.localPosition = Vector3.zero;
        joystick.isTouch = false;
        joystick.Character.GetComponent<Character_Anim>().anim.Play("Idle");
        GameObject.Find("Player_Canvas").SetActive(false);
        Statetri.Battletriger = true;
    }

    IEnumerator Bgm()
    {
        SoundManager.Smanager.BgmNum += 1;
        SoundManager.Smanager.bgmOn = true;
        yield return null;
    }


    IEnumerator LoadAsy (string secenIndex)
    {
     
        AsyncOperation operation = SceneManager.LoadSceneAsync(secenIndex);
        Loading.SetActive(true);

        while (!operation.isDone)
        {
            
            yield return null;
        }
       
    }


}
