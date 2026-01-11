// Test việc chạy 2 thread song song
// 1 thread luôn làm việc thêm dữ liệu vào biến lưu trữ global
// 1 thread luôn làm việc đọc dữ liệu ra và handle nghiệp vụ

using System.Collections.Concurrent;
using TDProject.Core.Utility;

namespace TDProject.Core.Business;

/// <summary>
/// Test chạy song song 2 luồng bằng kiểu dữ liệu List
/// </summary>
public class TwoThreadConcurrentUsingList
{
    #region Declare

    /// <summary>
    /// danh cách database id đang chờ xử lý
    /// </summary>
    private List<Guid> _listDatabaseId = new List<Guid>();

    /// <summary>
    /// object dùng để lock khi thêm databaseid
    /// </summary>
    private object _lockDatabaseObj = new object();

    /// <summary>
    /// cờ quạt nhận biết có đang chạy lệnh ở thread xử lý nghiệp vụ không
    /// </summary>
    private bool _isRunningBussinessThread = false;

    #endregion

    #region Methods

    private void DoSlowMethod()
    {
        // nếu đã có task run rồi thì cứ chạy tiếp vòng while trong task đó
        if (_isRunningBussinessThread)
        {
            return;
        }

        _isRunningBussinessThread = true;

        // chưa có thì run task mới
        Task.Run(() =>
        {
            try
            {
                while (_listDatabaseId.Count > 0)
                {
                    // luôn phải có try catch khi làm việc đa luồng
                    try
                    {
                        lock (_lockDatabaseObj)
                        {
                            Guid currentDB = _listDatabaseId[0];
                            TDLogger.LogRuntime("Kiểu dữ liệu list - Bắt đầu chạy " + currentDB);
                            TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
                            _listDatabaseId.RemoveAt(0);
                            TDLogger.LogRuntime("Kiểu dữ liệu list - Kết thúc chạy " + currentDB);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{this.GetType()} {nameof(DoSlowMethod)}" + ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{this.GetType()} {nameof(DoSlowMethod)}" + ex);
            }
            finally
            {
                _isRunningBussinessThread = false;
            }
        });
    }

    /// <summary>
    /// làm việc đa luồng
    /// </summary>
    public void RunTask(int iterations, int dbIdGenerateOneTime)
    {
        // giả lập trường hợp thêm 1 database nào list
        // sau đó 1 thread khác đọc list database và in ra màn hình
        for (int currentIteration = 0; currentIteration < iterations; currentIteration++)
        {
            TDLogger.LogRuntime($"Kiểu dữ liệu list - Bắt đầu đổ thêm data vào hàng đợi lần {currentIteration + 1}");
            for (int dbIdCount = 0; dbIdCount < dbIdGenerateOneTime; dbIdCount++)
            {
                // phải gọi lock thủ công
                lock (_lockDatabaseObj)
                {
                    _listDatabaseId.Add(Guid.NewGuid());
                }
            }

            TDLogger.LogRuntime($"Kiểu dữ liệu list - Kết thúc đổ thêm data vào hàng đợi lần {currentIteration + 1}");
            DoSlowMethod();
            TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
        }
        while (_listDatabaseId.Count > 0)
        {
            // nếu còn đang xử lý thì chưa dừng thread chính để trace log
            TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
        }
    }

    #endregion
}

/// <summary>
/// Test chạy song song 2 luồng bằng kiểu dữ liệu concurrentqueue
/// </summary>
public class TwoThreadConcurrentUsingConcurrentQueue
{
    #region Declare

    /// <summary>
    /// danh cách database id đang chờ xử lý
    /// </summary>
    private ConcurrentQueue<Guid> _concurrentQueueDBIds = new ConcurrentQueue<Guid>();

    /// <summary>
    /// cờ quạt nhận biết có đang chạy lệnh ở thread xử lý nghiệp vụ không
    /// </summary>
    private bool _isRunningBussinessThread = false;

    #endregion

    #region Methods

    private void DoSlowMethod()
    {
        // nếu đã có task run rồi thì cứ chạy tiếp vòng while trong task đó
        if (_isRunningBussinessThread)
        {
            return;
        }


        _isRunningBussinessThread = true;

        // chưa có thì run task mới
        Task.Run(() =>
        {
            try
            {
                while (_concurrentQueueDBIds.Count > 0)
                {
                    Guid currentDB;
                    _concurrentQueueDBIds.TryDequeue(out currentDB);
                    // luôn phải có try catch khi làm việc đa luồng
                    try
                    {
                        TDLogger.LogRuntime("Kiểu dữ liệu concurrent - Bắt đầu chạy " + currentDB);
                        TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
                        TDLogger.LogRuntime("Kiểu dữ liệu concurrent - Kết thúc chạy " + currentDB);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{this.GetType()} {nameof(DoSlowMethod)}" + ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{this.GetType()} {nameof(DoSlowMethod)}" + ex);
            }
            finally
            {
                _isRunningBussinessThread = false;
            }
        });
    }

    /// <summary>
    /// làm việc đa luồng
    /// </summary>
    public void RunTask(int iterations, int dbIdGenerateOneTime)
    {
        // giả lập trường hợp thêm 1 database nào list
        // sau đó 1 thread khác đọc list database và in ra màn hình
        for (int currentIteration = 0; currentIteration < iterations; currentIteration++)
        {
            TDLogger.LogRuntime($"Kiểu dữ liệu list - Bắt đầu đổ thêm data vào hàng đợi lần {currentIteration + 1}");
            for (int dbIdCount = 0; dbIdCount < dbIdGenerateOneTime; dbIdCount++)
            {
                _concurrentQueueDBIds.Enqueue(Guid.NewGuid());
            }

            TDLogger.LogRuntime($"Kiểu dữ liệu list - Kết thúc đổ thêm data vào hàng đợi lần {currentIteration + 1}");
            DoSlowMethod();
            TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
        }
        
        while (_concurrentQueueDBIds.Count > 0)
        {
            // nếu còn đang xử lý thì chưa dừng thread chính để trace log
            TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
        }
    }

    #endregion
}