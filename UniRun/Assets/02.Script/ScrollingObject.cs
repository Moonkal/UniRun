using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������Ʈ�� ���������� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public float speed=8f;// �̵� �ӵ�

    // Update is called once per frame
    void Update()
    {
        //�ʴ� ���ǵ� �� �ӵ��� �������� ���� �̵� ����
        if (!GameManager.Instanse.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
