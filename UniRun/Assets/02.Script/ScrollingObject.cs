using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 오브젝트를 지속적으로 왼쪽으로 움직이는 스크립트
public class ScrollingObject : MonoBehaviour
{
    public float speed=8f;// 이동 속도

    // Update is called once per frame
    void Update()
    {
        //초당 스피드 의 속도로 왼쪽으로 평행 이동 구현
        if (!GameManager.Instanse.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
