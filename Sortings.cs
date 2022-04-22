namespace Sortings;

public class SortingMethods
{
    // N * N/2 = O(N^2)
    public int[] BubbleSort(int[] input)
    {
        for (int k = 0; k < input.Length; k++)
            for (int i = 0; i < input.Length - 1 - k; i++)
                if (input[i] > input[i + 1])
                    (input[i], input[i + 1]) = (input[i + 1], input[i]);

        return input;
    }

    // O(N^2)
    public int[] InsertSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            var key = arr[i];
            var j = i - 1;
            while (j > -1 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }

        return arr;
    }

    //O(N+K) 
    // K is knowing
    internal int[] CountSort(int[] arr, int K)
    {
        var counts = new int[K];

        // Calculate counts;
        for (int i = 0; i < arr.Length; i++)
            ++counts[arr[i]];

        // Set positions
        for (int i = 1; i < counts.Length; i++)
            counts[i] += counts[i - 1];

        var output = new int[arr.Length];

        // for (int i = counts.Length - 1; i > 0; i--)
        //     counts[i] = counts[i-1];  

        // counts[0] = 0;

        // for (int i = 0; i < arr.Length - 1; i++)
        // {
        //     output[counts[arr[i]]] = arr[i];
        //     ++counts[arr[i]];
        // }

        // Reverse for stability
        for (int i = arr.Length - 1; i > -1; i--)
        {
            output[counts[arr[i]] - 1] = arr[i];
            --counts[arr[i]];
        }

        return output;
    }

    private Random random = new Random();
    private int N = 0;
    internal void QuickSort(Span<int> arr)
    {
        // System.Console.Write(++N);
        if (arr.Length < 2) return;

        var pivot = arr[random.Next(0, arr.Length)];
        var i = 0;
        var j = arr.Length - 1;

        while (true)
        {
            while (arr[i] < pivot) i++;
            while (arr[j] > pivot) j--;

            if (i >= j) break;

            (arr[i], arr[j]) = (arr[j], arr[i]);
            i++; j--;
        }

        QuickSort(arr[..i]);
        QuickSort(arr[i..]);
    }

    //#region MergeSort
    internal void MergedSortStartArray(int[] expected)
    {
        MergeSortArray(expected, 0, expected.Length - 1);
    }
    private void MergeSortArray(Span<int> arr, int l, int r)
    {
        if (l < r)
        {
            var p = (l + r) / 2;

            // Find the left part
            MergeSortArray(arr, l, p);
            // Take right par
            MergeSortArray(arr, p + 1, r);
            // Merge left and right
            MergeArr(arr, l, p, r);
        }
    }
    private void MergeArr(Span<int> arr, int l, int m, int r)
    {
        var l1 = m - l + 1;
        var l2 = r - m;
        var temp1 = new int[l1];
        var temp2 = new int[l2];

        for (int q = 0; q < temp1.Length; q++)
            temp1[q] = arr[l + q];

        for (int q = 0; q < temp2.Length; q++)
            temp2[q] = arr[m + 1 + q];

        int i = 0;
        int j = 0;
        int k = l;
        while (i < l1 && j < l2)
        {
            if (temp1[i] <= temp2[j])
            {
                arr[k] = temp1[i];
                i++;
            }
            else
            {
                arr[k] = temp2[j];
                j++;
            }

            k++;
        }

        while (i < l1)
        {
            arr[k] = temp1[i];
            k++; i++;
        }

        while (j < l2)
        {
            arr[k] = temp2[j];
            k++; j++;
        }
    }
    //#endregion MergeSort

    internal void HeapSort(Span<int> arr)
    {
        var len = arr.Length;
        for (int i = len / 2 - 1; i >= 0; i--)
            Heapify(arr, len, i);

        for (int i = len - 1; i > 0; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            // 0 - Cause we're using recursive in the 
            Heapify(arr, i, 0);
        }
    }

    private void Heapify(Span<int> span, int size, int idx)
    {
        var left = idx * 2 + 1;
        var right = idx * 2 + 2;
        var largest = idx;

        if (left < size && span[largest] < span[left])
            largest = left;

        //here we need use largest cause it can be change
        if (right < size && span[largest] < span[right])
            largest = right;

        if (largest != idx)
        {
            (span[idx], span[largest]) = (span[largest], span[idx]);
            Heapify(span, size, largest);
        }
    }
}