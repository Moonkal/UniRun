using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임 오버 상태를 표현하고 게임 점수와 UI를 관리하는 메니저
    //씬에는 단 하나의 게임 매니저만 존재할 수 있음

    public static GameManager Instanse;
    //싱글턴을 할당하는 전역 변수
    public bool isGameOver = false;//게임 오버 상태
    public Text scoreText;//점수를 출력할 UI텍슽처

    public GameObject gameOverUI;




    private int score = 0;//게임 점수
    //게임 시작과 동시에 싱글턴을 구성
    private void Awake()
    {
        //싱글턴 인스턴스 가 비어 있나요?
        if (Instanse == null)
        {
            //인스턴스가 비어있다면 그곳에 내 자신을 할당
            Instanse = this;

        }
        else {

            //인스턴스에 이미  다른 gamemanager오브젝트가
            //할당되어 있다면
            //씬에 두개이상의 gamemanager오브젝트가 존재한다는 으미ㅣ
            //싱글턴 오브젝트는 하나만 존재해야 하므로
            //자신의 게임 오브젝트를 파괴

            Destroy(gameObject);
        
        }
    }


    // 게임 오버 상태에서 게임을 재시작할 수 있게 처리
    void Update()
    {
        //게임오버 상태에서 사용자가 마우스 왼쪽 버튼을 클릭한ㅇ다면

        if (isGameOver && Input.GetMouseButtonDown(0)) {


            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    //점수를 증가 시키는 메소드

    public void AddScore(int newScore) {

        //게임 오버가 아니라면
        if (!isGameOver) {
            //점수를 증가시켜줌
            score += newScore;
            scoreText.text = "Score : " + score;
        }

    }

    //플래이어 캐릭터가 사망시 게임오버를 실행하는 메소드

    public void OnPlayerDead() {
        isGameOver = true;
        gameOverUI.SetActive(true);
    } 
}
