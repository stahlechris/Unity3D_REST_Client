using System.Runtime.InteropServices;
using System;
using System.Numerics;

namespace Microsoft.Azure.Kinect.Sensor.BodyTracking
{
    [StructLayout(LayoutKind.Sequential)]
    [System.Serializable]
    public struct Skeleton
    {
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = (int)JointId.Count)]
        public Joint[] Joints;

        //default values: pass the JointId.Count to construct Joint[] for Skeleton
        public Skeleton(int numJoints)
        {
            //declare & init Joints[] with JointId.Count size
            Joints = new Joint[numJoints];
            //make a new Random
            Random rand = new Random();
            //make new float[]s representing position and orientation of a Joint
            float[] pos, rot;
            //pos has 3 floats to make a Vector3 pos[0],-pos[1],pos[2]
            pos = new float[3];
            //rot has 4 floats to make a Quaternion rot[1],rot[2],rot[3],rot[0]
            rot = new float[4];
            //Fill Joints[] with numJoints many Joint
            for (int i = 0; i < numJoints; i++)
            {
                //fill dummy float[]pos,rot for position and orientation of joints
                for (int j = 0; j < pos.Length; j++)
                {
                    pos[j] = (float)rand.NextDouble();
                }
                for (int k = 0; k < rot.Length; k++)
                {
                    rot[k] = (float)rand.NextDouble();
                }
                //make a new Joint by passing dummy float[] pos,rot to Joint constructor
                Joints[i] = new Joint(pos, rot);
            }
        }
    }

    

    [StructLayout(LayoutKind.Sequential)]
    [System.Serializable]
    public struct Joint
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Position;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Orientation;

        public Joint(float[] position, float[] orientation)
        {
            Position = position;
            Orientation = orientation;
        }
    }
}
