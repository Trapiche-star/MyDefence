using UnityEngine;
using System.Collections;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        
        #region Variables
        //프리팹 오브젝트
        public GameObject prefab;

        //맵 타입들의 부모 오브젝트 
        //public Transform parents;

        //맵 타일 생성 체크
        bool isCreate = false;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //[1]
            //Instantiate(prefab);
            //위치:(5,0,8) 맵타일 생성하기
            //Instantiate(prefab, 위치(vector-벡터), 방향);

            //-Vector3 position = new Vector3(5f, 0f, 8f);
            //-Instantiate(prefab, position, Quaternion.identity);

            //Instantiate(prefab, new Vector3(5f, 0f, 8f), Quaternion.identity);

            //row(10)행 x10(column) 열 타입맵 찍, 타일간 간격은 1이다
            //GeneratMap(10, 10);
            //GeneratemapTile(10, 10);

            //랜덤 타일찍기
            //GenerateRandomMaoTile();

            //랜덤 타일을 1초 간격으로 10개 찍는데
            //타일 하나 찍고 -> 1초 딜레이-> 타일 하나 찍고 -> 1초 딜레이
            //Debug.Log("[0] 코루틴 시작");
            //StartCoroutine(CreateMapTile());
            //Debug.Log("[4] 타일 생성 완료");
        }      

        private void Update()
        {
            if (isCreate == false)
            {//랜덤 타일을 1초 간격으로 10개 찍는데
             //타일 하나 찍고 -> 1초 딜레이-> 타일 하나 찍고 -> 1초 딜레이
                Debug.Log("[0] 코루틴 시작");
                StartCoroutine(CreateMapTile());

                Debug.Log($"[4] 타일 생성 완료:{ isCreate}");
                isCreate = true;
            }
            Debug.Log($"[99]업테이트 내용 실행");
        }

        #endregion

        #region Custom Method
        void GeneratMap(int row, int column)
        { 
            //10행 x10 열 타입맵 찍, 타일간 간격은 1이다
            for(int i = 0; i < row; i++)
            {
                for(int j= 0; j < column; j++)
                {
                    Vector3 position = new Vector3(i * 5f, 0f,j * -5f);
                    Instantiate(prefab, position, Quaternion.identity,this.transform);
                }                
            }            
            
            
            /*ai
            int rows = 10;   // 행
            int cols = 10;   // 열
            float spacing = 1f; // 간격

            for (int x = 0; x < cols; x++)
            {
                for (int z = 0; z < rows; z++)
                {
                    // (5,0,8) 기준으로 시작해서 격자 배치
                    Instantiate(prefab, new Vector3(5f + x * spacing, 0f, 8f + z * spacing),Quaternion.identity);
                }
            }*/
        }
        //맵 제네레이터를 부모로 지정하며 맵 타일 찍기
        void GeneratemapTile(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //인스턴스시 위치 지정
                    //Vector3 position = new Vector3(i * 5f, 0f, j * -5f);
                    //Instantiate(prefab, position, Quaternion.identity);

                    //인스턴스 후 위치 지정 - 생성된 게임오브젝트(Transform)가저오기
                    GameObject go = Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0f, j * -5f);

                }
            }
        }

        //row(10)행 x10(column) 열 중에 랜덤한 위치에 타일 하나 찍기
        void GenerateRandomMaoTile()
        {

            //int row = Random.Range(0, 10);
            //int column = Random.Range(0, 10);

            // 0 1 2 3..... => r:0, c:0~9
            // 10 11 12 13 ..=> r:1, c:0~9
            // 20 21 22 23 ...=> r:2, c:0~9
            int randNumber = Random.Range(0, 100);
            int row = randNumber / 10;
            int column = randNumber % 10;

            Vector3 position = new Vector3(row * 5f, 0f, column * -5f);
            Instantiate(prefab, position, Quaternion.identity);
        }

        IEnumerator CreateMapTile()
        {
           /* GenerateRandomMaoTile();
            Debug.Log("[1] 첫번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMaoTile();
            Debug.Log("[2] 두번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMaoTile();
            Debug.Log("[3] 세번째 타일 생성");
            yield return new WaitForSeconds(1.0f);*/

            for (int i = 1; i <= 3; i++)
            {
                GenerateRandomMaoTile();
                Debug.Log($"{i+1}번째 타일 생성");
                yield return new WaitForSeconds(1.0f);
            }

        }
        #endregion
    }
}


/*
코루틴  함수 : 지연 함수

- 하나 이상의 yield return  문이 꼭 있서야 한다
- yield return 문에서 지연 시간 지정한다
- 시간(초)지연 : yield return new WaitForSeconds(.1f); <- (지연시간(초));

형식
IEnumerator 함수이름()
{
    //...
    yield return ...// 하나이상의 yield return  문이 꼭 있서야 한다
}

코루틴 함수 호출
StartCoroutine(코루틴함수이름):


Quaternion(쿼터니언)
identity(아이던티티)  
*/