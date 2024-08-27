using System;

namespace Astronomy
{
    public static class MoonPhaseCalculator
    {
        public enum Phase
        {
            Nova,
            Crescente,
            QuartoCrescente,
            QuaseCheia,
            Cheia,
            Minguante,
            QuartoMInguante,
            QuaseNova,
        }

        static double synodicLength = 29.530588853; //length in days of a complete moon cycle
        static DateTime referenceNewMoonDate = new DateTime(2017, 11, 18);

        public static Phase GetPhase(DateTime date)
        {
            return GetPhase(GetAge(date));
        }

        static double GetAge(DateTime date)
        {
            double days = (date - referenceNewMoonDate).TotalDays;

            return days % synodicLength;
        }

        static Phase GetPhase(double age)
        {
            if (age < 1) return Phase.Nova;
            if (age < 7) return Phase.Crescente;
            if (age < 8) return Phase.QuartoCrescente;
            if (age < 14) return Phase.QuaseCheia;
            if (age < 15) return Phase.Cheia;
            if (age < 22) return Phase.Minguante;
            if (age < 23) return Phase.QuartoMInguante;
            if (age < 29) return Phase.QuaseNova;

            return Phase.Nova;
        }
    }
}