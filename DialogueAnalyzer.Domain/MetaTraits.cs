using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueAnalyzer.Domain
{
    public class MetaTraits
    {
        private double _dominance;
        private double _empathy;
        private double _anxiety;
        private double _impulsivity;
        private double _analyticity;

        public double Dominance
        {
            get => _dominance;
            set => _dominance = Clamp(value);
        }

        public double Empathy
        {
            get => _empathy;
            set => _empathy = Clamp(value);
        }

        public double Anxiety
        {
            get => _anxiety;
            set => _anxiety = Clamp(value);
        }

        public double Impulsivity
        {
            get => _impulsivity;
            set => _impulsivity = Clamp(value);
        }

        public double Analyticity
        {
            get => _analyticity;
            set => _analyticity = Clamp(value);
        }

        public MetaTraits()
        {
            _dominance = 0.5;
            _empathy = 0.5;
            _anxiety = 0.5;
            _impulsivity = 0.5;
            _analyticity = 0.5;
        }

        public MetaTraits(double dominance, double empathy, double anxiety, double impulsivity, double analyticity)
        {
            Dominance = dominance;
            Empathy = empathy;
            Anxiety = anxiety;
            Impulsivity = impulsivity;
            Analyticity = analyticity;
        }

        public void ApplyDelta (MetaTraits delta, double learningRate = 0.1)
        {
            Dominance += delta.Dominance * learningRate;
            Empathy += delta.Empathy * learningRate;
            Anxiety += delta.Anxiety * learningRate;
            Impulsivity += delta.Impulsivity * learningRate;
            Analyticity += delta.Analyticity * learningRate;
        }

        public MetaTraits GetDelta(MetaTraits other)
        {
            return new MetaTraits(
                other.Dominance - Dominance,
                other.Empathy - Empathy,
                other.Anxiety - Anxiety,
                other.Impulsivity - Impulsivity,
                other.Analyticity - Analyticity
            );
        }


        // продолжить писать класс профиль
        // из фазы 1 сделать ci/cd

        private static double Clamp(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public override string ToString()
        {
            return $"Dom:{Dominance:F2} Emp:{Empathy:F2} Anx:{Anxiety:F2} Imp:{Impulsivity:F2} Ana:{Analyticity:F2}";
        }

        public override bool Equals(object obj)
        {
            if (obj is not MetaTraits other)
                return false;

            return Dominance == other.Dominance
                && Empathy == other.Empathy
                && Anxiety == other.Anxiety
                && Impulsivity == other.Impulsivity
                && Analyticity == other.Analyticity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Dominance, Empathy, Anxiety, Impulsivity, Analyticity);
        }
    }
}
