﻿using UnityEngine;
using System;
using System.Reflection;
using Alkaid;
using Rosetta;

public class TestMono : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Type type = Type.GetType("Mono.Runtime");
		if (type != null)
		{
			MethodInfo info = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static);
			
			if (info != null)
				Debug.Log(info.Invoke(null, null));
		}

        Rosetta.Rosetta r = Rosetta.Rosetta.Instance;
        Debug.LogWarning("Rosetta  100   " + r.GetRandomNum100());
        Debug.LogWarning("Rosetta  1000   " + r.GetRandomNum1000());

        Rosetta.Rosetta.Instance.Init(SetUpWithUnity);
        Rosetta.Rosetta.Instance.StartApp();
	}

    private void SetUpWithUnity()
    {
        LoggerSystem.Instance.SetConsoleDelegate(UnityEngine.Debug.Log);
        if (Application.isEditor)
        {
            DataProviderSystem.Instance.SetRootDir(Application.streamingAssetsPath);
        }
        else
        {
            DataProviderSystem.Instance.SetRootDir(Application.persistentDataPath);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {

        Rosetta.Rosetta.Instance.StopApp();
    }

    private int count = 0;
    public void OnClick()
    {
        Alkaid.MyRandom mr = new Alkaid.MyRandom();
        Debug.LogWarning("Framework 1000   " + mr.GetRandomNum1000());

        GameObject go = mr.CreateOne();
        //go.transform.parent = this.transform;
        go.name = "createone:" + count++;
        go.transform.localPosition = Vector3.one * count;
    }
}
