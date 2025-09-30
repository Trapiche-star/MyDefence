using Unity.VisualScripting;
using UnityEngine;

namespace MyDefence
{
    public class RotateTest01 : MonoBehaviour
    {
        #region Variables
        //축 회전 누적 값dmf wjwkdgksms qustn
        float x = 0f;

        //회전 속도
        public float rotateSpeed = 10f;

        //이동 속도 
        public float moveSpeed = 0f;
 
        //타겟
        public Transform target;
        #endregion

        #region Unity Event Method
        void Start ()
        {
            //회전값 설정
            /*회전값 연습
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);    
            this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            */
        }        
        
        private void Update()
        {
            /* 구현 예제들
            //x축, y축, z축으로 회전 구현
            //x += 1;
            /*회전 구현 연습
            //this.transform.rotation = Quaternion.Euler(x, 0, 0);      //x축
            //this.transform.rotation = Quaternion.Euler(0, x, 0);      //y축
            //this.transform.rotation = Quaternion.Euler(0, 0, x);      //z축
            

            //Rotate (자전)
            //this.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            //[1-2]RotateAround (타겟 기준으로 공전)
            //this.transform.RotateAround(target.position, Vector3.up, Time.deltaTime * 20f);
            */

            //타겟을 향해 회전
            //타겟을 향한 방향을 구한다 : 타겟 - 현재위치
            Vector3 dir = target.position - this.transform.position;

            //타겟 방향에 대한 회전값 구하기
            Quaternion lookRotation = Quaternion.LookRotation(dir);          
            Quaternion lerpRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);

            //회전값(x,y,z,w)에서 euler값(x,y,z) 얻어오기
            Vector3 eulerValue = lerpRotation.eulerAngles;

            //euler값(x,y,z)에서 회전값(x,y,z,w) 얻어오기 -y축 값만 연산 적용
            this.transform.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);

            //this.transform.rotation = lerpRotation;

            //this.transform.rotation = lookRotation; 회전할때 공간이동 하듯이 뿅하고 회전
            //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
            


        }

        #endregion

    }
}
