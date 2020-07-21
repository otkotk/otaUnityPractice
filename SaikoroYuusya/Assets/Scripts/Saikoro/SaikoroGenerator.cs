﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;

public class SaikoroGenerator : MonoBehaviour
{
    public GameObject[] childObj;

    public GameObject[] sucs = new GameObject[8];
    public GameObject[] fais = new GameObject[8];
    public GameObject[] cris = new GameObject[8];

    [SerializeField] private GameObject suc_1;
    [SerializeField] private GameObject fai_1;
    [SerializeField] private GameObject cri_1;
    [SerializeField] private GameObject suc_2;
    [SerializeField] private GameObject fai_2;
    [SerializeField] private GameObject cri_2;
    [SerializeField] private GameObject suc_3;
    [SerializeField] private GameObject fai_3;
    [SerializeField] private GameObject cri_3;
    [SerializeField] private GameObject suc_4;
    [SerializeField] private GameObject fai_4;
    [SerializeField] private GameObject cri_4;
    [SerializeField] private GameObject suc_5;
    [SerializeField] private GameObject fai_5;
    [SerializeField] private GameObject cri_5;
    [SerializeField] private GameObject suc_6;
    [SerializeField] private GameObject fai_6;
    [SerializeField] private GameObject cri_6;
    [SerializeField] private GameObject suc_7;
    [SerializeField] private GameObject fai_7;
    [SerializeField] private GameObject cri_7;
    [SerializeField] private GameObject suc_8;
    [SerializeField] private GameObject fai_8;
    [SerializeField] private GameObject cri_8;


    // サイコロで決める
    private int[] saikoro_1 = new int[] { 1, 1, 1, 1, 1, 2, 2, 3 };
    private int[] saikoro_2;




    // Use this for initialization
    void Start()
    {
        InsertionGameObject();
        ShuffleSaikoro();
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeColor()
    {
        for(int i=0; i<saikoro_2.Length; i++)
        {
            switch (saikoro_2[i])
            {
                case 1:
                    sucs[i].SetActive(true);
                    break;
                case 2:
                    fais[i].SetActive(true);
                    break;
                case 3:
                    cris[i].SetActive(true);
                    break;
            }
        }
        //childObj = GameObject.FindGameObjectsWithTag("Saikoros");
        //int indexxx = 0;
        //foreach(GameObject gb in childObj)
        //{
        //    switch (saikoro_2[indexxx])
        //    {
        //        case 1:
        //            sucs[indexxx].SetActive(true);
        //            break;
        //        case 2:
        //            fais[indexxx].SetActive(true);
        //            break;
        //        case 3:
        //            cris[indexxx].SetActive(true);
        //            break;
        //    }
        //    indexxx += 1;
        //    gb.GetComponent<Image>().color = new Color(0.843f, 0.627f, 0.294f, 0.785f);
        //}
    }

    // サイコロの中身をシャッフルする
    public void ShuffleSaikoro()
    {
        saikoro_2 = saikoro_1.OrderBy(i => Guid.NewGuid()).ToArray();
    }

    // Serializefieldのオブジェクトを、配列に格納する
    public void InsertionGameObject()
    {
        sucs[0] = suc_1;
        fais[0] = fai_1;
        cris[0] = cri_1;
        sucs[1] = suc_2;
        fais[1] = fai_2;
        cris[1] = cri_2;
        sucs[2] = suc_3;
        fais[2] = fai_3;
        cris[2] = cri_3;
        sucs[3] = suc_4;
        fais[3] = fai_4;
        cris[3] = cri_4;
        sucs[4] = suc_5;
        fais[4] = fai_5;
        cris[4] = cri_5;
        sucs[5] = suc_6;
        fais[5] = fai_6;
        cris[5] = cri_6;
        sucs[6] = suc_7;
        fais[6] = fai_7;
        cris[6] = cri_7;
        sucs[7] = suc_8;
        fais[7] = fai_8;
        cris[7] = cri_8;
    }
}
