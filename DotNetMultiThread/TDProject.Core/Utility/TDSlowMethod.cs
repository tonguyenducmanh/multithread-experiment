using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using TDProject.Model;

namespace TDProject.Core.Utility;

/// <summary>
/// class chứa các method chạy chậm để giả lập cpu xử lý công việc nặng
/// </summary>
public static class TDSlowMethod
{
    /// <summary>
    /// CPU burn theo số vòng (deterministic)
    /// </summary>
    /// <param name="iterations">số lần chạy vòng lặp</param>
    /// <returns></returns>
    public static double CPUBurnByLoop(long iterations)
    {
        double result = 0;
        for (long i = 0; i < iterations; i++)
        {
            result += Math.Sqrt(i) * Math.Sin(i);
        }

        return result;
    }

    /// <summary>
    /// Đốt CPU theo thời gian
    /// </summary>
    /// <param name="duration">thời gian tối đa muốn đốt</param>
    public static void CPUBurnByTime(TimeSpan duration)
    {
        var sw = Stopwatch.StartNew();
        double x = 1.0;

        while (sw.Elapsed < duration)
        {
            x = Math.Sqrt(x * 1.000001 + 0.123456);
        }
    }

    /// <summary>
    /// Hash nhiều vòng
    /// </summary>
    /// <param name="rounds">số lần hash</param>
    public static byte[] HeavyHash(int rounds)
    {
        using var sha = SHA256.Create();
        byte[] data = Encoding.UTF8.GetBytes(TDConstant.LoremIpsum);

        for (int i = 0; i < rounds; i++)
        {
            data = sha.ComputeHash(data);
        }

        return data;
    }

    /// <summary>
    /// Đếm số nguyên tố (branch heavy)
    /// </summary>
    /// <param name="max">số lần đếm tối đa</param>
    public static int CountPrimes(int max)
    {
        int count = 0;

        for (int i = 2; i <= max; i++)
        {
            bool prime = true;

            for (int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                {
                    prime = false;
                    break;
                }
            }

            if (prime)
                count++;
        }

        return count;
    }
}