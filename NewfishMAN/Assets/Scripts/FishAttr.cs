
using UnityEngine;

public class FishAttr : MonoBehaviour
{
    public int maxNum;
    public int maxSpeed;
    private void OnTriggerEnter2D(Collider2D collision) //魚がborderにぶつかったらなくす　　　　
    {
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
