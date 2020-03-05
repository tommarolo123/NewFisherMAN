using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int lv = 0;
    public Transform bulletHolder;
    public Text oneShootCostText; //一発の金額cost
    public GameObject[] gunGos;
    private int costIndex = 0;
    //今使っている弾
    public GameObject[] bullet1Gos;
    public GameObject[] bullet2Gos;
    public GameObject[] bullet3Gos;
    public GameObject[] bullet4Gos;
    public GameObject[] bullet5Gos;
    private int[] oneShootCosts  = { 5,10,20,30,40,50,60,70,80,90,100,200,300,400,500,600,700,800,900,1000};//一発かかるゴールド

    void Update()
    {
        Fire();
        ChangeBulletCost();
    }

    void Fire()
    {
        GameObject[] useBullets = bullet5Gos;
        int bulletIndex;
        if (Input.GetMouseButtonDown(0))
        {
            switch (costIndex / 4) //今の鉄砲
            {
                case 0: useBullets = bullet1Gos; break;
                case 1: useBullets = bullet2Gos; break;
                case 2: useBullets = bullet3Gos; break;
                case 3: useBullets = bullet4Gos; break;
                case 4: useBullets = bullet5Gos; break;
            }
            bulletIndex = (lv % 10 >= 9) ? 9 : lv % 10;//lv 10ごとに弾の色を変える
            GameObject bullet = Instantiate(useBullets[bulletIndex]);
            bullet.transform.SetParent(bulletHolder, false);
            bullet.transform.position = gunGos[costIndex / 4].transform.Find("FirePos").transform.position;//発射位置
            bullet.transform.rotation = gunGos[costIndex / 4].transform.Find("FirePos").transform.rotation;
            
            bullet.AddComponent<Ef_AutoMove>().Dir = Vector3.up;//弾飛び
            bullet.GetComponent<Ef_AutoMove>().speed = 10f;
        } 
    } 
    void ChangeBulletCost()//マウスのスクロールで鉄砲を切り替え
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            OnButtonMDoown();
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            OnButtonPDown();
        }
    }
    public void OnButtonPDown()
    {
        gunGos[costIndex / 4].SetActive(false);
        //今の鉄砲を無効
        costIndex++;
        costIndex = (costIndex > oneShootCosts.Length - 1) ? 0 : costIndex; //最大鉄砲の後は0に戻る
        gunGos[costIndex / 4].SetActive(true);
        //次の鉄砲
        oneShootCostText.text = "$" + oneShootCosts[costIndex];
    }

    public void OnButtonMDoown()
    {
        gunGos[costIndex / 4].SetActive(false);
        //今の鉄砲を無効
        costIndex--;
        costIndex = (costIndex < 0) ? oneShootCosts.Length-1 : costIndex; //最大鉄砲の後は0に戻る
        gunGos[costIndex / 4].SetActive(true);
        //次の鉄砲
        oneShootCostText.text = "$" + oneShootCosts[costIndex];
    }


}
