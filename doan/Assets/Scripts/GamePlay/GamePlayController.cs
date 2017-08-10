using UnityEngine;
using System.Collections;

public class GamePlayController : MonoBehaviour
{

    public static GamePlayController instance;
    public static MathUnity MU = new MathUnity();
    public static bool TaoGach = true;
    public static int loaiGach = 0;
    public static int[,] khungHinh = new int[15, 22]; // khung hinh gom 14*20 phan tu 

    public static string action = " ";
    public static bool stopTime = false;
    public static int Soluong = 0;
    public static bool xoaGach = false;
    public static bool TinHieu = false;
    public static int vitriXoaDauTien = 20;

    public static int Begin, End;


    private GameObject[] gach = new GameObject[7];
    [SerializeField]
    private GameObject V, S, Z, T, I, L, J, gachCon, Delete;



    void Awake()
    {
        MakeInstance();

        gach[0] = V;
        gach[1] = S;
        gach[2] = Z;
        gach[3] = I;
        gach[4] = T;
        gach[5] = L;
        gach[6] = J;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                khungHinh[j, i] = 0;
            }
        }

        RandomGach();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }


    void Update()
    {
        RandomGach();
    }

    public void RandomGach()
    {
        if (TaoGach)
        {
            loaiGach = Random.Range(0, 6);
            Vector3 temp = transform.position;
            temp.x = 7; // vi tri x chinh giua
            temp.y = 18; // vi tri y tren dau.
            Instantiate(gach[loaiGach], temp, Quaternion.identity);
            TaoGach = false;
        }
    }


    public bool KiemTraDiChuyen(int gioiHan)
    {

        if (MU.ToInt(GachCon4.instance.transform.position.x) == gioiHan)
            return true;
        else if (MU.ToInt(GachCon3.instance.transform.position.x) == gioiHan)
            return true;
        else if (MU.ToInt(GachCon2.instance.transform.position.x) == gioiHan)
            return true;
        else if (MU.ToInt(GachCon1.instance.transform.position.x) == gioiHan)
            return true;


        return false;
    }

    public bool KiemTraTrung(int DiChuyen)
    {
        if (khungHinh[MU.ToInt(GachCon4.instance.transform.position.x) + DiChuyen, MU.ToInt(GachCon4.instance.transform.position.y)] != 0)
            return true;
        else if (khungHinh[MU.ToInt(GachCon3.instance.transform.position.x) + DiChuyen, MU.ToInt(GachCon3.instance.transform.position.y)] != 0)
            return true;
        else if (khungHinh[MU.ToInt(GachCon2.instance.transform.position.x) + DiChuyen, MU.ToInt(GachCon2.instance.transform.position.y)] != 0)
            return true;
        else if (khungHinh[MU.ToInt(GachCon1.instance.transform.position.x) + DiChuyen, MU.ToInt(GachCon1.instance.transform.position.y)] != 0)
            return true;
        return false;
    }


    public void GanVitriKhungHinh()
    {
        stopTime = true;
        khungHinh[MU.ToInt(GachCon1.instance.transform.position.x), MU.ToInt(GachCon1.instance.transform.position.y)] = 1;
        Instantiate(gachCon, GachCon1.instance.transform.position, Quaternion.identity);

        khungHinh[MU.ToInt(GachCon2.instance.transform.position.x), MU.ToInt(GachCon2.instance.transform.position.y)] = 1;
        Instantiate(gachCon, GachCon2.instance.transform.position, Quaternion.identity);

        khungHinh[MU.ToInt(GachCon3.instance.transform.position.x), MU.ToInt(GachCon3.instance.transform.position.y)] = 1;
        Instantiate(gachCon, GachCon3.instance.transform.position, Quaternion.identity);

        khungHinh[MU.ToInt(GachCon4.instance.transform.position.x), MU.ToInt(GachCon4.instance.transform.position.y)] = 1;
        Instantiate(gachCon, GachCon4.instance.transform.position, Quaternion.identity);

        DuyetGach(); // kiem tra xem co du 1 hang gach hay ko ?

    }

    public int VitriDiemCham()
    {
        int vitri = 19;
        if (vitri > GachCon1.instance.transform.position.y)
            vitri = MU.ToInt(GachCon1.instance.transform.position.y);
        if (vitri > GachCon2.instance.transform.position.y)
            vitri = MU.ToInt(GachCon2.instance.transform.position.y);
        if (vitri > GachCon3.instance.transform.position.y)
            vitri = MU.ToInt(GachCon3.instance.transform.position.y);
        if (vitri > GachCon4.instance.transform.position.y)
            vitri = MU.ToInt(GachCon4.instance.transform.position.y);
        return vitri;
    }

    public int RowNull(int begin)
    {
        for (int i = begin; i <= 19; i++)
        {
            for (int j = 0; j <= 13; j++)
            {
                if (khungHinh[j, i] != 0)
                    break;
                else if (khungHinh[j, i] == 0 && j == 13)
                {
                    return i;
                }
            }
        }
        return 19;
    }

    public void DelRow(int Begin, int End)
    {
        Vector3 temp = Vector3.zero;
        temp.x = 0;
        temp.y = Begin;
        Instantiate(Delete, temp, Quaternion.identity);
        DiemXoa.instance.End = End;
        DiemXoa.instance.Begin = Begin;

    }


    public bool CheckOneRow(int i)
    {
        for (int j = 0; j <= 13; j++)
        {
            if (khungHinh[j, i] != 0 && j == 13)
            {
                return true;
            }
            else if (khungHinh[j, i] == 0)
                return false;
        }
        return false;
    }

    public void DuyetGach()
    {
        Begin = VitriDiemCham();
        End = RowNull(VitriDiemCham());
        int tempEnd = End;
        TinHieu = false;
        for (int i = Begin; i < tempEnd; i++)
        {
            if (CheckOneRow(i))
            {
                if (vitriXoaDauTien > i)
                    vitriXoaDauTien = i;

                    TinHieu = true;
                    for (int itemp = i; itemp < tempEnd; itemp++)
                    {
                        for (int j = 0; j < 14; j++)
                        {
                            khungHinh[j, itemp] = khungHinh[j, itemp + 1];
                        }

                    }
                    tempEnd--;
                    i--;
                }
            }
        if (TinHieu)
        {
            DelRow(Begin, End);
        }
    }


    public void NewHinh(int begin, int end) // gia tri am
    {
        Debug.Log(begin + "| " + end);
        Debug.Log("new");
        Vector3 temp = Vector3.zero;
        for (int i = begin; i <= end; i++) // i >= -end
        {
            Debug.Log("hang: " + i);
            for (int j = 0; j < 14; j++)
            {
                if (khungHinh[j, i] != 0)
                {
                    temp.x = j;
                    temp.y = i;
                    Instantiate(gachCon, temp, Quaternion.identity);
                    Debug.Log(temp.x + " | " + temp.y);
                }
            }

        }

        stopTime = false;
    }


}
