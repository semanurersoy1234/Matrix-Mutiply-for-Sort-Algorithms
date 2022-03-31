/**
* @file ce100-hw2-algo-lib-cs
* @author Sema Nur Ersoy
* @date 31 March 2022
*
* @brief <b> HW-2 Functions </b>
*
* HW-2 Sample Lib Functions
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw2_algo_lib_cs
{
    public class Class1
    {
        /**
         * 
         * @name MatrixMultiplicationRec
         * @param [in] row1 [\b int] 
         * @param [in] column1 [\b int] 
         * @param [in] A [\b int[,]]
         * @param [in] row2 [\b int]
         * @param [in] column2 [\b int]
         * @param [in] B [\b int[,]]
         * @param [in] C [\b int[,]]
         * Given two matrices A and B. The task is to multiply matrix A and matrix B recursively.
         * The inner most Recursive call of multiplyMatrix() is to iterate k (col1 or row2).
         * he second recursive call of multiplyMatrix() is to change the columns and the outermost recursive call is to change rows.
         * In Recursive Matrix Multiplication, we implement three loops of Iteration through recursive calls. 
         **/
        public static int a = 0, b = 0, c = 0;
        public static void MatrixMultiplicationRec(int row1, int column1, int[,] A, int row2, int column2, int[,] B, int[,] C)
        {
          
            if (a >= row1)
            {
                return;
            }

           
            if (b < column2)
            {
                if (c < column1)
                {
                    C[a, b] += A[a, c] * B[c, b];
                    c++;

                    MatrixMultiplicationRec(row1, column1, A, row2, column2, B, C);
                }

                c = 0;
                b++;
                MatrixMultiplicationRec(row1, column1, A, row2, column2, B, C);
            }

            b = 0;
            a++;
            MatrixMultiplicationRec(row1, column1, A, row2, column2, B, C);

        }
        /**
        * 
        * @name MatrixMultiplicationıterative
        * @param [in] a [\b int[,]]
        * @param [in] row [\b int]
        * @param [in] col [\b int]
        * @param [in] b [\b int[,]]
        * Applications of matrix multiplication in computational problems are found in many fields including scientific computing
        * Many different algorithms have been designed for multiplying matrices on different types of hardware
        * Matrix multiplication is such a central operation in many numerical algorithms, much work has been invested in making matrix multiplication algorithms efficient
        **/
        public static int[,] Matrixmultiplicationıterative(int[,] a, int[,] b, int row, int col)
        {
            int[,] result = new int[row, col];
          
            for (int i = 0; i < row; i++)
            {
               
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < row; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
         
            return result;
        }

        /**
        * 
        * @name calc
        * @param [in] n [\b int] 
        * The calc function allows us to perform mathematical operations on property values.
        **/
        public static void calc(int n)
        {
            Random rng = new Random();
            float[,] m1 = new float[n, n];
            float[,] m2 = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m1[i, j] = (float)rng.NextDouble();
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m2[i, j] = (float)rng.NextDouble();
                }
            }

            float[,] m3 = MatrixMultiplicationstrassen(m1, m2, n);
        }
        /**
        * 
        * @name MatrixMultiplicationstrassen
        * @param [in] a [\b float[,]] 
        * @param [in] b [\b float[,]] 
        * @param [in] n [\b int]
        * The Strassen algorithm replaces multiplies with additions.
        **/
        public static float[,] MatrixMultiplicationstrassen(float[,] a, float[,] b, int n)
        {
            if (n == 2)
            {
                var m1 = (a[0, 0] + a[1, 1]) * (b[0, 0] + b[1, 1]);
                var m2 = (a[1, 0] + a[1, 1]) * b[0, 0];
                var m3 = a[0, 0] * (b[0, 1] - b[1, 1]);
                var m4 = a[1, 1] * (b[1, 0] - b[0, 0]);
                var m5 = (a[0, 0] + a[0, 1]) * b[1, 1];
                var m6 = (a[1, 0] - a[0, 0]) * (b[0, 0] + b[0, 1]);
                var m7 = (a[0, 1] - a[1, 1]) * (b[1, 0] + b[1, 1]);
                a[0, 0] = m1 + m4 - m5 + m7;
                a[0, 1] = m3 + m5;
                a[1, 0] = m2 + m4;
                a[1, 1] = m1 - m2 + m3 + m6;
                return a;
            }
            else
            {
                float[,] a11 = matrixDivide(a, n, 11);
                float[,] a12 = matrixDivide(a, n, 12);
                float[,] a21 = matrixDivide(a, n, 21);
                float[,] a22 = matrixDivide(a, n, 22);

                float[,] b11 = matrixDivide(b, n, 11);
                float[,] b12 = matrixDivide(b, n, 12);
                float[,] b21 = matrixDivide(b, n, 21);
                float[,] b22 = matrixDivide(b, n, 22);

                float[,] p1 = MatrixMultiplicationstrassen(a11, matrixDiff(b12, b22, n / 2), n / 2);
                float[,] p2 = MatrixMultiplicationstrassen(matrixSum(a11, a12, n / 2), b22, n / 2);
                float[,] p3 = MatrixMultiplicationstrassen(matrixSum(a21, a22, n / 2), b11, n / 2);
                float[,] p4 = MatrixMultiplicationstrassen(a22, matrixDiff(b21, b11, n / 2), n / 2);
                float[,] p5 = MatrixMultiplicationstrassen(matrixSum(a11, a22, n / 2), matrixSum(b11, b22, n / 2), n / 2);
                float[,] p6 = MatrixMultiplicationstrassen(matrixDiff(a12, a22, n / 2), matrixSum(b21, b22, n / 2), n / 2);
                float[,] p7 = MatrixMultiplicationstrassen(matrixDiff(a11, a21, n / 2), matrixSum(b11, b12, n / 2), n / 2);

                float[,] c11 = matrixDiff(matrixSum(p5, p4, n / 2), matrixDiff(p2, p6, n / 2), n / 2);
                float[,] c12 = matrixSum(p1, p2, n / 2);
                float[,] c21 = matrixSum(p3, p4, n / 2);
                float[,] c22 = matrixDiff(matrixSum(p1, p5, n / 2), matrixSum(p3, p7, n / 2), n / 2);

                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        a[i, j] = c11[i, j];
                        a[i, j + n / 2] = c12[i, j];
                        a[i + n / 2, j] = c21[i, j];
                        a[i + n / 2, j + n / 2] = c22[i, j];
                    }
                }
                return a;
            }
        }
        /**
        * 
        * @name matrixSum
        * @param [in] a [\b float[,]] 
        * @param [in] b [\b float[,]] 
        * @param [in] n [\b int]
        * By multiplying this with the specified Matrix value, the Matrix provides the front side of the specified value.
        **/
        public static float[,] matrixSum(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return c;
        }
        /**
        * 
        * @name matrixDiff
        * @param [in] a [\b float[,]] 
        * @param [in] b [\b float[,]] 
        * @param [in] n [\b int]
        * It is a difference equation in which it relates to its value at one or more previous points.
        **/

        public static float[,] matrixDiff(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] - b[i, j];
            return c;
        }
        /**
        * 
        * @name matrixCombine
        * @param [in] a11 [\b float[,]] 
        * @param [in] a12 [\b float[,]] 
        * @param [in] a21 [\b float[,]]
        * @param [in] a22 [\b float[,]]
        * @param [in] n [\b int]
        * You can also use square brackets to join existing matrices together.
        * This way of creating a matrix is called concatenation.
        **/
        public static float[,] matrixCombine(float[,] a11, float[,] a12, float[,] a21, float[,] a22, int n)
        {
            float[,] a = new float[n, n];
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    a[i, j] = a11[i, j];
                    a[i, j + n / 2] = a12[i, j];
                    a[i + n / 2, j] = a21[i, j];
                    a[i + n / 2, j + n / 2] = a22[i, j];
                }
            }
            return a;
        }
        /**
        * 
        * @name matrixDivide
        * @param [in] a [\b float[,]]
        * @param [in] n [\b int]
        * @param [in] region [\b int]
        * Dividing a matrix by another matrix is an undefined function.
        * The closest equivalent is multiplying by the inverse of another matrix.
        **/
        public static float[,] matrixDivide(float[,] a, int n, int region)
        {
            float[,] c = new float[n / 2, n / 2];
            if (region == 11)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 12)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 21)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 22)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            return c;
        }

        /**
               * 
               * @name LomutoPartition
               * @param [in] arr [\b int[]] 
               * @param [in] low [\b int] 
               * @param [in] high [\b int]
               * Lomuto’s partition scheme is easy to implement as compared to Hoare scheme.
               * This has inferior performance to Hoare’s QuickSort.
               **/
        public static int LomutoPartition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
               
                if (arr[j] <= pivot)
                {
                    i++; 
                    int temp1 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp1;
                }
            }
            int temp = arr[i+1];
            arr[i+1] = arr[high];
            arr[high] = temp;
            return (i + 1);
        }

        /**
        * 
        * @name LomutoQuickSort
        * @param [in] arr [\b int []] 
        * @param [in] low [\b int] 
        * @param [in] high [\b int]
        * Lomuto’s partition scheme is easy to implement as compared to Hoare scheme.
        * This has inferior performance to Hoare’s QuickSort.
        * This algorithm works by assuming the pivot element as the last element.
        * If any other element is given as a pivot element then swap it first with the last element.
        **/
        public static void LomutoQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
              
                int pi = LomutoPartition(arr, low, high);

                
                LomutoQuickSort(arr, low, pi - 1);
                LomutoQuickSort(arr, pi + 1, high);
            }
        }
        /**
        * 
        * @name Hoarepartition
        * @param [in] arr [\b int[]] 
        * @param [in] lw [\b int] 
        * @param [in] high [\b int]
        * Hoare’s Partition works by initializing two indexes that start at two ends.
        * The two indexes move toward each other until an inversion is found.
        * When an inversion is found, two values are swapped and the process is repeated.
        **/
        public static int Hoarepartition(int[] arr, int lw, int high)
        {
            int pivot = arr[lw];
            int i = lw - 1, j = high + 1;

            while (true)
            {
                
                do
                {
                    i++;
                } while (arr[i] < pivot);

                
                do
                {
                    j--;
                } while (arr[j] > pivot);

                
                if (i >= j)
                    return j;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                
            }
        }
        /**
        * 
        * @name HoareQuickSort
        * @param [in] arr [\b int[]] 
        * @param [in] low [\b int] 
        * @param [in] high [\b int]
        * This algorithm works by assuming the pivot element as the last element.
        * If any other element is given as a pivot element then swap it first with the last element.
        * After coming out from the loop swap arr[i] with arr[hi]. This i stores the pivot element.
        **/


        public static void HoareQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                
                int pi = Hoarepartition(arr, low, high);

               
                HoareQuickSort(arr, low, pi);
                HoareQuickSort(arr, pi + 1, high);
            }
        }
        /**
        * 
        * @name randomlomutopartition
        * @param [in] arr [\b int[]] 
        * @param [in] low [\b int] 
        * @param [in] high [\b int]
        * Quicksort is a divide-and-conquer algorithm. 
        * Lomuto’s partition scheme is easy to implement as compared to Hoare scheme. 
        * This has inferior performance to Hoare’s QuickSort.
        * When implemented well, it can be somewhat faster than merge sort and about two or three times faster than heapsort.
        **/

        public static int randomlomutopartition(int[] arr, int low, int high)
        {


            int pivot = arr[high];

            int i = (low - 1); 
            for (int j = low; j < high; j++)
            {

                
                if (arr[j] < pivot)
                {
                    i++;

                    int tempp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempp;
                }
            }

            int tempp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tempp2;

            return i + 1;
        }

        /**
         * 
         * @name random
         * @param [in] arr [\b int[]] 
         * @param [in] low [\b int] 
         * @param [in] high [\b int]
         * In this article, we will discuss how to implement QuickSort using random pivoting.
         * In QuickSort we first partition the array in place such that all elements to the left of the pivot element are smaller.
         * The Lomuto partition scheme can be used for various purposes including sorting the array.
         **/
        public static int random(int[] arr, int low, int high)
        {

            Random rand = new Random();
            int pivot = rand.Next(low) % (high - low) + low;

            int tempp1 = arr[pivot];
            arr[pivot] = arr[high];
            arr[high] = tempp1;

            return randomlomutopartition(arr, low, high);
        }
        /**
        * 
        * @name randomQuicksortLomuto
        * @param [in] arr [\b int[]] 
        * @param [in] low [\b int] 
        * @param [in] high [\b int]
        * Lomuto’s partition scheme is easy to implement as compared to Hoare scheme.
        * This has inferior performance to Hoare’s QuickSort. 
        **/
        public static void randomQuicksortLomuto(int[] arr, int low, int high)
        {
            if (low < high)
            {
                
                int pi = randomlomutopartition(arr, low, high);

                
                randomQuicksortLomuto(arr, low, pi - 1);
                randomQuicksortLomuto(arr, pi + 1, high);
            }
        }
        /**
        * 
        * @name randomhoarepartition
        * @param [in] arr [\b int[]] 
        * @param [in] low [\b int] 
        * @param [in] high [\b int]
        * Unlike merge sort we don’t need to merge the two sorted arrays.
        * Using a randomly generated pivot we can further improve the time complexity of QuickSort. 
        **/
        public static int randomhoarepartition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {

                do
                {
                    i++;
                } while (arr[i] < pivot);

                
                do
                {
                    j--;
                } while (arr[j] > pivot);

                
                if (i >= j)
                    return j;

                int tempp = arr[i];
                arr[i] = arr[j];
                arr[j] = tempp;
            }
        }
        /**
        * 
        * @name Random
        * @param [in] arr [\b int[]] 
        * @param [in] low [\b int] 
        * @param [in] high [\b int]
        * Hoare partition is an algorithm that is used to partition an array about a pivot.
        * All elements smaller than the pivot are on it's left (in any order) and all elements greater than the pivot are on it's right.
        **/
        public static int Random(int[] arr, int low, int high)
        {
           
            Random rand = new Random();
            int pivot = rand.Next() % (high - low) + low;

            int tempp1 = arr[pivot];
            arr[pivot] = arr[high];
            arr[high] = tempp1;

            return randomhoarepartition(arr, low, high);
        }
        /**
        * 
        * @name randomQuicksortHoare
        * @param [in] array [\b int[]] 
        * @param [in] lw [\b int] 
        * @param [in] high [\b int]
        * Randomized quick sort chooses a random element as a pivot. 
        * It is done so as to avoid the worst case of quick sort in which the input array is already sorted.
        **/
        public static void randomQuicksortHoare(int[] array, int lw, int high)
        {
            if (lw < high)
            {
              
                int pi = Random(array, lw, high);

            
                randomQuicksortHoare(array, lw, pi);
                randomQuicksortHoare(array, pi + 1, high);
            }
        }

        /**
        * @name SelectionProblem 
        * @param [in] array [\b int[]]
        * @param [in] a [\b int]
        * @param [in] b [\b int]
        * @param [in] c [\b int]
        * @retval [\b int]
        **/
        public static int SelectionProblem(int[] array, int a, int b, int c)
        {
            // If k is smaller than number
            // of elements in array
            if (c > 0 && c <= b - a + 1)
            {
                // Partition the array around a
                // random element and get position
                // of pivot element in sorted array
                int pos = randompartition(array, a, b);

                // If position is same as k
                if (pos - a == c - 1)
                    return array[pos];

                // If position is more, recur
                // for left subarray
                if (pos - a > c - 1)
                    return SelectionProblem(array, a, pos - 1, c);

                // Else recur for right subarray
                return SelectionProblem(array, pos + 1, b, c - pos + a - 1);
            }
            // If k is more than number of
            // elements in array
            return int.MaxValue;
        }

        /**
        * @name partition 
        * @param [in] arr [\b int[]]
        * @param [in] l [\b int]
        * @param [in] r [\b int]
        * @retval [\b int]
        **/
        public static int partition(int[] arr, int l, int r)
        {
            int x = arr[r], i = l;
            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                }
            }
            int temp2 = arr[i];
            arr[i] = arr[r];
            arr[r] = temp2;
            return i;
        }

        /**
        * @name randompartition 
        * @param [in] arr [\b int[]]
        * @param [in] l [\b int]
        * @param [in] r [\b int]
        * @retval [\b int]
        **/
        public static int randompartition(int[] arr, int l, int r)
        {
            int n = r - l + 1;
            Random rnd = new Random();
            int rand = rnd.Next(0, 1);
            int pivot = (int)(rand * (n - 1));
            int temp = arr[l + pivot];
            arr[l + pivot] = arr[r];
            arr[r] = temp;
            return partition(arr, l, r);
        }

        /**
        * 
        * @name HeapSort
        * @param [in] array [\b int[]] 
        * It is one of the sorting algorithms developed to keep the data in order in memory.
        * Stacking sort creates a heap tree in the background and sorts by taking the number at the top of that tree. 
        **/
        public static void HeapSort(int[] array)
        {
            int n = array.Length;


            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(array, n, i);


            for (int i = n - 1; i > 0; i--)
            {

                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;


                heapify(array, i, 0);
            }
        }

        /**
         * 
         * @name heapify
         * @param [in] arr [\b int[]] 
         * @param [in] n [\b int] 
         * @param [in] i [\b int]
         * All C# objects spawn in the Heap region.
         **/
        public static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;


            if (l < n && arr[l] > arr[largest])
                largest = l;


            if (r < n && arr[r] > arr[largest])
                largest = r;


            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;


                heapify(arr, n, largest);
            }
        }

        /**
        * @name Parent 
        * @param [in] s [\b int]
        * @retval [\b int]
        **/
        public static int[] H = new int[50];
        public static int size = -1;
        public static int Parent(int s)
        {
            return (s - 1) / 2;
        }

        /**
        * @name LeftChild 
        * @param [in] r [\b int]
        * @retval [\b int]
        **/
        public static int LeftChild(int r)
        {
            return ((2 * r) + 1);
        }

        /**
        * @name RightChild 
        * @param [in] b [\b int]
        * @retval [\b int]
        **/
        public static int RightChild(int b)
        {
            return ((2 * b) + 2);
        }

        /**
        * @name ShiftUp 
        * @param [in] x [\b int]
        **/
        public static void ShiftUp(int x)
        {
            while (x > 0 &&
                   H[Parent(x)] < H[x])
            {

                // Swap parent and current node
                int temp = H[Parent(x)];
                H[Parent(x)] = H[x];
                H[x] = temp;

                // Update i to parent of i
                x = Parent(x);
            }
        }

        /**
        * @name ShiftDown 
        * @param [in] i [\b int]
        **/
        public static void ShiftDown(int i)
        {
            int maxIndex = i;

            // Left Child
            int l = LeftChild(i);

            if (l <= size &&
                H[l] > H[maxIndex])
            {
                maxIndex = l;
            }

            // Right Child
            int r = RightChild(i);

            if (r <= size &&
                H[r] > H[maxIndex])
            {
                maxIndex = r;
            }

            // If i not same as maxIndex
            if (i != maxIndex)
            {
                int temp = H[i];
                H[i] = H[maxIndex];
                H[maxIndex] = temp;
                ShiftDown(maxIndex);
            }
        }

        /**
        * @name InsertValue 
        * @param [in] t [\b int]
        **/
        public static void InsertValue(int t)
        {
            size = size + 1;
            H[size] = t;

            // Shift Up to maintain heap property 
            ShiftUp(size);
        }

        /**
        * @name ExtractMaxPriority 
        * @retval [\b int]
        **/
        public static int ExtractMaxPriority()
        {
            int result = H[0];
            H[0] = H[size];
            size = size - 1;
            // Shift down the replaced element to maintain the heap property
            ShiftDown(0);
            return result;
        }

        /**
        * @name ChangePriorityQueue 
        * @param [in] x [\b int]
        * @param [in] y [\b int]
        **/
        public static void ChangePriorityQueue(int x, int y)
        {
            int oldp = H[x];
            H[x] = y;

            if (y > oldp)
            {
                ShiftUp(x);
            }
            else
            {
                ShiftDown(x);
            }
        }

        /**
        * @name GetMax 
        * @retval [\b int]
        **/
        public static int GetMax()
        {
            return H[0];
        }

        /**
        * @name Remove 
        * @param [in] e [\b int]
        **/
        public static void Remove(int e)
        {
            H[e] = GetMax() + 1;

            // Shift the node to the root
            // of the heap
            ShiftUp(e);

            // Extract the node
            ExtractMaxPriority();
        }


        /**
        * 
        * @name CountingSort
        * @param [in] array [\b int[]] 
        * The frequency array is then iterated over to use distinct elements and their occurrences and.
        * Counting sort is based on the idea that the number of occurrences of distinct elements is counted. 
        **/
        public static void CountingSort(int[] array)
        {
            int max = array.Max();
            int min = array.Min();
            int range = max - min + 1;
            int[] count = new int[range];
            int[] output = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }
            for (int i = 1; i < count.Length; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[array[i] - min] - 1] = array[i];
                count[array[i] - min]--;
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = output[i];
            }
        }

        /**
        * 
        * @name RadixSort
        * @param [in] arr [\b int[]] 
        * @param [in] n [\b int] 
        * Radix Sort is one of the linear sorting algorithms that sorts numbers by operating on their digits.
        * It is essentially a fast algorithm that sorts numbers written in base 2.
        **/
        public static void RadixSort(int[] arr, int n)
        {
            int m = getMax(arr, n);


            for (int exp = 1; m / exp > 0; exp *= 10)
                CountSort(arr, n, exp);
        }

        /**
        * 
        * @name getMax
        * @param [in] arr [\b int[]] 
        * @param [in] n [\b int] 
        * Returns the larger of two local unsigned integers.
        **/
        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }
        /**
        * 
        * @name CountSort
        * @param [in] arr [\b int[]] 
        * @param [in] n [\b int] 
        * @param [in] exp [\b int]
        * It is one of the sorting algorithms developed to keep the data in order in memory.
        * It simply counts how many of each number in the array to be sorted is in a different array.
        * It then obtains the array sorted by an operation above the array of these numbers.
        **/
        public static void CountSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int i;
            int[] count = new int[10];

            for (i = 0; i < 10; i++)
                count[i] = 0;

            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }       
    }
}


