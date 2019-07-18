using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hierachyTriger : MonoBehaviour {
    public GameObject Playercanvas;
    public bool Battletriger;
    public GameObject PlayerState;
    bool Uptriger;

    private void Start()
    {
        Battletriger = false;
        Uptriger = true;
    }


    private void Update()
    {
        triger();
    }

    public void triger()
    {
        if (Battletriger)
        {
            StartCoroutine(canvas());
        }
        else
        {
            GameObject.Find("Character").GetComponent<State>().enabled = false;
        }
    }

    IEnumerator canvas()
    {
        if (Uptriger == true)
        {
            yield return new WaitForSeconds(3f);
            Playercanvas.SetActive(true);
            GameObject.Find("Character").GetComponent<State>().enabled = true;
            GetComponent<RotateCamera>().BattleCamera = true;
            GetComponent<RotateCamera>().ChoiseCharacter = false;
            Playercanvas.transform.Find("JoyStick").GetComponent<CharacterUI>().Battle = true;
            yield return new WaitForSeconds(0.1f);
            PlayerState.SetActive(true);
            Uptriger = false;
        }
    }
}
