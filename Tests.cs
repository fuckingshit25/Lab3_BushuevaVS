using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб3
{
    class Tests
    {
        [Test]
        public void AddDataToDB_Successful()
        {
            // Создание заглушки для объекта TriangleDBEntities
            var triangleDBEntitiesMock = Substitute.For<TriangleDBEntities>();

            // Установка ожидаемых параметров
            string A = "3";
            string B = "4";
            string C = "5";

            // Выполнение метода AddDataToDB
            DBcontroller.AddDataToDB(A, B, C);

            // Проверка вызовов методов TriangleDBEntities
            triangleDBEntitiesMock.Received(1).Triangle.Add(Arg.Any<Triangle>());
            triangleDBEntitiesMock.Received(1).SaveChanges();

            // Проверка обновления списка треугольников
            Assert.AreEqual(1, DBcontroller.triangles.Count);
            Assert.AreEqual(A, DBcontroller.triangles[0].Length_A.ToString());
            Assert.AreEqual(B, DBcontroller.triangles[0].Length_B.ToString());
            Assert.AreEqual(C, DBcontroller.triangles[0].Length_C.ToString());
        }
        [Test]
        public void AddDataToDB_ErrorCalculatingTriangle()
        {
            // Создание заглушки для объекта TriangleDBEntities
            var triangleDBEntitiesMock = Substitute.For<TriangleDBEntities>();

            // Установка ожидаемых параметров
            string A = "1";
            string B = "2";
            string C = "3";

            // Выполнение метода AddDataToDB
            DBcontroller.AddDataToDB(A, B, C);

            // Проверка вызовов методов TriangleDBEntities
            triangleDBEntitiesMock.Received(1).Triangle.Add(Arg.Any<Triangle>());
            triangleDBEntitiesMock.Received(1).SaveChanges();

            // Проверка обновления списка треугольников
            Assert.AreEqual(1, DBcontroller.triangles.Count);
            Assert.AreEqual(A, DBcontroller.triangles[0].Length_A.ToString());
            Assert.AreEqual(B, DBcontroller.triangles[0].Length_B.ToString());
            Assert.AreEqual(C, DBcontroller.triangles[0].Length_C.ToString());
            Assert.AreEqual("Ошибка при вычислении треугольника", DBcontroller.triangles[0].Error);
        }
        [Test]
        public void RemoveDataToDB_Successful()
        {
            // Создание заглушки для объекта TriangleDBEntities
            var triangleDBEntitiesMock = Substitute.For<TriangleDBEntities>();

            // Установка данных
            Triangle triangle = new Triangle
            {
                ID = 1,
                Length_A = 3,
                Length_B = 4,
                Length_C = 5
            };
            DBcontroller.triangles.Add(triangle);

            // Выполнение метода RemoveDataToDB
            DBcontroller.RemoveDataToDB(triangle.ID);
            // Проверка вызовов методов TriangleDBEntities
            triangleDBEntitiesMock.Received(1).Triangle.Remove(Arg.Is(triangle));
            triangleDBEntitiesMock.Received(1).SaveChanges();
            // Проверка обновления списка треугольников
            Assert.AreEqual(0, DBcontroller.triangles.Count);
        }
        [Test]
        public void MainWindow_DisplayData()
        {
            // Создание экземпляра MainWindow
            MainWindow mainWindow = new MainWindow();
            // Проверка отображения данных в TrianglesGrid
            Assert.AreEqual(DBcontroller.triangles, mainWindow.TrianglesGrid.ItemsSource);
        }
        [Test]
        public void MainWindow_AddTriangle()
        {
            // Создание экземпляра MainWindow
            MainWindow mainWindow = new MainWindow();
            var triangleDBEntitiesMock = Substitute.For<TriangleDBEntities>();
            // Установка данных
            string A = "3";
            string B = "4";
            string C = "5";

            // Установка значений для текстовых полей в главном окне
            mainWindow.A.Text = A;
            mainWindow.B.Text = B;
            mainWindow.C.Text = C;

            // Выполнение метода Add через главное окно
            mainWindow.Add(null, null);
            // Проверка вызовов методов TriangleDBEntities
            triangleDBEntitiesMock.Received(1).Triangle.Add(Arg.Any<Triangle>());
            triangleDBEntitiesMock.Received(1).SaveChanges();
            // Проверка обновления списка треугольников
            Assert.AreEqual(1, DBcontroller.triangles.Count);
            Assert.AreEqual(A, DBcontroller.triangles[0].Length_A.ToString());
            Assert.AreEqual(B, DBcontroller.triangles[0].Length_B.ToString());
            Assert.AreEqual(C, DBcontroller.triangles[0].Length_C.ToString());
        }
    }
}
