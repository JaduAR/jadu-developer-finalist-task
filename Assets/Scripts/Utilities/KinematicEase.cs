// ------------------------
// Onur Ereren - April 2022
// ------------------------

// Ease calculation script.
// Allows for evaluation of values between 0-1 according to selected easing.
// Mathematical formulas obtained from: https://easings.net/

using UnityEngine;

namespace EaseLibrary
{

    public static class KinematicEase
    {
        private const float c1 = 1.70158f;
        private const float c2 = c1 * 1.525f;
        private const float c3 = c1 + 1f;
        private const float c4 = (2f * Mathf.PI) / 3f;
        private const float c5 = (2f * Mathf.PI) / 4.5f;
        private const float n1 = 7.5625f;
        private const float d1 = 2.75f;
        
        public static float Evaluate(EaseType type, float t)
        {
            float result = 0f;

            switch (type)
            {
                case EaseType.Linear:
                    result = t;
                    break;
                case EaseType.EaseInSine:
                    result = 1f - (Mathf.Cos((t * Mathf.PI) * 0.5f));
                    break;
                case EaseType.EaseOutSine:
                    result = Mathf.Sin((t * Mathf.PI) * 0.5f);
                    break;
                case EaseType.EaseInOutSine:
                    result = -(Mathf.Cos(Mathf.PI * t) - 1f) * 0.5f;
                    break;
                case EaseType.EaseInQuad:
                    result = t * t;
                    break;
                case EaseType.EaseOutQuad:
                    result = 1f - (1f - t) * (1f - t);
                    break;
                case EaseType.EaseInOutQuad:
                    result = t < 0.5f ? 2f * t * t : 1 - Mathf.Pow(-2f * t + 2f, 2f) * 0.5f;
                    break;
                case EaseType.EaseInCubic:
                    result = t * t * t;
                    break;
                case EaseType.EaseOutCubic:
                    result = 1f - Mathf.Pow(1 - t, 3f);
                    break;
                case EaseType.EaseInOutCubic:
                    result = t < 0.5f ? 4f * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 3f) * 0.5f;
                    break;
                case EaseType.EaseInQuart:
                    result = t * t * t * t;
                    break;
                case EaseType.EaseOutQuart:
                    result = 1f - Mathf.Pow(1f - t, 4);
                    break;
                case EaseType.EaseInOutQuart:
                    result = t < 0.5f ? 8 * t * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 4) * 0.5f;
                    break;
                case EaseType.EaseInQuint:
                    result = t * t * t * t * t;
                    break;
                case EaseType.EaseOutQuint:
                    result = 1f - Mathf.Pow(1f - t, 5f);
                    break;
                case EaseType.EaseInOutQuint:
                    result = t < 0.5f ? 16 * t * t * t * t * t : 1f - Mathf.Pow(-2f * t + 2f, 5) * 0.5f;
                    break;
                case EaseType.EaseInExpo:
                    result = t == 0f ? 0f : Mathf.Pow(2f, 10f * t - 10f);
                    break;
                case EaseType.EaseOutExpo:
                    result = t == 1f ? 1f : 1f - Mathf.Pow(2f, -10f * t);
                    break;
                case EaseType.EaseInOutExpo:
                    result = t == 0 ? 0 :
                        t == 1 ? 1 :
                        t < 0.5f ? Mathf.Pow(2f, 20f * t - 10f) * 0.5f : (2f - Mathf.Pow(2f, -20f * t + 10f)) * 0.5f;
                    break;
                case EaseType.EaseInCirc:
                    result = 1f - Mathf.Sqrt(1f - Mathf.Pow(t, 2f));
                    break;
                case EaseType.EaseOutCirc:
                    result = Mathf.Sqrt(1f - Mathf.Pow(t - 1f, 2f));
                    break;
                case EaseType.EaseInOutCirc:
                    result = t < 0.5f
                        ? (1f - Mathf.Sqrt(1f - Mathf.Pow(2f * t, 2f))) * 0.5f
                        : (Mathf.Sqrt(1f - Mathf.Pow(-2f * t + 2f, 2f)) + 1f) * 0.5f;
                    break;
                case EaseType.EaseInBack:
                    result = c3 * t * t * t - c1 * t * t;
                    break;
                case EaseType.EaseOutBack:
                    result = 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);
                    break;
                case EaseType.EaseInOutBack:
                    result = t < 0.5f
                        ? (Mathf.Pow(2f * t, 2f) * ((c2 + 1f) * 2f * t - c2)) * 0.5f
                        : (Mathf.Pow(2f * t - 2f, 2f) * ((c2 + 1f) * (t * 2f - 2f) + c2) + 2f) * 0.5f;
                    break;
                case EaseType.EaseInElastic:
                    result = t == 0f ? 0f :
                        t == 1f ? 1f : -Mathf.Pow(2f, 10f * t - 10f) * Mathf.Sin((t * 10f - 10.75f) * c4);
                    break;
                case EaseType.EaseOutElastic:
                    result = t == 0f ? 0f :
                        t == 1f ? 1f : Mathf.Pow(2f, 10f * t) * Mathf.Sin((t * 10f - 0.75f) * c4) + 1f;
                    break;
                case EaseType.EaseInOutElastic:
                    result = t == 0f ? 0f :
                        t == 1f ? 1f :
                        t < 0.5f ? -(Mathf.Pow(2f, 20f * t - 10f) * Mathf.Sin((20f * t - 11.125f) * c5)) * 0.5f :
                        (Mathf.Pow(2f, -20f * t + 10f) * Mathf.Sin((20f * t - 11.125f) * c5)) * 0.5f + 1f;
                    break;
                case EaseType.EaseInBounce:
                    result = 1f - Evaluate(EaseType.EaseOutBounce, 1f - t);
                    break;
                case EaseType.EaseOutBounce:
                    result = t < 1f / d1 ? n1 * t * t :
                        t < 2f / d1 ? n1 * (t -= 1.5f / d1) * t + 0.75f :
                        t < 2.5f / d1 ? n1 * (t -= 2.25f / d1) * t + 0.9375f : n1 * (t -= 2.625f / d1) * t + 0.984375f;
                    break;
                case EaseType.EaseInOutBounce:
                    result = t < 0.5f
                        ? (1f - Evaluate(EaseType.EaseOutBounce, 1f - 2f * t)) * 0.5f
                        : (1f + Evaluate(EaseType.EaseOutBounce, 2f * t - 1f)) * 0.5f;
                    break;
                case EaseType.CustomOne:
                    result = Mathf.Pow((-Mathf.Pow((-t + 1f), 0.3f) + 1f), 0.3f);
                    break;
                default:
                    break;
            }

            return result;
        }

    }

    public enum EaseType
    {
        Linear,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInQuad,
        EaseOutQuad,
        EaseInOutQuad,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic,
        EaseInQuart,
        EaseOutQuart,
        EaseInOutQuart,
        EaseInQuint,
        EaseOutQuint,
        EaseInOutQuint,
        EaseInExpo,
        EaseOutExpo,
        EaseInOutExpo,
        EaseInCirc,
        EaseOutCirc,
        EaseInOutCirc,
        EaseInBack,
        EaseOutBack,
        EaseInOutBack,
        EaseInElastic,
        EaseOutElastic,
        EaseInOutElastic,
        EaseInBounce,
        EaseOutBounce,
        EaseInOutBounce,
        CustomOne
    }
}