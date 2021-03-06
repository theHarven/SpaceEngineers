﻿namespace VRageRender
{
    public class MyPostprocessSettings
    {
        public bool EnableTonemapping;
        public bool EnableEyeAdaptation;
        public bool EnableSsao;

        public float Contrast;
        public float Brightness;

        public float ConstantLuminance;
        public float LuminanceExposure;
        public float EyeAdaptationTau;
        public float MiddleGrey;
        public float MiddleGreyAt0;
        public float MiddleGreyCurveSharpness;
        public float BlueShiftRapidness;
        public float BlueShiftScale;

        public float BloomExposure;
        public float BloomMult;

        public float Tonemapping_A;
        public float Tonemapping_B;
        public float Tonemapping_C;
        public float Tonemapping_D;
        public float Tonemapping_E;
        public float Tonemapping_F;
        public float LogLumThreshold;
        public float NightLogLumThreshold;

        public float ForwardPassAmbient;

        public static MyPostprocessSettings DefaultGame()
        {
            return new MyPostprocessSettings
            {
                EnableTonemapping = true,
                EnableSsao = true,
                EnableEyeAdaptation = true,

                ConstantLuminance = 0.025f,
                EyeAdaptationTau = 0.3f,
                LuminanceExposure = 0.51f,
                Contrast = 0.006f,
                Brightness = 0,
                MiddleGrey = 0,
                BloomExposure = 0.5f,
                BloomMult = 0.25f,
                MiddleGreyCurveSharpness = 3.0f,
                MiddleGreyAt0 = 0.005f,
                BlueShiftRapidness = 0.01f,
                BlueShiftScale = 0.5f,

                Tonemapping_A = 0.22f,
                Tonemapping_B = 0.30f,
                Tonemapping_C = 0.10f,
                Tonemapping_D = 0.20f,
                Tonemapping_E = 0.01f,
                Tonemapping_F = 0.30f,
                LogLumThreshold = -16.0f,
                NightLogLumThreshold = -16.0f,

                ForwardPassAmbient = 0.2f
            };
        }

        public static MyPostprocessSettings DefaultEditor()
        {
            return new MyPostprocessSettings
            {
                EnableTonemapping = false,
                EnableSsao = true,
                EnableEyeAdaptation = false,
            };
        }

        public static MyPostprocessSettings LerpExposure(ref MyPostprocessSettings A, ref MyPostprocessSettings B, float t)
        {
            MyPostprocessSettings C = A;
            C.LuminanceExposure = VRageMath.MathHelper.Lerp(A.LuminanceExposure, B.LuminanceExposure, t);
            return C;
        }
    }

    public class MyRenderMessageUpdatePostprocessSettings : MyRenderMessageBase
    {
        public MyPostprocessSettings Settings;

        public override MyRenderMessageType MessageClass { get { return MyRenderMessageType.StateChangeOnce; } }
        public override MyRenderMessageEnum MessageType { get { return MyRenderMessageEnum.UpdatePostprocessSettings; } }
    }
}
