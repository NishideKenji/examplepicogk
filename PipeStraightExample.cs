using PicoGK;
using System.Numerics;

public static class PipeStraightExample
{
    public static void Task()
    {
        // ===== パラメータ（全部 mm） =====
        float length = 60f;     // 直管の長さ
        float rInner = 8f;      // 流路半径（内径/2）
        float wall   = 2f;      // 肉厚
        float rOuter = rInner + wall;

        // ===== 1) 流路（中身）を Lattice で作る =====
        Lattice lat = new();
        lat.AddBeam(Vector3.Zero, new Vector3(length, 0, 0), rInner, rInner);

        Voxels voxInside = new(lat);

        // ===== 2) 外側は「内側をオフセットして作る」 =====
        Voxels voxOutside = voxInside.voxOffset(wall);

        // ===== 3) 肉厚＝外側 - 内側 =====
        Voxels voxPipe = (voxOutside - voxInside);

        // ===== 4) 端面の丸キャップを切る（BBoxでIntersect） =====
        // 少しだけ余裕を見てカット用の箱を作る
        float cutMargin = 0.5f;
        BBox3 box = new(
            new Vector3(0, -(rOuter + cutMargin), -(rOuter + cutMargin)),
            new Vector3(length,  (rOuter + cutMargin),  (rOuter + cutMargin))
        );

        voxPipe = voxPipe & new Voxels(Utils.mshCreateCube(box));

        // ===== 表示 =====
        Library.oViewer().Add(voxPipe, 1);
    }
}
