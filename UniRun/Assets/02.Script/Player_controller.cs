using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//player controle�� �÷��̾� ĳ���ͷμ�  player���� ������Ʈ ������
public class Player_controller : MonoBehaviour
{
    //�÷��̾� ����� ����� ����� Ŭ��
    public AudioClip deathClip;
    public float jumpForse = 700f;

    //���� ���� ȸ��
    private int jumpCount = 0;

    //�÷��̾ �ٴڿ� ��Ҵ��� Ȯ��
    private bool isGrounded = false;
    //�� �����̾ ����ߴ��� �������
    private bool isDead = false;
    //����� ������ٵ� ������Ʈ
    private Rigidbody2D playerRigidbody;
    //����� ����� �ҽ� ������Ʈ
    private AudioSource playerAudio;

    //����� �ִϸ���;�� ������Ʈ 
    private Animator animator;
        
        // Start is called before the first frame update
    void Start()
    {
        //���������� �� �ʱ�ȭ ����
        //���� ������Ʈ�� ���� ����� ������Ʈ���� ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //������� �Է��� �����ϰ� �����ϴ� ó��
        //1.���� ��Ȳ�� �˸��� �ִϸ��̼� ���
        //2.���콺�� ���� Ŭ���� �����ϰ� ������ �� �� �ְ� ����
        //3.���콺 ���� ��ư�� ���� ������ ���� �����ϰ� �� ó��
        //4. �ִ� ����Ƚ���� �����ϸ� ������ ���ϰ� ����

        //����� ���̻� ó���� �������� �ʰ� �����ϴ� ó���� ����
        if (isDead) return;
        //���콺 ���� ��ư�� ��������& �ִ� ����Ƚ�� (2)�� �������� �ʾҴٸ� 
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //���� Ƚ���� ���� 
            jumpCount++;
            // ���������� �ӵ��� ���������� ����(0,0)�� ����
            // ���� ���������� �� �Ǵ� �ӵ��� ���ǰų� �������� 
            //���� ���̰� ���ϰ������� �Ǵ� ������ ��������
            playerRigidbody.velocity = Vector2.zero;
            //������ �ٵ� �������� ���ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForse));

            //������� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0) {
            //���콺 ���� ��ư���� ���� ���� ������ �ӵ��� y���� ������(���� ��� ��)
            //����ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
            
        }

        //�ִϸ������� grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);

        
    }

    void Die() {
        //���ó���ϴ� ��ũ��Ʈ
        //�ִϸ������� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");


        //audio �ҽ��� �Ҵ�� ����� Ŭ���� deathclip���� ����
        playerAudio.clip = deathClip;
        //
        //��� ȿ���� ���
        playerAudio.Play();

        //�ӵ��� ����(0,0)
        playerRigidbody.velocity = Vector2.zero;
        //�� ����߾� ������¸� true��
        isDead = true;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾ �ٴڿ� ���� ���� �����ϴ� ó��
        //� �ݶ��̴��� ������� �浹 ǥ���� ������ ���� �ִ���
        if (collision.contacts[0].normal.y > 0.7f) {
            //contacts�� �浹 �������� ������ ��� 
            // contactPointŸ���� �����͸� contacts��� �迭 ������ �������
            //normar ���浹 �������� �浹 ǥ���� ���� (�븻 ����)
            //�� �˷��ִ� �����Դϴ�.


            //isgrounded�� true�� �����ϰ�  ���� ���� Ƚ���� 
            //0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ����ڸ��� ó��

        //� �ݶ��̴����� ������ ��� is grounded�� false ����
        isGrounded = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹 ����
        if (collision.tag == "Dead" && !isDead) {
            Die();
        }
        //�浹�� ������ �±װ� dead�ΰ���?
       



    }
    //�浹 ����Ƽ �浹 �پ��� ���
    // �w���� ũ�� �ΰ����� ����
    //1.Oncollider���迵�� enter stay exit
    //2.ontirigger�迭  enter stay exit

    // OnCollision �迭�� �� �ݶ��̴� ������ �浹���� 
    //���ϳ��� istrigger�� üũ�� �ǤӾ� ���� ���� ��� 
    //ontrigger r�迭�� ���ϳ��� istrigger�� üũ�Ǿ� ���� �� ���
}
