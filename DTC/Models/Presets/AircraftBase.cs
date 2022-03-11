using System;

namespace DTC.Models.Presets
{
    public class AircraftBase
    {
        public string GetName(AircraftModel aircraftModel)
        {
            if (aircraftModel == AircraftModel.F16C)
            {
                return "F-16C";
            }
            throw new Exception();
        }

        public string GetName1(AircraftModel aircraftModel)
        {
            if (aircraftModel == AircraftModel.JF17)
            {
                return "JF-17";
            }
            throw new Exception();
        }
    }
}