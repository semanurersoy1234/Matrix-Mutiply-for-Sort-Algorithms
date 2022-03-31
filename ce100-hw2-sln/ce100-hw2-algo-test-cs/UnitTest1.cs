using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce100_hw2_algo_lib_cs;

namespace ce100_hw2_algo_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixMultiplicationRec_Test1()
        {
            int row1 = 2, col1 = 2;
            int row2 = 2, col2 = 2;

            int[,] A = {{6, 2},
                       {5, 8}};

            int[,] B = {{7, 5},
                       {4, 2}};

            int[,] c = new int[row1, col2];

            Class1.a = 0; Class1.b = 0; Class1.c = 0;
            Class1.MatrixMultiplicationRec(row1, col1, A, row2, col2, B, c);
            int[,] expected = {{50, 34},
                              {67, 41}};
            CollectionAssert.AreEqual(c, expected);
        }

        [TestMethod]
        public void MatrixMultiplicationRec_Test2()
        {
            int row1 = 3, col1 = 3;
            int row2 = 3, col2 = 3;

            int[,] A = {{7, 2, 1},
                       {6, 1, 5},
                       {8, 3, 2}};

            int[,] B = {{3, 5, 2},
                       {8, 1, 3},
                       {6, 7, 4}};

            int[,] c = new int[row1, col2];

            Class1.a = 0; Class1.b = 0; Class1.c = 0;
            Class1.MatrixMultiplicationRec(row1, col1, A, row2, col2, B, c);
            int[,] expected = {{43, 44, 24},
                              {56, 66, 35},
                              {60, 57, 33}};
            CollectionAssert.AreEqual(c, expected);
        }

        [TestMethod]
        public void MatrixMultiplicationRec_Test3()
        {
            int row1 = 4, col1 = 4;
            int row2 = 4, col2 = 4;

            int[,] A = {{3, 1, 2, 5},
                       {2, 3 ,6, 1},
                       {4, 2, 5, 4},
                       {3, 2, 1, 5}};

            int[,] B = {{2, 5, 1, 2},
                       {1, 2, 3, 1},
                       {3, 6, 5, 2},
                       {1, 3, 7, 6}};

            int[,] c = new int[row1, col2];

            Class1.a = 0; Class1.b = 0; Class1.c = 0;
            Class1.MatrixMultiplicationRec(row1, col1, A, row2, col2, B, c);
            int[,] expected = {{18, 44, 51, 41},
                              {26, 55, 48, 25},
                              {29, 66, 63, 44},
                              {16, 40, 49, 40}};
            CollectionAssert.AreEqual(c, expected);
        }

        [TestMethod]
        public void MatrixMultiplicationIterative_Test1()
        {

            int[,] a = {{2, 5},
                       {4, 7}};

            int[,] b = {{3, 2},
                       {8, 6}};

            int row = 2, col = 2;

            int[,] result = {{46, 34 },
                             {68, 50 }};
            CollectionAssert.AreEqual(Class1.Matrixmultiplicationıterative(a, b, row, col), result);

        }

        [TestMethod]
        public void MatrixMultiplicationIterative_Test2()
        {

            int[,] a = {{2, 3, 5},
                       {1, 4, 7},
                       {6, 2, 1}};

            int[,] b = {{5, 3, 2},
                       {3, 1, 4},
                       {6, 1, 2}};

            int row = 3, col = 3;

            int[,] result = {{49, 14, 26},
                             {59, 14, 32},
                             {42, 21, 22}};
            CollectionAssert.AreEqual(Class1.Matrixmultiplicationıterative(a, b, row, col), result);
        }

        [TestMethod]
        public void MatrixMultiplicationIterative_Test3()
        {

            int[,] a = {{3,2,1,5},
                       {2,8,4,3},
                       { 1,2,5,4},
                       {6,1,2,3}};

            int[,] b = {{1,3,2,5},
                       {4,2,1,7},
                       {6,5,4,2},
                       {3,4,2,7}};

            int row = 4, col = 4;

            int[,] result = {{32,38,22,66},
                             {67,54,34,95},
                             {51,48,32,57},
                             {31,42,27,62} };
            CollectionAssert.AreEqual(Class1.Matrixmultiplicationıterative(a, b, row, col), result);
        }

        [TestMethod]
        public void MatrixMultiplicationStrassen_Test1()
        {

            float[,] a = {{2, 6},
                       {8, 2}};

            float[,] b = {{4, 3},
                       {5, 6}};

            int n = 2;
            float[,] result = {{38, 42},
                              {42, 36}};

            CollectionAssert.AreEqual(Class1.MatrixMultiplicationstrassen(a, b, n), result);
        }

        [TestMethod]
        public void MatrixMultiplicationStrassen_Test2()
        {

            float[,] a = {{4, 6},
                       {2, 4}};

            float[,] b = {{5, 8},
                       {7, 5}};

            int n = 2;
            float[,] result = {{62, 62},
                              {38, 36}};

            CollectionAssert.AreEqual(Class1.MatrixMultiplicationstrassen(a, b, n), result);
        }

        [TestMethod]
        public void MatrixMultiplicationStrassen_Test3()
        {

            float[,] a = {{5, 6},
                       {2, 5}};

            float[,] b = {{4, 9},
                       {3, 4}};

            int n = 2;
            float[,] result = {{38, 69},
                              {23, 38}};

            CollectionAssert.AreEqual(Class1.MatrixMultiplicationstrassen(a, b, n), result);
        }


        [TestMethod]
        public void QuickSortLomutoPartition_Test1()
        {
            int[] array = { 26, 8, 3, 35, 15, 41 };
            int n = array.Length;
            Class1.LomutoQuickSort(array, 0, n - 1);
            int[] result = { 3, 8, 15, 26, 35, 41 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void QuickSortLomutoPartition_Test2()
        {
            int[] array = { 32, 28, 6, 72, 45, 18 };
            int n = array.Length;
            Class1.LomutoQuickSort(array, 0, n - 1);
            int[] result = { 6, 18, 28, 32, 45, 72 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void QuickSortLomutoPartition_Test3()
        {
            int[] array = { 45, 67, 3, 25, 32, 56 };
            int n = array.Length;
            Class1.LomutoQuickSort(array, 0, n - 1);
            int[] result = { 3, 25, 32, 45, 56, 67 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void QuickSortHoarePartition_Test1()
        {
            int[] array = { 61, 32, 38, 21, 92, 11 };
            int n = array.Length;
            Class1.HoareQuickSort(array, 0, n - 1);
            int[] result = { 11, 21, 32, 38, 61, 92 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void QuickSortHoarePartition_Test2()
        {
            int[] array = { 22, 8, 36, 75, 45, 9 };
            int n = array.Length;
            Class1.HoareQuickSort(array, 0, n - 1);
            int[] result = { 8, 9, 22, 36, 45, 75 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void QuickSortHoarePartition_Test3()
        {
            int[] array = { 13, 7, 26, 98, 42, 34 };
            int n = array.Length;
            Class1.HoareQuickSort(array, 0, n - 1);
            int[] result = { 7, 13, 26, 34, 42, 98 };
            CollectionAssert.AreEqual(array, result);

        }
        [TestMethod]
        public void randomQuickSortHoarePartition_Test1()
        {
            int[] array = { 75, 36, 45, 3, 65, 39 };
            int n = array.Length;
            Class1.randomQuicksortHoare(array, 0, n - 1);
            int[] result = { 3, 36, 39, 45, 65, 75 };
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void randomQuickSortHoarePartition_Test2()
        {
            int[] array = { 78, 64, 5, 32, 85, 14 };
            int n = array.Length;
            Class1.randomQuicksortHoare(array, 0, n - 1);
            int[] result = { 5, 14, 32, 64, 78, 85 };
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void randomQuickSortHoarePartition_Test3()
        {
            int[] array = { 87, 13, 45, 66, 35, 1 };
            int n = array.Length;
            Class1.randomQuicksortHoare(array, 0, n - 1);
            int[] result = { 1, 13, 35, 45, 66, 87 };
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void randomQuickSortLomutoPartition_Test1()
        {
            int[] array = { 43, 6, 25, 30, 62, 35 };
            int n = array.Length;
            Class1.randomQuicksortLomuto(array, 0, n - 1);
            int[] result = { 6, 25, 30, 35, 43, 62 };
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void randomQuickSortLomutoPartition_Test2()
        {
            int[] array = { 13, 25, 34, 5, 72, 42 };
            int n = array.Length;
            Class1.randomQuicksortLomuto(array, 0, n - 1);
            int[] result = { 5, 13, 25, 34, 42, 72 };
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void randomQuickSortLomutoPartition_Test3()
        {
            int[] array = { 62, 48, 9, 14, 36, 18 };
            int n = array.Length;
            Class1.randomQuicksortLomuto(array, 0, n - 1);
            int[] result = { 9, 14, 18, 36, 48, 62 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void SelectionProblem_Test1()
        {
            int[] array = { 8, 23, 5, 7, 9, 12 };
            int n = array.Length;
            int k = 2;
            Assert.AreEqual(Class1.SelectionProblem(array, 0, n - 1, k), 7);
        }

        [TestMethod]
        public void SelectionProblem_Test2()
        {
            int[] array = { 12, 24, 54, 1, 6, 2, 76};
            int n = array.Length;
            int k = 4;
            Assert.AreEqual(Class1.SelectionProblem(array, 0, n - 1, k), 12);
        }

        [TestMethod]
        public void SelectionProblem_Test3()
        {
            int[] array = { 61, 12, 14, 26, 3, 6, 67, 78, 34};
            int n = array.Length;
            int k = 8;
            Assert.AreEqual(Class1.SelectionProblem(array, 0, n - 1, k), 67);
        }

        [TestMethod]
        public void HeapSort_Test1()
        {
            int[] array = { 78, 63, 5, 36, 12, 29 };
            Class1.HeapSort(array);
            int[] result = { 5, 12, 29, 36, 63, 78 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void HeapSort_Test2()
        {
            int[] array = { 63, 74, 2, 96, 36, 7 };
            Class1.HeapSort(array);
            int[] result = { 2, 7, 36, 63, 74, 96 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void HeapSort_Test3()
        {
            int[] array = { 78, 60, 2, 40, 77, 96 };
            Class1.HeapSort(array);
            int[] result = { 2, 40, 60, 77, 78, 96 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void PriorityQueueWithHeap_Parent_Test1()
        {
            /*       45
                  /     \
                 31        14
                / \        / \
               13  20     7   11
                 / \
                12  7
            */

            // Insert the element to the
            // priority queue
            // index zero
            Class1.InsertValue(45);
            // index one 
            Class1.InsertValue(20);
            // index two
            Class1.InsertValue(14);
            Class1.InsertValue(12);
            // index four
            Class1.InsertValue(31);
            Class1.InsertValue(7);
            Class1.InsertValue(11);
            Class1.InsertValue(13);
            Class1.InsertValue(7);
            // Get parent of a node
            Assert.AreEqual(Class1.H[1], Class1.H[Class1.Parent(4)]);
        }

        [TestMethod]
        public void PriorityQueueWithHeap_LeftChild_Test1()
        {
            /*       45
                  /     \
                 31        14
                / \        / \
               13  20     7   11
                 / \
                12  7
            */

            // Insert the element to the
            // priority queue
            // index zero
            Class1.InsertValue(45);
            // index one 
            Class1.InsertValue(20);
            // index two
            Class1.InsertValue(14);
            Class1.InsertValue(12);
            // index four
            Class1.InsertValue(31);
            Class1.InsertValue(7);
            Class1.InsertValue(11);
            Class1.InsertValue(13);
            Class1.InsertValue(7);
            // Get parent of a node
            Assert.AreEqual(Class1.H[11], Class1.H[Class1.LeftChild(5)]);
        }

        [TestMethod]
        public void PriorityQueueWithHeap_RightChild_Test1()
        {
            /*       42
                  /     \
                 35        15
                / \        / \
               16  23     8   13
                 / \
                10  8
            */

            // Insert the element to the
            // priority queue
            // index zero
            Class1.InsertValue(42);
            // index one 
            Class1.InsertValue(35);
            // index two
            Class1.InsertValue(15);
            Class1.InsertValue(16);
            // index four
            Class1.InsertValue(23);
            Class1.InsertValue(8);
            Class1.InsertValue(13);
            Class1.InsertValue(10);
            Class1.InsertValue(8);
            // Get parent of a node
            Assert.AreEqual(Class1.H[2], Class1.H[Class1.RightChild(0)]);
        }

        [TestMethod]
        public void PriorityQueueWithHeap_extractmax_Test1()
        {
            /*       42
                  /     \
                 35        15
                / \        / \
               16  23     8   13
                 / \
                10  8
            */

            // Insert the element to the
            // priority queue
            // index zero
            Class1.InsertValue(42);
            // index one 
            Class1.InsertValue(35);
            // index two
            Class1.InsertValue(15);
            Class1.InsertValue(16);
            // index four
            Class1.InsertValue(23);
            Class1.InsertValue(8);
            Class1.InsertValue(13);
            Class1.InsertValue(10);
            Class1.InsertValue(8);
            Class1.ExtractMaxPriority();
            // Get parent of a node
            Assert.AreEqual(Class1.H[2], Class1.H[0]);
        }

        [TestMethod]
        public void PriorityQueueWithHeap_changepriority_Test1()
        {
            /*       42
                  /     \
                 35        15
                / \        / \
               16  23     8   13
                 / \
                10  8
            */

            // Insert the element to the
            // priority queue
            // index zero
            Class1.InsertValue(42);
            // index one 
            Class1.InsertValue(35);
            // index two
            Class1.InsertValue(15);
            Class1.InsertValue(16);
            // index four
            Class1.InsertValue(23);
            Class1.InsertValue(8);
            Class1.InsertValue(13);
            Class1.InsertValue(10);
            Class1.InsertValue(8);
            Class1.ExtractMaxPriority();
            // Get parent of a node
            int i = 8, p = 10;
            Class1.ChangePriorityQueue(i, p);
            Class1.Remove(15);
            Assert.AreEqual(45, Class1.H[0]);
        }

        [TestMethod]
        public void CountingSort_Test1()
        {
            int[] array = { 47, 60, 32, 6, 36, 22 };
            Class1.CountingSort(array);
            int[] result = { 6, 22, 32, 36, 47, 60 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void CountingSort_Test2()
        {
            int[] array = { 66, 5, 20, 44, 75, 34 };
            Class1.CountingSort(array);
            int[] result = { 5, 20, 34, 44, 66, 75 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void CountingSort_Test3()
        {
            int[] array = { 47, 3, 55, 31, 96, 27 };
            Class1.CountingSort(array);
            int[] result = { 3, 27, 31, 47, 55, 96 };
            CollectionAssert.AreEqual(array, result);
        }


        [TestMethod]
        public void RadixSort_Test1()
        {
            int[] array = { 23, 2, 65, 54, 77, 12 };
            int n = array.Length;
            Class1.RadixSort(array, n);
            int[] result = { 2, 12, 23, 54, 65, 77 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void RadixSort_Test2()
        {
            int[] array = { 32, 22, 47, 38, 7, 69 };
            int n = array.Length;
            Class1.RadixSort(array, n);
            int[] result = { 7, 22, 32, 38, 47, 69 };
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void RadixSort_Test3()
        {
            int[] array = { 3, 25, 31, 78, 37, 49 };
            int n = array.Length;
            Class1.RadixSort(array, n);
            int[] result = { 3, 25, 31, 37, 49, 78 };
            CollectionAssert.AreEqual(array, result);
        }
    }
}