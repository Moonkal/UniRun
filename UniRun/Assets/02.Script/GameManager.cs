using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //���� ���� ���¸� ǥ���ϰ� ���� ������ UI�� �����ϴ� �޴���
    //������ �� �ϳ��� ���� �Ŵ����� ������ �� ����

    public static GameManager Instanse;
    //�̱����� �Ҵ��ϴ� ���� ����
    public bool isGameOver = false;//���� ���� ����
    public Text scoreText;//������ ����� UI�ؚ�ó

    public GameObject gameOverUI;




    private int score = 0;//���� ����
    //���� ���۰� ���ÿ� �̱����� ����
    private void Awake()
    {
        //�̱��� �ν��Ͻ� �� ��� �ֳ���?
        if (Instanse == null)
        {
            //�ν��Ͻ��� ����ִٸ� �װ��� �� �ڽ��� �Ҵ�
            Instanse = this;

        }
        else {

            //�ν��Ͻ��� �̹�  �ٸ� gamemanager������Ʈ��
            //�Ҵ�Ǿ� �ִٸ�
            //���� �ΰ��̻��� gamemanager������Ʈ�� �����Ѵٴ� ���̤�
            //�̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ�
            //�ڽ��� ���� ������Ʈ�� �ı�

            Destroy(gameObject);
        
        }
    }


    // ���� ���� ���¿��� ������ ������� �� �ְ� ó��
    void Update()
    {
        //���ӿ��� ���¿��� ����ڰ� ���콺 ���� ��ư�� Ŭ���Ѥ��ٸ�

        if (isGameOver && Input.GetMouseButtonDown(0)) {


            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    //������ ���� ��Ű�� �޼ҵ�

    public void AddScore(int newScore) {

        //���� ������ �ƴ϶��
        if (!isGameOver) {
            //������ ����������
            score += newScore;
            scoreText.text = "Score : " + score;
        }

    }

    //�÷��̾� ĳ���Ͱ� ����� ���ӿ����� �����ϴ� �޼ҵ�

    public void OnPlayerDead() {
        isGameOver = true;
        gameOverUI.SetActive(true);
    } 
}
