using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories.Exceptions
{
    internal static class ExceptionMessages
    {
        public static string InvalidTypeOfDough = 
            "Invalid type of dough.";

        public static string InvalidTypeOfFlour = 
            "Invalid type of flour.";

        public static string InvalidWeightOfDough =
            "Dough weight should be in the range[1..200].";

        public static string InvalidTopping =
            "Cannot place {0} on top of your pizza.";

        public static string InvalidToppingWeight =
            "{0} weight should be in the range [1..50].";
    }
}
