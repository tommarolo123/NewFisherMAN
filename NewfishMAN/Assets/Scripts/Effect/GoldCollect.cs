
using UnityEngine;

public class GoldCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gold")
        {
           // AudiManager.Instance.PlayEffectSound(AudiManager.Instance.goldClip);
            Destroy(collision.gameObject);
        }
    }
}
