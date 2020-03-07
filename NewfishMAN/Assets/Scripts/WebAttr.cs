using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAttr : MonoBehaviour
{
    public float disapperTime;//消える時間
    public int damage;//威力

    private void Start()
    {
        Destroy(gameObject, disapperTime);//綱が消える
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fish")
        {

            collision.SendMessage("TakeDamage",damage);//綱の攻撃威力をTakeDamageに渡して、メッソドを実行する
        }
    }

}
