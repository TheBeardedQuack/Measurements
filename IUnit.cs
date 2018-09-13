using System;

namespace TBQ.Measurements {
    public interface IUnit : IComparable {
        string Name { get; }
        string Symbol { get; }
        string MeasurementType { get; }
        
        double Value { get; }
    }
}
