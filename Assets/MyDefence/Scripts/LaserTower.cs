using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 레이저를 쏘는 타워를 관리하는 클래스, Tower 상속받는다
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        //레이저 빔
        private LineRenderer lineRenderer;
        #endregion


        #region Unity Event Method     
        protected override void Start()
        {
            // ✅ 부모의 Start() 호출 (한 번만)
            base.Start();

            //LineRenderer 컴포넌트 가져오기
            lineRenderer = this.transform.GetComponent<LineRenderer>();
        }
        // ✅ 매 프레임마다 실행 (수정)
        protected override void Update()
        {
            //부모의 Update() 호출 (탐색 + 회전 등 기본 동작)
            base.Update();

            //타겟이 없으면 레이저 끄기
            if (target == null)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
                return;
            }

            //레이저 쏘기
            ShootLaser();
        }        
        #endregion

        #region Custom Method
        //레이져 빔 쏘기 
        private void ShootLaser()
        {
            //라인 랜더를 그린다
            if(lineRenderer.enabled == false)
            {
                lineRenderer.enabled = true;
            }              

            //라인 렌더러의 시작, 끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.transform.position);
        }
        #endregion
    }

}
