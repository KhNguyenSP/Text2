using UnityEngine;
using System.Collections;

public class btDown : MonoBehaviour {
    public static btDown instance;
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

    public void Down()
    {
        Vector3 tepm = Gach.instance.transform.position;
        if (VuotBien() == true)
        {
            Debug.Log("vuot bien");
            return;
        }
        else
        {
            tepm.y -= 1;
            Gach.instance.transform.position = tepm;
        }
    }

    public bool VuotBien()
    {
        if (GachCon1.instance.transform.position.y<=0)
            return true;
        else if (GachCon2.instance.transform.position.y <=0)
            return true;
        else if (GachCon3.instance.transform.position.y <=0)
            return true;
        else if (GachCon4.instance.transform.position.y <=0)
            return true;
        return false;
    }
}
