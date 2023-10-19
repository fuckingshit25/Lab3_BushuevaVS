using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб3
{
    public class DBcontroller
    {
        static TriangleDBEntities triangleDBEntities = new TriangleDBEntities();
        public static List<Triangle> triangles = triangleDBEntities.Triangle.ToList();//Получение данных
        public static void AddDataToDB(string A, string B, string C)//Добавление данных
        {
            
            TriangleCalculator triangleCalculator = new TriangleCalculator();
            var calculationResult = triangleCalculator.CalculateTriangle(A, B, C);
            Triangle triangle = new Triangle();
            triangle.Type_Triangle = triangleCalculator.triangleType;
            triangle.Length_A = Convert.ToDouble(A);
            triangle.Length_B = Convert.ToDouble(B);
            triangle.Length_C = Convert.ToDouble(C);
            // Проверяем, есть ли данные в БД
            Triangle ExistingTriangle = triangles.FirstOrDefault(t => t.Length_A == Convert.ToDouble(A) && t.Length_B == Convert.ToDouble(B) && t.Length_C == Convert.ToDouble(C));
            if (triangle != null)
            {
                triangle.Type_Triangle = ExistingTriangle.Type_Triangle;
            }
            else
            {
                triangle.Type_Triangle = triangleCalculator.triangleType;
                if (calculationResult.Item1 == "Ошибка")
                {
                    triangle.Error = "Ошибка при вычислении треугольника";
                }
                else
                {
                    triangle.Error = "";
                }
            }
            triangleDBEntities.Triangle.Add(triangle);
            triangleDBEntities.SaveChanges();
            triangles = triangleDBEntities.Triangle.ToList();
        }
        public static void RemoveDataToDB(int ID)//Удаление данных
        {
            Triangle triangle = triangles.Where(b => b.ID == ID).FirstOrDefault();
            triangleDBEntities.Triangle.Remove(triangle);
            triangleDBEntities.SaveChanges();
            triangles = triangleDBEntities.Triangle.ToList();
        }
    }
}
