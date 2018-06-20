using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotate : MonoBehaviour
{
    //中心点
    public Transform pivot;

    //見つめるポイント
    public Transform target;

    void Update()
    {
        ////マウスの方向を求める
        //Vector3 pos = Camera.main.WorldToScreenPoint(pivot.localPosition);
        //Quaternion target_rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);

        //見つめるポイントの方向を求める
        Quaternion target_rotation = Quaternion.LookRotation(target.position, transform.position);

        //目的の角度まで必要な角度を求める
        Quaternion required_rot = target_rotation * Quaternion.Inverse(transform.rotation);

        //xyz軸をそれぞれ回転させる
        transform.RotateAround(
            pivot.position,
            Vector3.forward,
            required_rot.eulerAngles.z
        );
        transform.RotateAround(
            pivot.position,
            Vector3.right,
            required_rot.eulerAngles.x
        );
        transform.RotateAround(
            pivot.position,
            Vector3.up,
            required_rot.eulerAngles.y
        );
    }
}