using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_StateBar : MonoBehaviour {
    State state;
   public Image HpBar;

	// Use this for initialization
	void Start () {
        state = GameObject.Find("GoblinKing").GetComponent<State>();
	}

    private void Update()
    {
        HpBar.fillAmount = (float)state.HP / (float)state.MaxHP;
    }
}
