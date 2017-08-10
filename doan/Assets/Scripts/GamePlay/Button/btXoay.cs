using UnityEngine;
using System.Collections;
using System;

public class btXoay : MonoBehaviour {

    public static btXoay instance;
    public static float goc = 0f;
    public static float gocOld = 0f;
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

   
	void Start () {
        goc = 0f;
	}
	
    public void XoayGach()
    {
        if (Gach.instance.transform.position.y < 2){
             
            if (MU.ToInt(GachCon4.instance.transform.position.y) <= 0 ||
                MU.ToInt(GachCon3.instance.transform.position.y) <= 0 ||
                MU.ToInt(GachCon2.instance.transform.position.y) <= 0 ||
                MU.ToInt(GachCon1.instance.transform.position.y) <= 0)
            {
                Debug.Log("Cham Duoi");
                return;
            }
        }
        else
        {
           
            gocOld = goc;
            if (GamePlayController.loaiGach < 4 && GamePlayController.loaiGach > 0)
            {
                if (goc == 0)
                    goc -= 90f;
                else
                    goc = 0f;
            }
            else if (GamePlayController.loaiGach >= 4)
                goc -= 90f;

            Gach.instance.transform.rotation = Quaternion.Euler(0f, 0f, goc);

            if(GamePlayController.instance.KiemTraTrung(0)){
                Gach.instance.transform.rotation = Quaternion.Euler(0f, 0f, gocOld);
                return;
            }

            else if (Gach.instance.transform.position.x > 5)
            {
             
                while (true)
                {
                    if (GamePlayController.instance.KiemTraDiChuyen(14))
                    {
                        Vector3 temp = Gach.instance.transform.position;
                        temp.x -= 1;
                        Gach.instance.transform.position = temp;
                    }
                    else
                        break;
                }
              
            }
            else
            {
                while (true)
                {
                    if (GamePlayController.instance.KiemTraDiChuyen(-1))
                    {
                        Vector3 temp = Gach.instance.transform.position;
                        temp.x += 1;
                        Gach.instance.transform.position = temp;
                    }
                    else
                        break;
                }
            }
        }  
    }
}
