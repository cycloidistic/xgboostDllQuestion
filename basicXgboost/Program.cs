using System;
using System.IO;
using System.Runtime.InteropServices;

namespace basicXgboost
{
  class Program
  {
    [DllImport("../../libs/libxgboost.dll", CharSet = CharSet.Auto)]
    public static extern int XGDMatrixCreateFromFile([MarshalAs(UnmanagedType.LPStr)] string file, int silent, IntPtr outputPtr);

    [DllImport("../../libs/libxgboost.dll", CharSet = CharSet.Auto)]
    public static extern int XGDMatrixNumCol(IntPtr dmatrixPtr, IntPtr dmatrixColumnsPtr);

    static void Main(string[] args)
    {
      IntPtr dmatrixPtr = Marshal.AllocHGlobal(1000000);
      IntPtr dmatrixColumnsPtr = Marshal.AllocHGlobal(10);

      int result = XGDMatrixCreateFromFile("../../libs/test.txt", 0, dmatrixPtr);
      int cols = XGDMatrixNumCol(dmatrixPtr, dmatrixColumnsPtr);

      Marshal.FreeHGlobal(dmatrixPtr);
      Marshal.FreeHGlobal(dmatrixColumnsPtr);
    }
  }
}
