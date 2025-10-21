using UnityEngine;
using TMPro;



namespace MyDefence
{
    /// <summary>
    /// 게임의 전체를 관리하는 클래스
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크 변수
        private bool isGameOver = false;

        //
        public GameObject GameOverUI;

        //치트 체크 변수
        [SerializeField]
        private bool isCheating = false;
        #endregion

        #region Unity Event Method       
        private void Update()
        {
            if (isGameOver)
                return;

            //게임 종료 체크
            if(PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //치트키
            if(Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }

            // O키로 강제 게임오버 치트
            if (Input.GetKeyDown(KeyCode.O))
            {
                ShowMeGameOverUI();
            }

        }
        #endregion

        #region Custom Method     

        //게임오버 처리
        private void GameOver()
        {
            //Debug.Log("Game Over");
            isGameOver = true;

            //효과: vfx, sfx
            //패널티 적용

            //UI 창 열기
            GameOverUI.SetActive(true);
        }

        //치트키
        void ShowMeTheMoney()
        {
            //치크 체크
            if (isCheating == false)
                return;

            //10만 골드 지급
            PlayerStats.AddMoney(100000);
        }

        void ShowMeGameOverUI()
        {
            // 치트 허용 여부 확인
            if (isCheating == false)
                return;

            // 이미 게임오버 상태라면 다시 실행하지 않음
            if (isGameOver)
                return;

            // 게임오버 처리 실행
            isGameOver = true;

            if (GameOverUI != null)
            {
                GameOverUI.SetActive(true);
                Time.timeScale = 0f; // 게임 일시정지
                Debug.Log("치트 발동: 강제 게임오버 UI 표시!");
            }
            else
            {
                Debug.LogWarning("GameOverUI가 연결되지 않았습니다!");
            }
        }


        void LevelupCheat()
        {
            //치크 체크
            if (isCheating == false)
                return;

            //level++;
        }

        //...
        #endregion
    }
}