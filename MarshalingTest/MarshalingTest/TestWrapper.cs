using System;
using System.Runtime.InteropServices;

namespace MarshalingTest
{
  class TestWrapper
  {
    [DllImport("ctest", CallingConvention = CallingConvention.Cdecl)]
    private static extern void Test(ref Obj obj, [In] double[] inArray, [Out] double[] outArray);

    public static void CallTest()
    {
      Obj obj = new Obj {A = 5, B = 10.5, InSize = 5, OutSize = 7};

      double[] inArray = { 1, 2, 3, 4, 5 };
      double[] outArray = new double[7];

      Test(ref obj, inArray, outArray);

      foreach(double outValue in outArray)
        Console.WriteLine("out_array[{0:d}]: {1:f}", Array.IndexOf(outArray, outValue), outValue);
    }

    private struct Obj
    {
      public int InSize;
      public int OutSize;
      public int A;
      public double B;
    }
  }
}
