using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    //�������μ� �ʿ��� ������ ���� ��ũ��Ʈ
    // Start is called before the first frame update
    //��ֹ� ������Ʈ�� ��� �迭
    public GameObject[] abs;
    //�÷��̾� ĳ���Ͱ� ��Ҵ���
    private bool stepSpeed;
    // ���ο� ����Ƽ �̺�Ʈ �޼��带 Ȯ��

    private void OnEnable()
    {
        //awake()�� start() ���� ����Ƽ �޼��� �Դϴ�.
        //Start �޼���ó�� ������Ʈ�� Ȱ��ȭ �ɶ� �ڵ����� �ѹ� ����Ǵ� �޼����Դϴ�.
        //ó�� �ѹ��� ����Ǵ� start �޼���� �޸�
        //OnEnable �޼���,�� ������Ʈ�� Ȱ��ȭ �ɶ� ����
        //�Ź� �ٽ� ����ǳ��Ѥ� �޼���� ������Ʈ�� ���� �ٽ�

        //�Ѵ� ������� ������ �� �ִ� �޼����Դϴ�.
        //������ �����ϴ� ó��
        //���� ���¸�����
        stepSpeed = false;

        //��ֹ��� ����ŭ ����
        for (int i = 0; i < abs.Length; i++) {
            //���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
            if (Random.Range(0, 3) == 0)
            {
                abs[i].SetActive(true);

            }
            else {
                abs[i].SetActive(false);
            }
        }





    }
    // �÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�浹�� ������ �±װ� Player �̰�
        //������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        if (collision.collider.tag == "Player" && !stepSpeed)
        {
            //������ �߰��ϰ� ���� ���¸� ������ ����
            stepSpeed = true;
            GameManager.Instanse.AddScore(1);
        }



    }




}
