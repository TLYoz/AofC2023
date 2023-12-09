namespace AdventOfCode;

public static class MathCompanion
{
    
    public static long Lcm(this int[] elements)
    {
        var lmc = 1L;
        var divisor = 2;
         
        while (true) {
             
            var counter = 0;
            var divisible = false;
            for (var i = 0; i < elements.Length; i++) {

                if (elements[i] == 1) {
                    counter++;
                }
                if (elements[i] % divisor == 0) {
                    divisible = true;
                    elements[i] /= divisor;
                }
            }
            if (divisible) {
                lmc *= divisor;
            }
            else {
                divisor++;
            }

            if (counter == elements.Length) {
                return lmc;
            }
        }
    }
}