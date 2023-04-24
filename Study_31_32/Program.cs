/*
using System;

public class 합계
{
    public static void Main()
    {
        //[1] Input : n명의 국어 점수로 가정
        int[] score = { 100, 75, 50, 37, 90, 95 };
        int sum = 0;
        //[2] Process : SUM : 주어진 범위에 주어진 조건
        //for (int i = 0; i < score.Length; i++) // 0번째 ~ 4번째
        //{
        //    if (score[i] >= 80)
        //    {
        //        sum += score[i]; // SUM
        //    }
        //}

        Console.WriteLine((new int[] { 100, 75, 50, 37, 90, 95 }).Where(s => s >= 80).Sum());
        //[3] Output
        //Console.WriteLine(
        //    "{0}명의 점수 중 80점 이상의 총점 : {1}"
        //    , score.Length, sum); // 285
    }
}
*/

/*
using System;
using System.Reflection.Emit;

public class 카운트
{
    public static void Main()
    {
        //[1] Input
        int[] data = { 10, 9, 4, 7, 6, 5 };
        int count = 0; // 카운트 저장
        //[2] Process : COUNT
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] % 2 == 0) // 짝수
            {
                count++; // 카운트 1증가
            }
        }
        //[3] Output
        Console.WriteLine(
            "짝수의 건수 : {0}", count); // 3

        Console.WriteLine(Enumerable.Range(1,1000).Where(n=>n%13==0).Count());
        Console.WriteLine(Enumerable.Range(1, 1000).Count(n => n % 13 == 0));
    }
}
*/

/*
// 정렬(SORT) : 순서대로 정렬시키는 알고리즘
// 오름차순(Ascending)정렬 : 1, 2, 3, ABC 순
// 내림차순(Descending)정렬 : 3, 2, 1, 다나가 순
// 종류 : 선택정렬, 버블정렬, 퀵정렬, 삽입, 기수, ...
using System;
using System.Linq;
using System.Threading.Channels;

public class 선택정렬
{
    public static void Main()
    {
        //[1] Input
        int[] data = { 7, 5, 6, 1, 10 };
        //[2] Process : Selection Sort
        int temp = 0; // 데이터 Swap용 임시 변수
        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = i + 1; j < data.Length; j++)
            {
                if (data[i] > data[j])
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }
            ShowArray(data); // 현재 i번째 데이터 출력
        }
        //[3] Output
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write("{0} ", data[i]); // 5 6 7 출력되도록
        }
        Console.WriteLine();

        int[] data2 = { 3, 2, 1, 5, 4 };
        Array.Sort(data2);
        for(int i2 = 0; i2 < data2.Length; i2++)
        {
            Console.WriteLine(data2[i2]);
        }
    }
    private static void ShowArray(int[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write("{0} ", data[i]);
        }
        Console.WriteLine();
    }

    
    

}
*/

/*
using System;

public class 이진검색
{
    public static void Main()
    {
        //[1] Input
        int[] data = { 1, 3, 5, 7, 9 }; //[!] 오름차순 정렬되었다고 가정...
        Console.WriteLine("찾을 데이터 : ");
        int search = Convert.ToInt32(Console.ReadLine());
        bool flag = false; // 찾았으면 true 그렇지않으면 false 
        int index = -1; // 찾은 위치
        int low = 0; int mid = 0; int high = 0; // 이분탐색 관련 변수
        low = 0; high = data.Length - 1;
        //[2] Process
        #region 순차검색
        //for (int i = 0; i < data.Length; i++)
        //{
        //    if (data[i] == search)
        //    {
        //        flag = true;
        //        index = i;
        //    }
        //} 
        #endregion
        while (low <= high)
        {
            mid = (low + high) / 2; // 중간값(검색할 데이터) 
            if (data[mid] == search)
            {
                flag = true; index = mid; break;
            }
            if (data[mid] < search)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        //[3] Output    
        if (flag)
        {
            Console.WriteLine("{0}를 {1}위치에서 찾았습니다.", search, index);
        }
        else
        {
            Console.WriteLine("찾지 못했습니다.");
        }



    }
}
*/

/*
// 병합(MEARGE) : 두개의 배열을 합치기(정렬하면서 합치기???)
// 오름차순으로 나열된 두 그룹의 데이터를 한 그룹의 데이터로 병합한다.
//(1) 데이터 a, b 중에 어느 한 쪽이 끝에 도달할 때까지 다음을 반복
//(2) a(i)와 b(j)를 비교해서 작은쪽을 c(k)에 복사하고 작은 쪽 번호를 +1한다.
//(3) 둘 중에 아직 끝까지 도달하지 않은 데이터를 끝까지 복사한다.
using System;

public class 병합정렬
{
    public static void Main()
    {
        //[1] Input : 원본 데이터가 정렬되어있다고 가정
        int[] first = { 1, 3, 5 }; int[] second = { 2, 4 };
        int[] mearge = new int[first.Length + second.Length]; // MEARGE될 배열
        int i = 0; int j = 0; int k = 0;
        int M = first.Length; int N = second.Length;
        //[2] Process
        while (i < M && j < N)
        {// 모두 끝에 도달할 때까지
            if (first[i] <= second[j])
            {
                mearge[k++] = first[i++];
            }
            else
            {
                mearge[k++] = second[j++];
            }
        }
        while (i < M)
        {// 첫번째 배열이 끝까지 도달할 때까지
            mearge[k++] = first[i++];
        }
        while (j < N)
        {// 두번째 배열이 끝까지 도달할 때까지
            mearge[k++] = second[j++];
        }
        //[3] Output
        for (i = 0; i < mearge.Length; i++)
        {
            Console.WriteLine(mearge[i]); // 1, 2, 3, 4, 5 출력되도록...
        }

        int[] first2 = {1,3,5}; 
        int[] second2 = {2,4};

        int[] merge = (from o in first2 select o).Union(from t in second2 select t).OrderBy(m=>m).ToArray();
        foreach(int i2  in merge)
        {
            Console.WriteLine(i2);
        }
    }
}
*/

/*
using System;
using System.Collections.Generic;
namespace 알고리즘
{
    public class ProductInfo
    {
        public string Name { get; set; }  // 상품명
        public int Quantity { get; set; } // 판매량
        public ProductInfo()
        {
            // Empty
        }
        public ProductInfo(string name, int quantity)
        {
            this.Name = name; this.Quantity = quantity;
        }
    }
    public class 그룹
    {
        public static void Main()
        {
            //[1] Input
            List<ProductInfo> lst = new List<ProductInfo>(); // 입력데이터
            List<ProductInfo> result = new List<ProductInfo>(); // 출력데이터
            #region 콘솔로부터 데이터입력
            //ProductInfo pi; string[] temp; string btn = "n";
            //do
            //{
            //    Console.Write("데이터 입력 : ");
            //    temp = Console.ReadLine().Trim().Split(' ');
            //    pi = new ProductInfo();
            //    pi.Name = temp[0].Trim().ToUpper();
            //    pi.Quantity = Convert.ToInt32(temp[1]);
            //    lst.Add(pi); // 컬렉션에 추가
            //    Console.Write("입력(y), 종료(n) : ");
            //    btn = Console.ReadLine().ToLower(); // 소문자로 y, n
            //} while (btn == "y"); 
            #endregion
            #region 기본값으로 초기화
            lst.Add(new ProductInfo("RADIO", 3));
            lst.Add(new ProductInfo("TV", 1));
            lst.Add(new ProductInfo("RADIO", 2));
            lst.Add(new ProductInfo("DVD", 4));
            #endregion
            //[2] Process
            //[A] 원본
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine("{0} {1}", lst[i].Name, lst[i].Quantity);
            }
            //[B] 정렬
            ProductInfo imsi = new ProductInfo();
            for (int i = 0; i < lst.Count - 1; i++)
            {
                for (int j = i + 1; j < lst.Count; j++)
                {
                    if (String.Compare(lst[i].Name, lst[j].Name) > 0)
                    {
                        imsi = lst[i]; lst[i] = lst[j]; lst[j] = imsi;
                    }
                }
            }
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine("{0} {1}", lst[i].Name, lst[i].Quantity);
            }
            //[C] 그룹
            #region 마지막레코드를 입력 후 계산
            //int subTotal = 0; // 소계
            //ProductInfo final = new ProductInfo();
            //final.Name = ""; final.Quantity = 0; 
            //lst.Add(final); // 마지막 레코드용 빈값
            //for (int i = 0; i < lst.Count - 1; i++) // 마지막 레코드(빈) 전까지 
            //{
            //    subTotal += lst[i].Quantity;
            //    if (String.Compare(lst[i].Name, lst[i + 1].Name) != 0) // 다르다면
            //    {
            //        if (lst[i].Name.Trim() != "") // 마지막 데이터가 아닐때까지
            //        {
            //            ProductInfo rlt = new ProductInfo();
            //            rlt.Name = lst[i].Name;
            //            rlt.Quantity = subTotal; // 현재까지 소계
            //            result.Add(rlt); // 한개 그룹 저장
            //            subTotal = 0; 
            //        }
            //    }
            //} 
            #endregion
            int subTotal = 0; // 소계
            for (int i = 0; i < lst.Count; i++)
            {
                subTotal += lst[i].Quantity;
                if ((i + 1) == lst.Count || // 단락(short circuiting) 
                    String.Compare(lst[i].Name, lst[i + 1].Name) != 0)
                {
                    ProductInfo rlt = new ProductInfo();
                    rlt.Name = lst[i].Name;
                    rlt.Quantity = subTotal; // 현재까지 소계
                    result.Add(rlt); // 한개 그룹 저장
                    subTotal = 0;
                }
            }
            //[3] Output
            Console.WriteLine("그룹화된 자료 출력");
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine("{0} {1}", result[i].Name, result[i].Quantity);
            }
        }
    }
}
// 원본 데이터가 아래와 같이 들어온다면??? 
// 이 데이터를 상품명으로 그룹화하자
// RADIO  5           DVD    5
// TV     6    -->    PHONE  5
// PHONE  3           RADIO  7
// RADIO  2           TV    16
// PHONE  2    
// TV    10       
// DVD    5

*/

//using System;

//class ClassDemo
//{
//    static void Main()
//    {
//        ClassOne.Hi();
//        ClassTwo.Hi();

//        ClassTwo ct = new ClassTwo();
//        ct.Hello();
//    }
//}

/*
using System;

class My { }

class Your
{
    public override string ToString()
    {
        return "새로운 반환 문자열 지정";
    }
}

class ToStringMethod
{
    static void Main()
    {
        My my = new My();
        Console.WriteLine(my);

        Your your = new Your();
        Console.WriteLine(your);
    }
}
*/

using System;
using System.Runtime.InteropServices;

public class CategoryClass
{
    public void Print(int i)
    {
        Console.WriteLine($"카테고리 : {i}");

    }
}

class ClassArray
{
    static void Main()
    {
        CategoryClass[] categories = new CategoryClass[3];

        for( int i = 0; i < categories.Length; i++ )
        {
            categories[i] = new CategoryClass();
        }

        for ( int i = 0;i < categories.Length;i++ )
        {
            categories[i].Print(i);
        }
    }
}
