
using UnityEngine;

public class FishMaker : MonoBehaviour
{
    public Transform fishHolder;//魚
    public Transform[] genPositions; //魚が生まれ点
    public GameObject[] fishPrafabs;//魚のprefab
    

    void MakeFishes()
    {
        int genPosIndex = Random.Range(0, genPositions.Length);//ランダムの位置から魚を生成する
        int fishPreIndex = Random.Range(0, fishPrafabs.Length);//ランダムに魚を生成する
                                                             
        int maxNum = fishPrafabs[fishPreIndex].GetComponent<FishAttr>().maxNum;  //魚の最大生成量とスピード
        int maxSpeed = fishPrafabs[fishPreIndex].GetComponent<FishAttr>().maxSpeed;
        int num = Random.Range((maxNum / 2) + 1, maxNum);//生成される量が1から最大
        int speed = Random.Range(maxSpeed / 2, maxSpeed);
        int moveType = Random.Range(0, 2); //0の場合まっすぐ　2は曲がる
        int angOffset;//まっすぐの場合　x軸との角度
        int angSpeed;//曲がる角スピード
        
        if (moveType == 0)
        {
            //まっすぐ魚群
        }
        else
        {
            //曲がる.
        }
    }

}
