using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AcDialogue;

public class Callbacks : MonoBehaviour
{
    [SerializeField]DialogueObject obj = null;

    void Start()
    {
        obj.Init(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            obj.ParseText<Callbacks>(this, obj.Infos[0].Content);
    }

    public void Test()
    {
        Debug.Log("Test Invoke");
    }
}
