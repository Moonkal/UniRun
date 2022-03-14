using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이전 총알 생성기에서 사용되었던 instantiate

//매번 필요시 마다 사용했던 instantiate(생성) 방식이 
//오브젝트 풀링 방식을 사용 할꺼에요
//오브젯트 풀링
//게임 초기에 필요한 만큼 오브젝트를 미리 만들어
//풀 웅덩이에 쌓아두는 방식입니다.
//instantiate메서드 처럼 오브젝트를 실시간으로 생성하기
//Detory() 메서드처럼 오브젝트를 실시간으로 파괴하는
//처리는 성능을 많이 요구합니다.
//또한 메모리를 정리하는 GC유발하기 쉽습니다.
//게임 도중에 오브젝트를 너무 자주 생성하거나 파괴하면
//게임 끊김(프리즈) 현상이 발생이 됩니다.
//발판을 생성하고 주기적으로 재ㅔ배치 하는 스크립트

public class Platformspa : MonoBehaviour
{
    //생성할 발판의 원본 프리팹    
    public GameObject platformPrefab;

    //생성할 발판의 수
    public int count = 3;

    //다음 배치까지의 시간 간격 최솟값
    public float timeBetMin=1.25f;
    //다음 배치까지의 시간 간격 최대값
    public float timebetMax=2.25f;
       //다음 배치까지의 시간 간격
    public float timebet;

    //배치한 위치에[ 최소 y값
    public float ymin=-3.5f;
    //배치할 위치에 최대 y값
    public float ymax=1.5f;
    //배치할 위치의 x값
    public float xpos = 20f;

    //미리 생성한 발판들을 보관할 배열
    private GameObject[] platforms;
    //사용할 현재 순번의 발판
    private int currentINdex = 0;

    //초반의 생성한 발판을 화면 위에 숨겨둘 위치
    private Vector2 poolpos = new Vector2(0,-25);
    //마지막 배치 시점
    private float lastspaTime;
    void Start()
    {
        //변수를 초기화;하고 사용할 발판을 미리 생성

        //count 만큼의 공간을 가지느 ㄴ새로운 발판 생성
        platforms = new GameObject[count];


        //count 만큼 루프하면서 발판 생성
        for (int i = 0; i < count; i++) {
            //platformPrefa을 원본으로 새 발판을
            //poolpos위치에 복재 생성
            //생성된 발퓨ㅏㄴ을 platforms 배열에 할당

            platforms[i] = Instantiate(platformPrefab,poolpos,Quaternion.identity);
            
            /*Quaternion.Equals(new Vector3(0,0,0))*/

        }

        //마지막 배치 시점 초기화
        lastspaTime = 0f;
        //다음번 배치 까지의 시간 간격을 초기화
        timebet = 0f;

    }
     
    // Update is called once per frame
    void Update()
    {
        //순서를 돌아가며 주기적 발판을 배치  

        //게임 오버 상태에서는 동작하지 않음

        if (GameManager.Instanse.isGameOver) return;

        //마지막 배치 시점에서 Timebet 이상 시간이 흘렀다면

        if (Time.time >= lastspaTime + timebet) {

            //기록된 마짖막 배치 시점을 현재 시점으로 갱신
            lastspaTime = Time.time;

            //다음 배치까지의 시간 간격을 timebetspamin
            //timbetspa max  사이에서 랜덤 가져옿기\
            timebet = Random.Range(timeBetMin, timebetMax);
            //배치할 위치의 높이를 ymin과 ymax 사이에서 랜덤 가져오기

            float ypos = Random.Range(ymin, ymax);


            //사용할 현재 순번의 발판 게임 오브젝트를 비활성화하고
            //바로 죽시 다시 활성화  이 떄 발판의 platform컴포넌트의 \

            //onenable 메서드가 실행됨
            platforms[currentINdex].SetActive(false);
            platforms[currentINdex].SetActive(true);

            //현재 순번의 발판ㄷ을 화면 오르쪽에 재배치
            platforms[currentINdex].transform.position = new Vector2(xpos, ypos);
            //순번 넘기기
            currentINdex++;
            //마지막 순번의 도달했다면

            if (currentINdex >= count) {
                currentINdex = 0;
            }

        }


    }
}
