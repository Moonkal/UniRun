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


public class Platformspa : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
