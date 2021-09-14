using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
using Object = UnityEngine.Object;
using Coroutine = Coroutines.Coroutine;
using Tweens.Formulas;

namespace Tweens
{
    public static class Formula
    {
        internal static InversionFormula Invertion { get; private set; } = new InversionFormula();

        public static LinearFormula Linear { get; private set; } = new LinearFormula();

        public static QuadraticInFormula QuadIn { get; private set; } = new QuadraticInFormula();

        public static QuadraticOutFormula QuadOut { get; private set; } = new QuadraticOutFormula();

        public static QuadraticInOutFormula QuadInOut { get; private set; } = new QuadraticInOutFormula();

        public static CubicInFormula CubicIn { get; private set; } = new CubicInFormula();

        public static CubicOutFormula CubicOut { get; private set; } = new CubicOutFormula();

        public static CubicInOutFormula CubicInOut { get; private set; } = new CubicInOutFormula();

        public static QuarticInFormula QuartIn { get; private set; } = new QuarticInFormula();

        public static QuarticOutFormula QuartOut { get; private set; } = new QuarticOutFormula();

        public static QuarticInOutFormula QuartInOut { get; private set; } = new QuarticInOutFormula();

        public static QuinticInFormula QuintIn { get; private set; } = new QuinticInFormula();

        public static QuinticOutFormula QuintOut { get; private set; } = new QuinticOutFormula();

        public static QuinticInOutFormula QuintInOut { get; private set; } = new QuinticInOutFormula();

        public static SineInFormula SineIn { get; private set; } = new SineInFormula();

        public static SineOutFormula SineOut { get; private set; } = new SineOutFormula();

        public static SineInOutFormula SineInOut { get; private set; } = new SineInOutFormula();

        public static CircularInFormula CircIn { get; private set; } = new CircularInFormula();

        public static CircularOutFormula CircOut { get; private set; } = new CircularOutFormula();

        public static CircularInOutFormula CircInOut { get; private set; } = new CircularInOutFormula();

        public static ExponentialInFormula ExpoIn { get; private set; } = new ExponentialInFormula();

        public static ExponentialOutFormula ExpoOut { get; private set; } = new ExponentialOutFormula();

        public static ExponentialInOutFormula ExpoInOut { get; private set; } = new ExponentialInOutFormula();

        public static ElasticInFormula ElasticIn { get; private set; } = new ElasticInFormula();

        public static ElasticOutFormula ElasticOut { get; private set; } = new ElasticOutFormula();

        public static ElasticInOutFormula ElasticInOut { get; private set; } = new ElasticInOutFormula();

        public static BackInFormula BackIn { get; private set; } = new BackInFormula();

        public static BackOutFormula BackOut { get; private set; } = new BackOutFormula();

        public static BackInOutFormula BackInOut { get; private set; } = new BackInOutFormula();

        public static BounceInFormula BounceIn { get; private set; } = new BounceInFormula();

        public static BounceOutFormula BounceOut { get; private set; } = new BounceOutFormula();

        public static BounceInOutFormula BounceInOut { get; private set; } = new BounceInOutFormula();
    }
}