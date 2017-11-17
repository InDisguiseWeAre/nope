using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    class ZTwo
    {
        public UInt64 Value;

        private static int BitsInNum(UInt64 num)
        {
            return Convert.ToString((Int64)num, 2).Length;
        }

        public static UInt64 mod(UInt64 val, UInt64 del)
        {
            if (val < del) return val;

            while (val >= del)
            {
                UInt64 mask = del << (BitsInNum(val) - BitsInNum(del));
                val ^= mask;
            }

            return val;
        }

        public static ZTwo operator +(ZTwo a, ZTwo b)
        {
            return new ZTwo() { Value = (a.Value ^ b.Value) };
        }

        public static ZTwo operator *(ZTwo a, ZTwo b)
        {
            UInt64 result = 0, uint_a = a.Value, uint_b = b.Value;

            //"обычное" умножение
            for (int i = 0; i < 8; i++)
            {
                result ^= (UInt64)(uint_a * (uint_b & ((UInt64)1 << i)));
            }

            //return new ZTwo() { Value = mod(result, 283) };
            return new ZTwo() { Value = result };
        }

        public override string ToString()
        {
            return Convert.ToString((Int64)this.Value, 2);
        }

        public static ZTwo ParseFromBits(string bits)
        {
            return new ZTwo() { Value = Convert.ToUInt64(bits, 2) };
        }
    }
}
