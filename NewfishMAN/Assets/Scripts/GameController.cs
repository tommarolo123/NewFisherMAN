using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Text oneShootCostText; //一発の金額cost
    public GameObject[] gunGos;
    private int costIndex = 0;
    //今使っている弾
    private int[] oneShootCosts  = { 5,10,20,30,40,50,60,70,80,90,100,200,300,400,500,600,700,800,900,1000};//一発かかるゴールド

    void Update()
    {
        ChangeBulletCost();
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
