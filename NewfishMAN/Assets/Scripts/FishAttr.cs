
using UnityEngine;

public class FishAttr : MonoBehaviour
{
    public int hp;//魚の命
    public int exp;
    public int gold; 
    public int maxNum;
    public int maxSpeed;
    public GameObject diePrefabs;
    public GameObject goldPrefabs;//魚死ぬときgold
    private void OnTriggerEnter2D(Collider2D collision) //魚がborderにぶつかったらなくす　　　　
    {
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }

    }


    void TakeDamage(int value) //綱が魚を攻撃,死亡　
    {
        hp -= value;
        if (hp<=0)
        {
            GameController.Instance.gold += gold;
            GameController.Instance.exp += exp;
            GameObject die = Instantiate(diePrefabs);
            die.transform.SetParent(gameObject.transform.parent, false);
            die.transform.position = transform.position;
            die.transform.rotation = transform.rotation;
            GameObject goldGo = Instantiate(goldPrefabs);
            goldGo.transform.SetParent(gameObject.transform.parent, false);
            goldGo.transform.position = transform.position;
            goldGo.transform.rotation = transform.rotation;
            Destroy(gameObject);

        }
    }
}
