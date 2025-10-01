using UnityEngine;

namespace Sample
{
    #region Circle Structure
    // 원 정보를 담는 구조체
    public struct cCircle
    {
        public float x; // 중심 X 좌표
        public float y; // 중심 Y 좌표
        public float r; // 반지름

        public cCircle(float xPos, float yPos, float radius)
        {
            x = xPos;
            y = yPos;
            r = radius;
        }
    }
    #endregion

    /// <summary>
    /// 두 원 충돌 체크
    /// </summary>
    public class HitTest : MonoBehaviour
    {
        #region 기존 체크 메서드
        private bool CheckHitCircle(cCircle a, cCircle b)
        {
            float xDistance = a.x - b.x;
            float yDistance = a.y - b.y;

            float distance = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);

            if (distance <= (a.r + b.r))
                return true;

            return false;
        }

        // 기존 도착 체크
        private bool CheckArrivePosition(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);
            if (distance < 0.5f)
                return true;

            return false;
        }
        #endregion

        #region ★ 추가 변수
        public float moveSpeed = 5f;               // ★ 추가: 이동 속도
        public Transform targetTransform;          // ★ 추가: 이동할 대상
        #endregion

        #region ★ 추가 메서드
        // 이동하면서 도착 체크
        private void Update()
        {
            if (targetTransform != null)
            {
                MoveTowardsTarget(targetTransform);

                if (CheckArrivePositionFrame(targetTransform))
                {
                    Debug.Log("목적지 도착!");
                    targetTransform = null;
                }
            }
        }

        // 한 프레임 이동 거리 기준 도착 체크
        private bool CheckArrivePositionFrame(Transform target)
        {
            float distance = Vector3.Distance(this.transform.position, target.position);
            float distanceThisFrame = Time.deltaTime * moveSpeed;

            if (distance <= distanceThisFrame)
                return true;

            return false;
        }

        // 목적지로 이동
        private void MoveTowardsTarget(Transform target)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
        #endregion
    }
}
