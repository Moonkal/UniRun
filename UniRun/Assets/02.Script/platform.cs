using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    //발판으로서 필요한 동작을 담은 스크립트
    // Start is called before the first frame update
    //장애물 오브젝트를 담는 배열
    public GameObject[] abs;
    //플레이어 캐릭터가 밟았는지
    private bool stepSpeed;
    // 새로운 유니티 이벤트 메서드를 확인

    private void OnEnable()
    {
        //awake()나 start() 같은 유니티 메서드 입니다.
        //Start 메서드처럼 컴포넌트가 활성화 될때 자동으로 한번 실행되는 메서드입니다.
        //처음 한번만 실행되는 start 메서드와 달리
        //OnEnable 메서드,는 컴포넌트가 활성화 될때 마다
        //매번 다시 실행되나ㅡㄴ 메서드라서 컴포넌트를 끄고 다시

        //켜는 방식으로 재실행될 수 있는 메서드입니다.
        //발판을 리셋하는 처리
        //밟힌 상태를리셋
        stepSpeed = false;

        //장애물의 수만큼 루프
        for (int i = 0; i < abs.Length; i++) {
            //현재 순번의 장애물을 1/3의 확률로 활성화
            if (Random.Range(0, 3) == 0)
            {
                abs[i].SetActive(true);

            }
            else {
                abs[i].SetActive(false);
            }
        }





    }
    // 플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌한 상대방의 태그가 Player 이고
        //이전에 플레이어 캐릭터가 밟지 않았다면
        if (collision.collider.tag == "Player" && !stepSpeed)
        {
            //점수를 추가하고 밟힌 상태를 참으로 변경
            stepSpeed = true;
            GameManager.Instanse.AddScore(1);
        }



    }




}
