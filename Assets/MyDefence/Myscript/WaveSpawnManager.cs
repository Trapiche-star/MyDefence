
using UnityEngine;
using System.Collections;

/*namespace MyDefence
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

/*namespace MyDefence
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
        public GameObject enemyPrefab;      // 적 프리팹
        public float spawnInterval = 0.5f;  // 웨이브 내 적 생성 간격
        public float waveInterval = 5f;     // 웨이브 간 간격

        private int waveCount = 0;          // 웨이브 카운트
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
            while (true)
            {
                waveCount++; // 웨이브 증가
                Debug.Log($"웨이브 {waveCount} 시작!");

                for (int i = 0; i < waveCount; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(spawnInterval); // 적 생성 간격
                }

                yield return new WaitForSeconds(waveInterval); // 다음 웨이브까지 대기
            }
        }

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
        #endregion
    }
}