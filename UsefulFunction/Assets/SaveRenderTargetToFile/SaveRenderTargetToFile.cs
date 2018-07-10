using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class SaveToFile
{

    public static void DumpRenderTexture(RenderTexture rt, string pngOutPath)
    {
        var oldRT = RenderTexture.active;

        var tex = new Texture2D(rt.width, rt.height);
        RenderTexture.active = rt;
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        tex.Apply();

        File.WriteAllBytes(pngOutPath, tex.EncodeToPNG());
        RenderTexture.active = oldRT;
    }

}

public class SaveRenderTargetToFile : MonoBehaviour
{

    public RenderTexture m_rt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        
        if (GUI.Button(new Rect(10, 70, 50, 30), "Save"))
        {
            SaveToFile.DumpRenderTexture(m_rt, Application.dataPath+"/../"+Time.frameCount+".png");
        }
            
    }
}
