using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Drag : MonoBehaviour
{
    //    public GameObject Kuning1, Kuning2, Kuning3, Kuning4, Hijau1, Hijau2, Hijau3, Hijau4, Merah1, Merah2, Merah3, Merah4, Orange1, Orange2, Orange3, Orange4;
    //    Vector2 Kuning1pos, Kuning2pos, Kuning3pos, Kuning4pos, Hijau1pos, Hijau2pos, Hijau3pos, Hijau4pos, Merah1pos, Merah2pos, Merah3pos, Merah4pos, Orange1pos, Orange2pos, Orange3pos, Orange4pos;

    public GameObject[] item;
    public GameObject[] itemdrop;

    public Vector2[] itempos;
    bool[] isdrop = new bool[4];

    public GameObject panelwin;
    public GameObject panellose;
    public AudioSource source;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip jawabansalah;
    public AudioClip buttondrop;

    public int nilaiKesempatan;
    public TextMeshProUGUI KesempatanTampil;


    void Start()
    {
        nilaiKesempatan = 3;
        KesempatanTampil.text = "Kesempatan : " + nilaiKesempatan;
        for (int i = 0; i < itempos.Length; i++)
        {
            itempos[i] = item[i].transform.localPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ItemDrag(int number)
    {
        if (isdrop[number] == false)
        {
            item[number].transform.position = Input.mousePosition;

        }

    }
    public void ItemEndDrag(int number)
    {
        float distance = Vector3.Distance(item[number].transform.localPosition, itemdrop[number].transform.localPosition);
        if (distance < 100)
        {
            item[number].transform.localPosition = itemdrop[number].transform.localPosition;
            isdrop[number] = true;
            source.clip = buttondrop;
            source.Play();
            Check();
        }
        else
        {
            item[number].transform.localPosition = itempos[number];
            KurangiKesempatan();

        }
    }




    void KurangiKesempatan()
    {
        if (nilaiKesempatan > 1)
        {
            nilaiKesempatan -= 1;
            KesempatanTampil.text = "Kesempatan : " + nilaiKesempatan;
            source.clip = jawabansalah;
            source.Play();

        }
        else
        {
            source.clip = incorrect;
            source.Play();
            panellose.SetActive(true);

        }
    }


    void Check()
    {
        for (int i = 0; i < isdrop.Length; i++)
        {
            if (isdrop[i] == false)
            {

                return;
            }
            else
            {
                if (i == isdrop.Length - 1)
                {
                    source.clip = correct;
                    panelwin.SetActive(true);
                    source.Play();
                }
            }

        }
    }

    public void ButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ButtonHome()
    {
        SceneManager.LoadScene(2);
    }
}
