
using UnityEngine;

public class Ef_AutoMove : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 Dir = Vector3.right;//x軸正方向
    　
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Dir * speed*Time.deltaTime);//移動  
    }
}
