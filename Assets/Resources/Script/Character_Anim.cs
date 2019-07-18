using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimTriger
{
    Idle = 0,
    Run,
    Attack1,
    Cast,
    Death
};

public class Character_Anim : MonoBehaviour {
    public Animation anim;
    public AnimTriger Triger;



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        anim.Play("Idle");
        Animation();
    }

    public void Animation()
    {
        switch (Triger)
        {
            case AnimTriger.Idle:
                anim.Play("Idle");
                break;
            case AnimTriger.Run:
                anim.Play("Run");
                break;
            default:
                break;
        }
    }
}
