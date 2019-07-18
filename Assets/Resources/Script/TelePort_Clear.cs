using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelePort_Clear : MonoBehaviour {
    hierachyTriger Statetri;
    private void OnTriggerEnter(Collider other)
    {
        ChangeScene();
    }


    void ChangeScene()
    {
        Statetri = GameObject.Find("Main_Camera").GetComponent<hierachyTriger>();
        StartCoroutine(LoadAsy("Scene1"));
        GameObject.Find("Character").transform.position = new Vector3(-0.8f, 0.7f, 66.5f);
        GameObject.Find("Character").transform.rotation = Quaternion.Euler(0, 0, 0);
        CharacterUI joystick = GameObject.Find("Player_Canvas").transform.Find("JoyStick").GetComponent<CharacterUI>();
        joystick.rect_JoyStck.localPosition = Vector3.zero;
        joystick.isTouch = false;
        joystick.Character.GetComponent<Character_Anim>().anim.Play("Idle");
        GameObject.Find("Player_Canvas").SetActive(false);
    }




    IEnumerator LoadAsy(string secenIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(secenIndex);


        while (!operation.isDone)
        {
            yield return null;
        }

    }
}
