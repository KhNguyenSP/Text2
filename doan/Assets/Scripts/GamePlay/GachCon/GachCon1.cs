using UnityEngine;
using System.Collections;

public class GachCon1 : MonoBehaviour {

    public static GachCon1 instance;
   
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
