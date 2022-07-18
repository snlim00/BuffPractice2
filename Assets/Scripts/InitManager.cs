using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    public delegate void Init();

    public static Init[] initEvent = new Init[15];

    private void Start()
    {
        for(int i = 0; i < initEvent.Length; ++i)
        {
            InitManager.initEvent[i].Invoke();
        }
    }
}
