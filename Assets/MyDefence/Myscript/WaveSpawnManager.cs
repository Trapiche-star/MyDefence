
using UnityEngine;
using System.Collections;
using TMPro;

/*놓침1
namespace MyDefence
{
    public class WaveSpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private float spawnTimer = 5f;
        private float countdown = 0f;

        private void Update()
        {
            countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                EnemySpawn();
                countdown = 0f;
            }
        }

        void EnemySpawn()
        {
            // WayPoints 첫 번째 위치에서 생성
            Transform startPoint = WayPoints.points[0];
            Instantiate(enemyPrefab, startPoint.position, startPoint.rotation);
        }

        private void Start()
        {
            EnemySpawn(); // 시작 시 1개 생성
        }
    }
}*/

/* 놓처서 ai 쓰는데 뭔가 꼬인듯?
namespace MyDefence
{
    /// <summary>
    /// 적 스폰 및 웨이브를 관리하는 클래스 
    /// </summary>
    public class WaveSpawnManager : MonoBehaviour
    {
        //#region #endregion
        #region Variables
        //적 프리펩 오브젝트 - 원본
        public GameObject enemyPrefab;

        //public Transflorm start; == this.transflorm

        //스폰 타이머
        private float spawnTimer = 5f;      //타이머 기준 시간
        private float countdown = 0f;       //시간 누적 변수

        //웨이브 카운트
        private int waveCount = 0;

        #endregion

        #region Uinty Event 
        private void Update()
        {
            countdown += Time.deltaTime;
            if(countdown >= spawnTimer)
            {
                // 타이머 기능 실행 
                EnemySpawn();

                // 타이머 초기화
                countdown = 0f;
            }
        }

        #endregion

        #region Custom Method
        //시작점 위치에 enemy 1개 생성
        void SpawnWave()
        {
            waveCount++;
            for(int i = 0; i < waveCount++; i++)
            {
                EnemySpawn();
            }
        }   

         #region Custom Method
         //시작점 위치에 enemy 1개 생성
         void EnemySpawn()
         {
             Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
         }

         #endregion

         #region 
         private void Start()
         {
             //시작점 위치에 enemy 1개 생성
             Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
         }
         #endregion

    }


}*/

namespace MyDefence
{
    /// <summary>
    /// 적 스폰 및 웨이브를 관리하는 클래스
    /// </summary>
    public class WaveSpawnManager : MonoBehaviour
    {
        #region Variables
        public GameObject enemyPrefab;                  // 적 프리팹
        public float spawnInterval = 0.5f;              // 웨이브 내 적 생성 간격
        public float waveInterval = 5f;                 // 웨이브 간 간격

        private int waveCount = 0;                      // 웨이브 카운트
        public int maxWaves = 5;                        // 최대 웨이브 수 (추가)
        public TextMeshProUGUI countdownText;           // UI - Text

        public Tower[] towers;                          // 씬의 모든 타워를 연결
        public float preWaveCountdown = 5f;             // ★추가★ 웨이브 시작 전 카운트다운
        #endregion

        #region Unity Event
        private void Start()
        {
            // 코루틴 시작
            StartCoroutine(SpawnWaves());
        }
        #endregion

        #region Custom Methods
        private IEnumerator SpawnWaves()
        {
            while (waveCount < maxWaves) // 최대 웨이브까지만 반복
            {
                waveCount++; // 웨이브 증가
                Debug.Log($"웨이브 {waveCount} 시작!");

                // ★추가★: 웨이브 시작 전 5→1 카운트다운
                float countdown = preWaveCountdown;
                while (countdown > 0f)
                {
                    if (countdownText != null)
                        countdownText.text = Mathf.Ceil(countdown).ToString();
                    countdown -= Time.deltaTime;
                    yield return null;
                }
                if (countdownText != null)
                    countdownText.text = "0";

                for (int i = 0; i < waveCount; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(spawnInterval); // 적 생성 간격
                }

                yield return new WaitForSeconds(waveInterval); // 다음 웨이브까지 대기
            }

            Debug.Log("모든 웨이브 종료!");
            OnAllWavesFinished();
        }

        public float spawnTimer = 5f;       // 스폰 주기 (초)  
        private float countdown = 0f;       // 경과 시간        

        private void SpawnEnemy()
        {
            Vector3 spawnPos = transform.position;

            // WayPoints 배열이 있으면 첫 번째 포인트에서 생성
            if (WayPoints.points != null && WayPoints.points.Length > 0)
            {
                spawnPos = WayPoints.points[0].position;
            }

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }

        private void OnAllWavesFinished()
        {
            // 모든 웨이브 끝났을 때 처리
            Debug.Log("게임 클리어! 다음 로직 실행");
            // 예: UI 띄우기, 씬 전환 등
            // SceneManager.LoadScene("ClearScene");
        }
        #endregion
    }
}
