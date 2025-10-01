using UnityEngine;

namespace Sample
{
    public class TargetTest : MonoBehaviour
    {
        #region Variables
        public int a = 10;
        private int b = 20;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //필드 초기화
            b = 30;
        }
        #endregion

        public int GetB()
        {
            return b;
        }


        #region
        public int c { get; set; } = 50; // ★ 추가: 자동 프로퍼티, 기본값 50

        #endregion

    }

}
