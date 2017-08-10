using UnityEngine;
using System.Collections;

public class btLeft : MonoBehaviour {
    public static btLeft instance;
    public static MathUnity MU = new MathUnity();

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    void Awake()
    {
        MakeInstance();
    }

    public void Left()
    {
        
        if (GamePlayController.instance.KiemTraDiChuyen(0))
        {
            Debug.Log("left");
            return;
        }
        else if (GamePlayController.instance.KiemTraTrung(-1))
        {
            Debug.Log("trung gach");
            return;
        }
        else
        {
            GamePlayController.action = "Left";
            Vector3 tepm = Gach.instance.transform.position;
            tepm.x -= 1;
            Gach.instance.transform.position = tepm;
        }
    }
}
