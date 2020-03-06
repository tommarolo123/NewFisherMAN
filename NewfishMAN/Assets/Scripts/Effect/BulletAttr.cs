using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttr : MonoBehaviour
{

    public int speed;//弾のスピード
    public int damage;//威力
    public GameObject webPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Border")
        {
            Destroy(gameObject); //boderに当たったら

        }
        if (collision.tag == "Fish")//魚に当たったら
        {
            GameObject web = Instantiate(webPrefab);//綱生成
            web.transform.SetParent(gameObject.transform.parent,false);//弾と同じ
            web.transform.position = gameObject.transform.position;//位置
            
            Destroy(gameObject);
        }
    }


}
