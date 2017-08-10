using UnityEngine;
using System.Collections;

public class GachCon : MonoBehaviour {
    public static GachCon instance;
    private static Renderer ren;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this; // gọi lại GamePlayController
    }
    
}
