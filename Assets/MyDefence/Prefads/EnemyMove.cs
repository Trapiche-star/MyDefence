/*
using MyDefence;
using UnityEngine;

/*namespace MyDefence
{
    public class EnemyMove : MonoBehaviour
    {
        //이동 목표 위치를 가지고 있는 오브젝트
        private Transform target;  // Cube (종점)

        //이동 속도
        public float speed = 4f;

        void Start ()
        {
            target = WayPoints.points[0];
        }


        void Update()
        {
            // Cube 쪽으로 이동 (오직 타겟용)
            //transform.position = Vector3.MoveTowards
            //(transform.position, target.position, speed * Time.deltaTime);            

            // 도착 판정
            *//*if (Vector3.Distance(transform.position, target.position) < 0.01f)
            {
                Debug.Log("종점 도착!!!"); // 콘솔에 출력
                Destroy(gameObject);       // Enemy 오브젝트 삭제
            }
            -중간에 계산값을 저장하지 않음 →            동일한 연산을 두 번 쓰면 효율이 떨어질 수 있음
            (하지만 거리 계산 1회라 큰 문제 없음) *//*


            //타겟을 향해 이동 
            Vector3 dir = target.position - this.transform.position;
            this.transform.Translate(dir.normalized * Time.deltaTime * speed);
            // - (방향 벡터를 활용한 다양한 이동(예: 회전하면서 이동, 다른 힘과 결합, 상대좌표 이동)을 원한다면 유용)

            //도착 판정
            //타겟과 Enmy와 거리를 구해서 일정거리안에 들어오면 도착이라고 판정 한다
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.5f)
            {
                Arrive();
            }
        }

        // <summary>
        /// 적이 목적지에 도착했을 때 실행되는 메서드
        /// </summary>
        private void Arrive()
        {
            Debug.Log("도착했다!");
            Destroy(this.gameObject); // 적 오브젝트 삭제
        }

            *//*float distance = Vector3.Distance(transform.position, target.position);
            if(distance < 0.01f)
            {
                Destroy(this.gameObject);
                Debug.Log("도착했다"); 
                
            }*//*

            //-가독성 좋음 → distance라는 이름만 봐도 의미가 바로 이해됨/같은 거리 값을 여러 번 사용해야 할 때 효율적
            
    }
}
*/

using UnityEngine;

namespace MyDefence
{
    public class EnemyMove : MonoBehaviour
    {
        private Transform target;
        private int waypointIndex = 0;
        public float speed = 4f;        

        void Start()
        {
            if (WayPoints.points.Length > 0)
            {
                target = WayPoints.points[waypointIndex];
            }
        }

        void Update()
        {
            if (target == null) return;

            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance < 0.1f)
            {
                GetNextWaypoint();
            }
        }

        void GetNextWaypoint()
        {
            waypointIndex++;
            if (waypointIndex >= WayPoints.points.Length)
            {
                Arrive();
                return;
            }
            target = WayPoints.points[waypointIndex];
        }

        private void Arrive()
        {
            Debug.Log("적이 종점 도착!");
            Destroy(gameObject);
        }
    }
}