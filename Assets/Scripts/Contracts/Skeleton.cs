using System.Runtime.InteropServices;

namespace Microsoft.Azure.Kinect.Sensor.BodyTracking
{
    public struct Skeleton
    {
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = (int)JointId.Count)]
        public Joint[] Joints;
    }

    //[StructLayout(LayoutKind.Sequential)]

    public struct Joint
    {
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Position;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Orientation;
    }
}
