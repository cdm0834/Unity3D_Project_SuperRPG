using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestScript : MonoBehaviour {
    public static QuestScript Quest = null;
    TextMeshProUGUI Quest1;
    TextMeshProUGUI Quest2;
    public int Iq1;
    public int Iq2;

    private void Awake()
    {
        if(Quest==null)
        {
            Quest = this;
        }
    }
    private void Start()
    {
        Iq1 = 0;
        Iq2 = 0;
        Quest1 = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        Quest2 = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        
        if(Iq1>=5)
        {
            Quest1.text = "V고블린 퇴치" + Iq1 + "/5";
            gameObject.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            Quest1.text = "고블린 퇴치" + Iq1 + "/5";
        }

        if(Iq2>=1)
        {
            Quest2.text = "V그곳의 대장 처치";
            gameObject.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            Quest2.text = "그곳의 대장 처치";
        }
        
    }

    
}
