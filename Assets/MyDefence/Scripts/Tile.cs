using UnityEngine;

namespace MuDefence
{
    public class Tile : MonoBehaviour
    {
        #region Variables

        //랜더러 컴포넌트 인스턴스 변수 선언
        private Renderer renderer;

        // 원래 색 저장용
        private Color startColor;  //또는 originalColor;;

        // 마우스 올렸을 때 색
        // public Color hoverColor = Color.yellow; Ai`
        public Color hoverColor;

        //마우스 올렸을때 색 메터리얼
        public Material hoverMaterial;

        //타일의 원래 메터리얼
        private Material startMaterial;

        //타워 건설
        public GameObject towerPrefad;

        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;
        #endregion

        #region Unity Event Method

        private void Start()
        {
             // Renderer 가져오기
             /*renderer = GetComponent<Renderer>();
             if (renderer != null)
             {
                startColor = renderer.material.color;
             }*/         
            renderer = this.transform.GetComponent<Renderer>();
            //startColor = renderer.material.color;
            startMaterial = renderer.material;

        }

        // 클릭 이벤트
        private void OnMouseDown()
        {          
            //만약 타일에 타워오브젝트가 있으면 설치하지 못한다
            if (tower != null)
            {
                Debug.Log("타워를 설치하지 못합니다");
                return;
            }

            //마우스가 좌클릭하여 타일 선택 - 여기에 타워 건설
            tower = Instantiate(BuildManager.Instance.GetTurretToBuild(), this.transform.position, Quaternion.identity);

        }


        // 마우스가 타일 위에 들어왔을 때
        private void OnMouseEnter()
        {
            /*if (renderer != null)
            {
                renderer.material.color = hoverColor;
            }*/           
            //renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }        

        // 마우스가 타일 위에서 나갔을 때
        private void OnMouseExit()
        {
            /*if (renderer != null)
            {
               renderer.material.color = startColor;
            }*/
            //renderer.material.color = startColor; 
            renderer.material = startMaterial;

        }       

        #endregion
    }


}
