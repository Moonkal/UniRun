using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치
public class BakcGround_loop : MonoBehaviour
{
    //배경의 가로 길이
    private float width;
    // Start is called before the first frame update
    //  유니티 이벤트 메서드
    private void Awake()
    {
        //Awake() method는 Start 메소드 처럼 초기 1회 자동 실행하는 유니티 이벤트 매소드 입니다.
        //하지만 start메소드보다 실행 시점이 한프레임 더 빠릅니다.
        //참조하세요
        //unity Method LifeCycle
        // 가로 길이를 측정
        // 
        //BoxCollider2D 컴포넌트으 size필드의 x값을 가로 길이로 사용
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
    }
    // Update is called once per frame
    void Update()
    {

        //현재위치가  원점에서 왼쪽으로 width 이상 이동할 시 
        //위치를 재배치 함
        if (transform.position.x <= -width) {
            RePosition();
        }
        
    }
    void RePosition() {
        //위치를 재배치하는 메서드
        //현재 위치에서 오른쪽으로 가로길이 *2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position  = (Vector2)transform.position + offset;
        //width 20.48*2=40.48
        //-20.48+40.48=20.48
    }
}
