
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public RectTransform UGUICanvas;
    public Camera mainCamera;
    void Update()
    {
        Vector3 mousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(UGUICanvas, new Vector2(Input.mousePosition.x,
            Input.mousePosition.y), mainCamera, out mousePos);
        //canvasの中マウスのポジション
        float z;
        if (mousePos.x>transform.position.x)
        {
            z = -Vector3.Angle(Vector3.up, mousePos - transform.position);//鉄砲の方向とマウスの角度
        }
        else
        {
            z = Vector3.Angle(Vector3.up, mousePos - transform.position);//鉄砲の方向とマウスの角度
        }

        transform.localRotation = Quaternion.Euler(0, 0, z); 
    }
}
