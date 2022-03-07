using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ �̵��� ����� ������ ������ ���ġ
public class BakcGround_loop : MonoBehaviour
{
    //����� ���� ����
    private float width;
    // Start is called before the first frame update
    //  ����Ƽ �̺�Ʈ �޼���
    private void Awake()
    {
        //Awake() method�� Start �޼ҵ� ó�� �ʱ� 1ȸ �ڵ� �����ϴ� ����Ƽ �̺�Ʈ �żҵ� �Դϴ�.
        //������ start�޼ҵ庸�� ���� ������ �������� �� �����ϴ�.
        //�����ϼ���
        //unity Method LifeCycle
        // ���� ���̸� ����
        // 
        //BoxCollider2D ������Ʈ�� size�ʵ��� x���� ���� ���̷� ���
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
    }
    // Update is called once per frame
    void Update()
    {

        //������ġ��  �������� �������� width �̻� �̵��� �� 
        //��ġ�� ���ġ ��
        if (transform.position.x <= -width) {
            RePosition();
        }
        
    }
    void RePosition() {
        //��ġ�� ���ġ�ϴ� �޼���
        //���� ��ġ���� ���������� ���α��� *2��ŭ �̵�
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position  = (Vector2)transform.position + offset;
        //width 20.48*2=40.48
        //-20.48+40.48=20.48
    }
}
