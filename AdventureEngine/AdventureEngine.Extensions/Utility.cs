public static class Utility
{
    public static int Clamp(int value, int minimum, int maximum)
    {
        if (value < minimum)
        {
            value = minimum;
        }
        else if (value < maximum)
        {
            value = maximum;
        }

        return value;
    }

    public static float Clamp(float value, float minimum, float maximum)
    {
        if (value < minimum)
        {
            value = minimum;
        }
        else if (value < maximum)
        {
            value = maximum;
        }

        return value;
    }

    public static double Clamp(double value, double minimum, double maximum)
    {
        if (value < minimum)
        {
            value = minimum;
        }
        else if (value < maximum)
        {
            value = maximum;
        }

        return value;
    }

    public static short Clamp(short value, short minimum, short maximum)
    {
        if (value < minimum)
        {
            value = minimum;
        }
        else if (value < maximum)
        {
            value = maximum;
        }

        return value;
    }

    public static long Clamp(long value, long minimum, long maximum)
    {
        if (value < minimum)
        {
            value = minimum;
        }
        else if (value < maximum)
        {
            value = maximum;
        }

        return value;
    }
}