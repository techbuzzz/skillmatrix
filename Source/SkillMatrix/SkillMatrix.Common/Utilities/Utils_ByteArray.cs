using System;
using System.Linq;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        public static bool ByteArrayEquals(byte[] a1, int start1, int length1,
                                   byte[] a2, int start2, int length2)
        {
            if (a1 == a2)
            {
                return true;
            }
            if ((a1 != null) && (a2 != null))
            {
                if (length1 != length2)
                {
                    return false;
                }
                for (int i = 0; i < length1; i++)
                {
                    if (a1[i + start1] != a2[i + start2])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //TODO: is performance optimal?
        public static int IndexOfSequence(byte[] buffer, int startIndex, int length, byte[] pattern)
        {
            int i = Array.IndexOf(buffer, pattern[0], startIndex);
            while (i >= 0 && i <= buffer.Length - pattern.Length && i <= length - pattern.Length)
            {
                if (ByteArrayEquals(buffer, i, pattern.Length,
                                    pattern, 0, pattern.Length))
                    return i;
                i = Array.IndexOf(buffer, pattern[0], i + 1);
            }
            return -1;
        }

        public static bool InSequence<T>(this T item, params T[] sequence)
        {
            return sequence.Contains(item);
        }
     
    }
}