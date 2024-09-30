using System;
using System.Collections.Generic;


namespace PlantsRadiation
{
    public interface IRadiation
    {
        void ModifyNutrientLevel(Wombleroot l);
        void ModifyNutrientLevel(Wittenroot l);
        void ModifyNutrientLevel(Woreroot l);
    }

    public class Alpha : IRadiation
    {
        public void ModifyNutrientLevel(Wombleroot l)
        {
            l.ModifyLevel(2);
        }

        public void ModifyNutrientLevel(Wittenroot l)
        {
            l.ModifyLevel(-3);
        }

        public void ModifyNutrientLevel(Woreroot l)
        {
            l.ModifyLevel(1);
        }

        private Alpha() { }

        private static Alpha instance = null;
        public static Alpha Instance()
        {
            if (instance == null)
            {
                instance = new Alpha();
            }
            return instance;
        }
    }

    public class Delta : IRadiation
    {
        public void ModifyNutrientLevel(Wombleroot l)
        {
            l.ModifyLevel(-2);
        }

        public void ModifyNutrientLevel(Wittenroot l)
        {
            l.ModifyLevel(4);
        }

        public void ModifyNutrientLevel(Woreroot l)
        {
            l.ModifyLevel(1);
        }

        private Delta() { }

        private static Delta instance = null;
        public static Delta Instance()
        {
            if (instance == null)
            {
                instance = new Delta();
            }
            return instance;
        }
    }

    public class NoRadiation : IRadiation
    {
        public void ModifyNutrientLevel(Wombleroot l)
        {
            l.ModifyLevel(-1);
        }

        public void ModifyNutrientLevel(Wittenroot l)
        {
            l.ModifyLevel(-1);
        }

        public void ModifyNutrientLevel(Woreroot l)
        {
            l.ModifyLevel(-1);
        }

        private NoRadiation() { }

        private static NoRadiation instance = null;
        public static NoRadiation Instance()
        {
            if (instance == null)
            {
                instance = new NoRadiation();
            }
            return instance;
        }
    }
}
