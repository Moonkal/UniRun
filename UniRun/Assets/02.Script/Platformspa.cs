using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �Ѿ� �����⿡�� ���Ǿ��� instantiate

//�Ź� �ʿ�� ���� ����ߴ� instantiate(����) ����� 
//������Ʈ Ǯ�� ����� ��� �Ҳ�����
//������Ʈ Ǯ��
//���� �ʱ⿡ �ʿ��� ��ŭ ������Ʈ�� �̸� �����
//Ǯ �����̿� �׾Ƶδ� ����Դϴ�.
//instantiate�޼��� ó�� ������Ʈ�� �ǽð����� �����ϱ�
//Detory() �޼���ó�� ������Ʈ�� �ǽð����� �ı��ϴ�
//ó���� ������ ���� �䱸�մϴ�.
//���� �޸𸮸� �����ϴ� GC�����ϱ� �����ϴ�.
//���� ���߿� ������Ʈ�� �ʹ� ���� �����ϰų� �ı��ϸ�
//���� ����(������) ������ �߻��� �˴ϴ�.
//������ �����ϰ� �ֱ������� ��Ĺ�ġ �ϴ� ��ũ��Ʈ

public class Platformspa : MonoBehaviour
{
    //������ ������ ���� ������    
    public GameObject platformPrefab;

    //������ ������ ��
    public int count = 3;

    //���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetMin=1.25f;
    //���� ��ġ������ �ð� ���� �ִ밪
    public float timebetMax=2.25f;
       //���� ��ġ������ �ð� ����
    public float timebet;

    //��ġ�� ��ġ��[ �ּ� y��
    public float ymin=-3.5f;
    //��ġ�� ��ġ�� �ִ� y��
    public float ymax=1.5f;
    //��ġ�� ��ġ�� x��
    public float xpos = 20f;

    //�̸� ������ ���ǵ��� ������ �迭
    private GameObject[] platforms;
    //����� ���� ������ ����
    private int currentINdex = 0;

    //�ʹ��� ������ ������ ȭ�� ���� ���ܵ� ��ġ
    private Vector2 poolpos = new Vector2(0,-25);
    //������ ��ġ ����
    private float lastspaTime;
    void Start()
    {
        //������ �ʱ�ȭ;�ϰ� ����� ������ �̸� ����

        //count ��ŭ�� ������ ������ �����ο� ���� ����
        platforms = new GameObject[count];


        //count ��ŭ �����ϸ鼭 ���� ����
        for (int i = 0; i < count; i++) {
            //platformPrefa�� �������� �� ������
            //poolpos��ġ�� ���� ����
            //������ ��ǻ������ platforms �迭�� �Ҵ�

            platforms[i] = Instantiate(platformPrefab,poolpos,Quaternion.identity);
            
            /*Quaternion.Equals(new Vector3(0,0,0))*/

        }

        //������ ��ġ ���� �ʱ�ȭ
        lastspaTime = 0f;
        //������ ��ġ ������ �ð� ������ �ʱ�ȭ
        timebet = 0f;

    }
     
    // Update is called once per frame
    void Update()
    {
        //������ ���ư��� �ֱ��� ������ ��ġ  

        //���� ���� ���¿����� �������� ����

        if (GameManager.Instanse.isGameOver) return;

        //������ ��ġ �������� Timebet �̻� �ð��� �귶�ٸ�

        if (Time.time >= lastspaTime + timebet) {

            //��ϵ� ��¢�� ��ġ ������ ���� �������� ����
            lastspaTime = Time.time;

            //���� ��ġ������ �ð� ������ timebetspamin
            //timbetspa max  ���̿��� ���� ��������\
            timebet = Random.Range(timeBetMin, timebetMax);
            //��ġ�� ��ġ�� ���̸� ymin�� ymax ���̿��� ���� ��������

            float ypos = Random.Range(ymin, ymax);


            //����� ���� ������ ���� ���� ������Ʈ�� ��Ȱ��ȭ�ϰ�
            //�ٷ� �׽� �ٽ� Ȱ��ȭ  �� �� ������ platform������Ʈ�� \

            //onenable �޼��尡 �����
            platforms[currentINdex].SetActive(false);
            platforms[currentINdex].SetActive(true);

            //���� ������ ���Ǥ��� ȭ�� �����ʿ� ���ġ
            platforms[currentINdex].transform.position = new Vector2(xpos, ypos);
            //���� �ѱ��
            currentINdex++;
            //������ ������ �����ߴٸ�

            if (currentINdex >= count) {
                currentINdex = 0;
            }

        }


    }
}
