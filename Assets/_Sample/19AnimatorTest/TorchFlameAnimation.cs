using System.Threading;
using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 랜덤 애니메이션 플레이 구현
    /// </summary>
    public class TorchFlameAnimation : MonoBehaviour
    {
        #region Variables
        //참조
        private Animator animator;
        //애니메이터 파라미터 변수 값
        private int flame = 0;

        [SerializeField]
        private float animTimer = 1f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //참조
            animator = GetComponent<Animator>();

            //초기화
            flame = 0;
        }

        private void Update()
        {
            //타이머  1번씩 랜덤 애니메이션 
            countdown += Time.deltaTime;
            if(countdown > animTimer)
            {
                //
                flame = Random.Range(1, 4);
                animator.SetInteger("Flame", flame);

                    countdown = 0f;
            }
        }
        #endregion

    }

}

