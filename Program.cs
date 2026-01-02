using System.Numerics;
using PicoGK;

namespace HelloPicoGK
{
    class Program
    {
        static void Main()
        {
            try
            {
                // 0.5mm voxel（粗いほど速い）
                Library.Go(0.5f, Task);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Task()
        {
            // 球を作る（公式の「First steps」方式）
            Lattice lat = new();
            lat.AddSphere(new Vector3(50, 50, 50), 40);

            Voxels vox = new(lat);

            // Viewerに表示
            Library.oViewer().Add(vox);
        }
    }
}