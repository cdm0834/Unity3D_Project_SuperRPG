using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    private void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true); // 16:9 로 개발시
        DontDestroyOnLoad(gameObject);
    }
}
