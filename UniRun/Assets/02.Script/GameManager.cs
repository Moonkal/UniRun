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



        public GameObject menuPanel;
    public int hpCount = 2;// ���� ����� ����� 
    public Text hpText;//����ڿ��� ������ ����� UI
    
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

    private void Start()
    {
        //����ڿ��� ������ ������� ���� ��������� ���
        hpText.text = hpCount.ToString();
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
        //������¸�  ���ӿ��� ���·� ����
        isGameOver = true;
        gameOverUI.SetActive(true);

        //���� ��ư Ȱ��ȭ
        
    }


    public void Onmenu() {

        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Offmenu() {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;


    }


    public void Exit()
    {
        Application.Quit();
    }
    
    public void ReStrat() {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
                }

    public bool crash() {



        hpText.text = "" + --hpCount;

        if (hpCount <= 0) return true;
        return false;

    }
}
