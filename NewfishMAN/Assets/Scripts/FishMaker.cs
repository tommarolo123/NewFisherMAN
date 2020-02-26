﻿
using UnityEngine;
using System.Collections;
public class FishMaker : MonoBehaviour
{
    public Transform fishHolder;//魚
    public Transform[] genPositions; //魚が生まれ点
    public GameObject[] fishPrefabs;//魚のprefab
    public float waveGenWaitTime = 0.3f; //0.3秒ごとに魚を生成する


    void Start()
    {
        InvokeRepeating("MakeFishes", 0, waveGenWaitTime);

    }

    void MakeFishes()
    {

        int genPosIndex = Random.Range(0, genPositions.Length);//ランダムの位置から魚を生成する
        int fishPreIndex = Random.Range(0, fishPrefabs.Length);//ランダムに魚を生成する

        int maxNum = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxNum;
        int maxSpeed = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxSpeed;
        //生成されたそれぞれの魚の最大速度と数量を取得
        int num = Random.Range((maxNum / 2) + 1, maxNum);//生成される量が1から最大
        int speed = Random.Range(maxSpeed / 2, maxSpeed);
        int moveType = Random.Range(0, 2); //0の場合まっすぐ　2は曲がる
        int angOffset;//まっすぐの場合　x軸との角度
        int angSpeed;//曲がる角スピード 
        
        if (moveType == 0)
        {
            angOffset = Random.Range(-22, 22);
            // 画面に入る魚群の角度範囲 
            GenStraightFish(genPosIndex, fishPreIndex, num, speed, angOffset);
            //まっすぐ魚群
        }
        else
        {
            //曲がる.
        }
    }
    void GenStraightFish(int genPosIndex,int fishPreIndex,int num,int speed,int angOffset)
    {
        for (int i = 0;i<num;i++)
        {
            GameObject fish = Instantiate(fishPrefabs[fishPreIndex]);
            fish.transform.SetParent(fishHolder, false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.transform.Rotate(0, 0, angOffset);
            //魚群を生成する
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            }

    }
}
