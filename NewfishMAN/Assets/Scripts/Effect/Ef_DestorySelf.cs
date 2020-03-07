using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_DestorySelf : MonoBehaviour
{

    public float delay = 1f;//捕獲された魚を消えさせる時間


    private void Start()
    {
        Destroy(gameObject, delay);
    }
}
