using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            return _instance;

        }

    }

    public Transform bulletHolder;
    public Text oneShootCostText; //一発の金額cost
    public GameObject[] gunGos;
    public Text goldText;
    public Text lvText;
    public Text lvNameText;//レベルに応じる称号
    public Text smallCountdownText;//左下
    public Text bigCountdownText;//右上
    public Button bigCountdownButton;//時計が0になったら押すとgoldボーナス
    public Button backButton;
    public Button settingButton;
    public Slider expSlider;
    

    public int lv = 0;
    public int gold = 500;
    public int exp = 0;
    public const int bigCountdown = 240;
    public const int smallCountdown = 60;
    public float bigTimer = bigCountdown;
    public float smallTimer = smallCountdown;
    public Color goldColor;
    //初期化   

   
    
    private int costIndex = 0;//今使っている弾
    public GameObject[] bullet1Gos;
    public GameObject[] bullet2Gos;
    public GameObject[] bullet3Gos;
    public GameObject[] bullet4Gos;
    public GameObject[] bullet5Gos;
    private int[] oneShootCosts  = { 5,10,20,30,40,50,60,70,80,90,100,200,300,400,500,600,700,800,900,1000};//一発かかるゴールド
    private string[] lvName = { "初心", "入門" ,"鉄", "銅", "銀","金","ダイヤ","師匠","大漁師"};

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        Fire();
        ChangeBulletCost();
        UpdateUI();
    }

    void UpdateUI()　
    {

        bigTimer -= Time.deltaTime;
        smallTimer -= Time.deltaTime;
        if (smallTimer<=0)//smallボーナス　自動
        {
            smallTimer = smallCountdown;//戻す
            gold += 50;

        }
        
        if (bigTimer <= 0 && bigCountdownButton.gameObject.activeSelf==false)　//ボタンによるビッグボーナス　手動 タイマーが＜＝０またボタンがないとき

        {
            bigCountdownText.gameObject.SetActive(false);//タイマーを隠す
            bigCountdownButton.gameObject.SetActive(true);//ボタン

        }

     
    while (exp >= 1000 + 200 * lv)//exp計算：次のレベル＝1000+200*現在レベルexp
        {

            lv++;
            exp = exp - (1000 + 200 * lv);
             
        }
        goldText.text = "$" + gold;
        lvText.text = lv.ToString();
        if ((lv/10)<=9) //レベル99以上の場合　大漁師
        {
            lvNameText.text = lvName[lv / 10];
        }
        else
        {
            lvNameText.text = lvName[9];
        }
        smallCountdownText.text =  (int)smallTimer / 10 + "  " + (int)smallTimer % 10;//左下タイマーを表す
        bigCountdownText.text = (int)bigTimer + "s";//右上のタイマー
        expSlider.value = ((float)exp) /(1000 + 200 * lv);//expスライドの表示


          }


    void Fire()
    {
        GameObject[] useBullets = bullet5Gos;
        int bulletIndex;
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false) //クリックするときUIをよける。弾でないように
        {
            if(gold-oneShootCosts[costIndex]>=0)//goldチェック
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
                gold -= oneShootCosts[costIndex]; //goldをかかる    
                GameObject bullet = Instantiate(useBullets[bulletIndex]);
                bullet.transform.SetParent(bulletHolder, false);
                bullet.transform.position = gunGos[costIndex / 4].transform.Find("FirePos").transform.position;//発射位置
                bullet.transform.rotation = gunGos[costIndex / 4].transform.Find("FirePos").transform.rotation;

                bullet.AddComponent<Ef_AutoMove>().Dir = Vector3.up;//弾飛び
                bullet.GetComponent<Ef_AutoMove>().speed = bullet.GetComponent<BulletAttr>().speed;
                bullet.GetComponent<BulletAttr>().damage = oneShootCosts[costIndex];//弾のcost　
            }

            else
            {
                StartCoroutine(GoldNotEnough());
            }
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
    public void OnBigCountdownButton()
    
        {
        gold += 500;
        bigCountdownButton.gameObject.SetActive(false); //ボーナスボタン隠す
        bigCountdownText.gameObject.SetActive(true);
        bigTimer = bigCountdown;　//タイマーを戻す
        }

    IEnumerator GoldNotEnough() //gold足りない場合　アニメーション
    {
        
         goldText.color = Color.red;
         yield return new WaitForSeconds(0.5f);
         goldText.color = Color.yellow;
       
    }

}
