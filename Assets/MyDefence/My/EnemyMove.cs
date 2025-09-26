using UnityEngine;

namespace My
{
    public class EnemyMove : MonoBehaviour
    {
        public Transform target;  // Cube (종점)
        public float speed = 10f;

        void Update()
        {
            // Cube 쪽으로 이동 (오직 타겟용)
            //transform.position = Vector3.MoveTowards
            //(transform.position, target.position, speed * Time.deltaTime);            

            // 도착 판정
            /*if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                Debug.Log("종점 도착!!!"); // 콘솔에 출력
                Destroy(gameObject);       // Enemy 오브젝트 삭제
            }
            -중간에 계산값을 저장하지 않음 →            동일한 연산을 두 번 쓰면 효율이 떨어질 수 있음
            (하지만 거리 계산 1회라 큰 문제 없음) */


            //타겟을 향해 이동 
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);
            // - (방향 벡터를 활용한 다양한 이동(예: 회전하면서 이동, 다른 힘과 결합, 상대좌표 이동)을 원한다면 유용)

            //도착 판정
            float distance = Vector3.Distance(transform.position, target.position);
            if(distance < 0.01f)
            {
                Destroy(this.gameObject);
                Debug.Log("도착했다"); 
                
            }      
            
            //-가독성 좋음 → distance라는 이름만 봐도 의미가 바로 이해됨/같은 거리 값을 여러 번 사용해야 할 때 효율적





        }


       




    }
}

