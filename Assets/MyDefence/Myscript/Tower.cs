using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 타겟 Enemy - 가장 가까운 적
        private GameObject target;

        //회전
        public Transform partToRotate;      //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f;     //회전 속도 

        //공격 범위
        public float attackRange = 7f;

        //찾기타이머
        public float searchTimer = 0.2f;
        private float countdown = 0f;

        // ★추가★: 범위 안 타겟 감지용
        private bool isTargetInRange = false;      

        #endregion

        #region Unity Event Metthod

        private void Start()
        {
            //초기화
            countdown = searchTimer;            
        }

        // ★추가★: 웨이브 시작 감지용 플래그
        private bool waveStarted = false;

        private void Update()
        {
            //0.2초마다 (가장 가까운 적 찾기)
            if(countdown <= 0f)
            {
                // 타이머 기능
                UpdateTarget();

                // ★추가★: 타겟이 공격 범위 안에 있는지 체크
                if (target != null)
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    isTargetInRange = distance <= attackRange; // 범위 안이면 true
                }
                else
                {
                    isTargetInRange = false;
                }

                // 타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            // ★추가★: 범위 안 타겟이 있을 때만 회전
            if (target != null && isTargetInRange)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Quaternion lerpRotation = Quaternion.Slerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed);
                partToRotate.rotation = Quaternion.Euler(0f, lerpRotation.eulerAngles.y, 0f);
            }
           
            /*
            // 타겟 없으면 중단
            if (target == null) return; 

            // 타겟 방향
            Vector3 dir = target.transform.position - transform.position;

            // 타겟 방향 회전값
            Quaternion lookRotation = Quaternion.LookRotation(dir);

            // 부드럽게 회전 (현재 회전 → 목표 회전)
            Quaternion lerpRotation = Quaternion.Slerp(partToRotate.rotation,lookRotation,Time.deltaTime * rotateSpeed);
            Vector3 eulerValue = lerpRotation.eulerAngles;

            // y축만 회전 적용
            partToRotate.rotation = Quaternion.Euler(0f, lerpRotation.eulerAngles.y, 0f);
            */
        }
        // 씬(Scene) 뷰에서 개체가 선택되었을 때 호출되는 메서드
        // 타워의 공격 범위를 시각적으로 확인하기 위해 빨간색 원을 그린다
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;                          // 기즈모 색상 = 빨간색
            Gizmos.DrawWireSphere(this.transform.position,     // 타워의 현재 위치를 중심으로
                                             attackRange);     // 반지름 = 공격 범위
        }
        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        void UpdateTarget()
        { 
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 초기화
            float minDistance = float.MaxValue;

            //최소 거리에 있는 게임 오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                //enemy들과의 거리 구하기
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }



            //가장 가까운 적을 찾았다, 이때 최소거리는 공격 범위보다 작어야 한다
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target=null;
            }
        }
        #endregion

    }



}
