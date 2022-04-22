using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Sortings;

// Debug

// var random = new Random();
// var expected = Enumerable.Repeat(1,20).Select(i => random.Next(0, 100)).ToArray();
// foreach (var item in expected)
//     System.Console.Write(item + ", ");   
// System.Console.WriteLine();

// var sorts = new SortingMethods();
// sorts.HeapSort(expected);

// System.Console.WriteLine();
// foreach (var item in expected)
//     System.Console.Write(item + ", ");   

// Benchs

BenchmarkRunner.Run<Benchmarks>();

[MemoryDiagnoser]
public class Benchmarks
{
    private static Random random = new Random();
    private readonly int[] expected = Enumerable.Repeat(1,100000).Select(i => random.Next(0, 99)).ToArray();
    private readonly SortingMethods sortings = new SortingMethods();

    [Benchmark]
    public void RunBubbleSort() => sortings.BubbleSort(expected);

    [Benchmark]
    public void RunInsertedSort() => sortings.InsertSort(expected);

    [Benchmark]
    public void RunCountSort() => sortings.CountSort(expected, 100);

    [Benchmark]
    public void RunQuickSort() => sortings.QuickSort(expected);
    
    [Benchmark]
    public void RunMergeSort() => sortings.MergedSortStartArray(expected);

    [Benchmark]
    public void RunHeapSort() => sortings.QuickSort(expected);

}