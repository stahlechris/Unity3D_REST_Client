namespace Microsoft.Azure.Kinect.Sensor.BodyTracking
{
    [System.Serializable]
    public enum JointId
    {
        Pelvis = 0, SpineNaval, SpineChest, Neck,
        ClavicleLeft, ShoulderLeft, ElbowLeft, WristLeft,
        ClavicleRight, ShoulderRight, ElbowRight, WristRight,
        HipLeft, KneeLeft, AnkleLeft, FootLeft,
        HipRight, KneeRight, AnkleRight, FootRight,
        Head, Nose, EyeLeft, EarLeft,
        EyeRight, EarRight, Count
    }
}
