using UnityEngine;
using System.Collections;

public class Gach : MonoBehaviour {

    private bool DiChuyen = true;
    public static Gach instance;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this; // gọi lại GamePlayController
    }
	
	
    void Start()
    {
        GamePlayController.action = " ";
        GamePlayController.stopTime = false;
        StartCoroutine(RoiGach());
    }

    IEnumerator RoiGach()
    {
        if (GamePlayController.stopTime == false)
        {
            yield return new WaitForSeconds(0.5f);
            GamePlayController.action = " ";
            Vector3 temp = transform.position;
            temp.y -= 1;
            transform.position = temp; 
        }
        StartCoroutine(RoiGach());     
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (GamePlayController.action == "Right")
           {
               if (target.tag == "Right")
               {
                   Vector3 temp = transform.position;
                   temp.x -= 1;
                   transform.position = temp;
               }
           }

        else if (GamePlayController.action == "Left")
        {
            if (target.tag == "Left")
            {
                Vector3 temp = transform.position;
                temp.x += 1;
                transform.position = temp;
            }
        }
       //else if (GamePlayController.action == "Rotation")
       // {
       //     if (target.tag == "Down" || target.tag == "Left" || target.tag == "Right" || target.tag == "OneGach")
       //     {
       //         Gach.instance.transform.rotation = Quaternion.Euler(0f, 0f, btXoay.gocOld);
       //     }
       // }
        else if (target.tag == "Down" || target.tag == "OneGach")
        {
            if (transform.position.y == 18)
            {
                Debug.Log("GameOver");
            }
            else
            {

                Vector3 temp = transform.position;
                temp.y += 1;
                transform.position = temp;
                GamePlayController.instance.GanVitriKhungHinh();
                GamePlayController.TaoGach = true;
                Destroy(gameObject);
            }

            
        }
       
    }
}
