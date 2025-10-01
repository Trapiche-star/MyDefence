using UnityEngine;

namespace MyDefence
{
    public class Bullet : MonoBehaviour
    {
        #region Variables
        
        private Transform target;              //타겟 오브젝트
        public float moveSpeed = 20f;          //총알 이동 속도
        public GameObject BulletImpact;     // ★ 타격 이펙트 프리팹                                          
        #endregion

        #region Unity Event Method
        private void Update()
        {
            if (target == null)
            {
                //Destroy(gameObject); // 목표 없으면 삭제
                return;
            }

            //타겟까지 이동하기 
            Vector3 dir = target.position - transform.position;

            //남은 거리
            float distance = Vector3.Distance(target.position, transform.position);

            //이번 프레임에 이동한 거리
            float distanceThisFrame = Time.deltaTime * moveSpeed;
            if(dir.magnitude <= distanceThisFrame)
            {
                HitTarget();                
                return;
            }

            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);
        }

        #endregion

        #region custom Mathod
        //매개변수로 들어온 타겟으로 저장
        public void SetTarget(Transform _target)
        {
            target = _target;
        }

        //타겟 명중
        void HitTarget()
        {
            // ★ 타격 이펙트 생성 (타겟이 없어도 생성)
            if (BulletImpact != null)
            {
                GameObject effectGo = Instantiate(BulletImpact, transform.position, Quaternion.identity);
                Destroy(effectGo, 2f); // 2초 뒤 삭제
            }

            //타겟 킬
            if (target != null)
            Destroy(target.gameObject);        

            //탄환 킬
            Destroy(this.gameObject);
        }
        #endregion



        

    }
}