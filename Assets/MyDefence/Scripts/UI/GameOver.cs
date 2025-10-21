using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        #region Variables
        //Rounds 텍스트
        public TextMeshProUGUI roundsText;
        #endregion

        #region Uniyt Event Method

        //게임오버 UI가 활성화 될때 Player.S값을 한번만 가져온다.
        private void OnEnable()
        {
            roundsText.text = PlayerStats.Rounds.ToString() + "ROUNDS SURVIVED";      
        }

        #endregion

        #region Custom Method
        //메인 메뉴 버튼을 눌렀을때 호출
        public void MainMenu()
        {
            Debug.Log("Gto MainMenu!!!");
        }

        //게임 재시작 버튼 눌렀을때 호출
        public void Restart()
        {
            Debug.Log("Run RePaly!!!");

            //현재 플레이하고 있는 씬을 다시 호출        
            //int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            string nowSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nowSceneName);

        }
        #endregion

    }

}
