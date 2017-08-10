﻿using UnityEngine;
using System.Collections;

public class DiemXoa : MonoBehaviour
{
    public static DiemXoa instance;
    public MathUnity MU = new MathUnity();
    private Vector3 vitri = Vector3.zero;
    public int Begin, End;


    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    void Awake()
    {
        MakeInstance();
        StartCoroutine(DiChuyen());

    }

    IEnumerator DiChuyen()
    {
        yield return new WaitForSeconds(0f);
        vitri = transform.position;
        if (vitri.x >= 13)
        {
            if (vitri.y == End)
            {
                GamePlayController.instance.NewHinh(Begin, End);
                Destroy(gameObject);
            }
            else
            {
                vitri.x = 0;
                vitri.y += 1;
                transform.position = vitri;
                StartCoroutine(DiChuyen());
            }
        }
        else
        {
            vitri.x += 1;
            transform.position = vitri;
            StartCoroutine(DiChuyen());
        }

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "OneGach")
        {
            Destroy(target.gameObject);
        }

    }

}
