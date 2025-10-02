using UnityEngine;


namespace Sample
{
    public class Singleton
    {
        //클래스의 인스턴스(객체)를 정적 변수 선언        
        private static Singleton instance;

        /*//publice한 속성으로 instance에 전역적 접근하기
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }*/

        //public한 메서드로 instance에 전역적 접근하기
        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        //필드 : 인스턴스이름.number
        public int number;
    }

}

/*디자인 패턴
Singleton.Insance. a= 10;
Debug.Log(Singleton.Insance.a.ToString()); 
*/