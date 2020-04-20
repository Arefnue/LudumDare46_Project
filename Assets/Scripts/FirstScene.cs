using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScene : MonoBehaviour
{
    public string mainMenu;
    private void Start()
    {
        GameManager.instance.ChangeScene(mainMenu);
    }
}
