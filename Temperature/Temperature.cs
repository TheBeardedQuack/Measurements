﻿using System;

namespace TBQ.Measurements.Temperature
{
    public abstract class Temperature : IUnit, IComparable<Temperature>, IEquatable<Temperature> {
        protected Temperature(double initialValue = 0.0f) {
            _Value = initialValue;
            _BaseValue = ConvertToBaseValue(Value);
        }
        protected Temperature(Temperature convertValue) {
            _BaseValue = convertValue.BaseValue;
            _Value = ConvertFromBaseValue(BaseValue);
        }

        protected virtual void OnValueChanged(double previous) {
            BaseValue = ConvertToBaseValue(Value);
            ValueChanged?.Invoke(this, previous);
        }
        protected virtual void OnBaseValueChanged(double previous) {
            Value = ConvertFromBaseValue(BaseValue);
        }

        protected abstract double ConvertFromBaseValue(double baseValue);
        protected abstract double ConvertToBaseValue(double unitValue);

        public int CompareTo(Temperature temperature) {
            return BaseValue.CompareTo(temperature?.BaseValue);
        }
        public int CompareTo(object obj) {
            if(obj is Temperature tmp)
                return CompareTo(tmp);
            throw new ArgumentException($"Parameter is not of type {nameof(Temperature)}", nameof(obj));
        }

        public bool Equals(Temperature temperature) {
            return CompareTo(temperature) == 0;
        }
        public override bool Equals(object other) {
            return Equals(other as Temperature);
        }

        public override int GetHashCode() {
            return BaseValue.GetHashCode();
        }
        
        public static implicit operator double(Temperature t) {
            return t.Value;
        }

        public abstract Temperature Add(double tetemperaturep);
        public abstract Temperature Add(Temperature temperature);
        public abstract Temperature Subtract(double temperature);
        public abstract Temperature Subtract(Temperature temperature);
        public abstract Temperature Negate();
        
        public static bool operator ==(Temperature t1, double t2) {
            return t1.CompareTo(t2) == 0;
        }
        public static bool operator !=(Temperature t1, double t2) {
            return t1.CompareTo(t2) != 0;
        }
        public static bool operator <(Temperature t1, double t2) {
            return t1.CompareTo(t2) < 0;
        }
        public static bool operator >(Temperature t1, double t2) {
            return t1.CompareTo(t2) > 0;
        }
        public static bool operator <=(Temperature t1, double t2) {
            return t1.CompareTo(t2) <= 0;
        }
        public static bool operator >=(Temperature t1, double t2) {
            return t1.CompareTo(t2) >= 0;
        }

        public static bool operator ==(Temperature t1, Temperature t2) {
            return t1.CompareTo(t2) == 0;
        }
        public static bool operator !=(Temperature t1, Temperature t2) {
            return t1.CompareTo(t2) != 0;
        }
        public static bool operator <(Temperature t1, Temperature t2) {
            return t1.CompareTo(t2) < 0;
        }
        public static bool operator >(Temperature t1, Temperature t2) {
            return t1.CompareTo(t2) > 0;
        }
        public static bool operator <=(Temperature t1, Temperature t2) {
            return t1.CompareTo(t2) <= 0;
        }
        public static bool operator >=(Temperature t1, Temperature t2) {
            return t1.CompareTo(t2) >= 0;
        }

        public event EventHandler<double> ValueChanged;

        public static Type BaseUnit { get; } = typeof(Celsius);

        public string MeasurementType { get; } = nameof(Temperature);
        public abstract string Name { get; }
        public abstract string Symbol { get; }

        public double Value {
            get => _Value;
            set {
                var prev = _Value;
                bool changing = !prev.Equals(value);

                _Value = value;
                if(changing)
                    OnValueChanged(prev);
            }
        }
        public double BaseValue {
            get => _BaseValue;
            set {
                var prev = _BaseValue;
                bool changing = !prev.Equals(value);

                _BaseValue = value;
                if(changing)
                    OnBaseValueChanged(prev);
            }
        }

        private double _Value = 0.0f;
        private double _BaseValue;
    }
}
