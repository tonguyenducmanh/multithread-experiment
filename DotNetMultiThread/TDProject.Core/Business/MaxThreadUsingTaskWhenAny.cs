// Xử lý tối đa n thread tại 1 thời điểm, nếu số thread đã đạt tới mức tối đa
// Sẽ phải đợi có ít nhất 1 thread rảnh rỗi để tiếp tục làm việc

using System.Collections.Concurrent;
using TDProject.Core.Utility;

namespace TDProject.Core.Business;

/// <summary>
/// Chạy max thread sử dụng Task.WhenAny
/// </summary>
public class MaxThreadUsingTaskWhenAny
{
    #region Declare

    /// <summary>
    /// danh sách database id đang chờ xử lý
    /// </summary>
    private ConcurrentQueue<Guid> _concurrentQueueDBIds = new ConcurrentQueue<Guid>();

    /// <summary>
    /// Số lượng thread tối đa được phép chạy đồng thời
    /// </summary>
    private int _maxThreadCount;

    /// <summary>
    /// Danh sách các task đang chạy để theo dõi
    /// </summary>
    private List<Task> _runningTasks = new List<Task>();

    /// <summary>
    /// Lock object để đồng bộ hóa truy cập vào _runningTasks
    /// </summary>
    private readonly object _lockObject = new object();

    #endregion

    #region Constructor

    /// <summary>
    /// Khởi tạo với số thread tối đa
    /// </summary>
    /// <param name="maxThreadCount">Số lượng thread tối đa (mặc định = 3)</param>
    public MaxThreadUsingTaskWhenAny(int maxThreadCount = 3)
    {
        _maxThreadCount = maxThreadCount;
    }

    #endregion

    #region Methods

    private Task DoSlowMethod(Guid dbId)
    {
        Task task = Task.Run(() =>
        {
            try
            {
                TDLogger.LogRuntime($"WhenAny - Bắt đầu xử lý {dbId} (Thread: {Thread.CurrentThread.ManagedThreadId})");
                TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
                TDLogger.LogRuntime($"WhenAny - Kết thúc xử lý {dbId} (Thread: {Thread.CurrentThread.ManagedThreadId})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{this.GetType()} {nameof(DoSlowMethod)} - {dbId}: {ex}");
            }
        });

        return task;
    }

    /// <summary>
    /// Xử lý tất cả items trong queue
    /// </summary>
    private async Task ProcessQueue()
    {
        while (_concurrentQueueDBIds.TryDequeue(out Guid currentDB))
        {
            // Nếu đã đạt max thread, đợi cho đến khi có ít nhất 1 task hoàn thành
            if (_runningTasks.Count >= _maxThreadCount)
            {
                Task completedTask = await Task.WhenAny(_runningTasks);
                
                lock (_lockObject)
                {
                    _runningTasks.Remove(completedTask);
                }
            }

            // Tạo và thêm task mới vào danh sách
            Task newTask = DoSlowMethod(currentDB);
            
            lock (_lockObject)
            {
                _runningTasks.Add(newTask);
            }
        }
    }

    /// <summary>
    /// Làm việc đa luồng với giới hạn số thread
    /// </summary>
    public async Task RunTask(int iterations, int dbIdGenerateOneTime)
    {
        // Giả lập trường hợp thêm database vào queue
        // Các thread sẽ được giới hạn bằng cách sử dụng Task.WhenAny
        for (int currentIteration = 0; currentIteration < iterations; currentIteration++)
        {
            TDLogger.LogRuntime($"WhenAny - Bắt đầu đổ thêm data vào hàng đợi lần {currentIteration + 1}");
            
            for (int dbIdCount = 0; dbIdCount < dbIdGenerateOneTime; dbIdCount++)
            {
                _concurrentQueueDBIds.Enqueue(Guid.NewGuid());
            }

            TDLogger.LogRuntime($"WhenAny - Kết thúc đổ thêm data vào hàng đợi lần {currentIteration + 1} (Tổng trong queue: {_concurrentQueueDBIds.Count})");
            
            // Xử lý queue
            await ProcessQueue();
            
            TDSlowMethod.CPUBurnByTime(TimeSpan.FromSeconds(2));
        }

        // Đợi tất cả task hoàn thành
        TDLogger.LogRuntime("WhenAny - Đang đợi tất cả task hoàn thành...");
        
        Task[] remainingTasks;
        lock (_lockObject)
        {
            remainingTasks = _runningTasks.ToArray();
        }
        
        await Task.WhenAll(remainingTasks);
        TDLogger.LogRuntime("WhenAny - Hoàn thành tất cả task!");
    }

    #endregion
}