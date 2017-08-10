using UnityEngine;
using System.Collections;

public class GachCon4 : MonoBehaviour {

    public static GachCon4 instance;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this; // gọi lại GamePlayController
    }
    public void vitri()
    {
        Debug.Log(transform.position.x + " | " + transform.position.y);
    }
}
