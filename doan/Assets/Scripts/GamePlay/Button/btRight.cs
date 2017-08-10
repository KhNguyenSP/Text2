using UnityEngine;
using System.Collections;

public class btRight : MonoBehaviour {

    public static btRight instance;
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

    public void Right()
    {
        if (GamePlayController.instance.KiemTraDiChuyen(13))
        {
            Debug.Log("right");
            return;
        }
        else if(GamePlayController.instance.KiemTraTrung(1)){
            Debug.Log("trung gach");
            return;
        }
        else
        {
            GamePlayController.action = "Right";
            Vector3 tepm = Gach.instance.transform.position;
            tepm.x += 1;
            Gach.instance.transform.position = tepm;
        }
    }
}
