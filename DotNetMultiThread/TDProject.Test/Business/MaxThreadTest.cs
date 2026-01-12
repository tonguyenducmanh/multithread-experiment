using TDProject.Core.Business;

namespace TDProject.Test.Business;

/// <summary>
/// Xử lý tôi đa n thread tại 1 thời điểm, nếu số thread đã đạt tới mức tối đa
/// Sẽ phải đợi có ít nhất 1 thread rảnh rỗi để tiếp tục làm việc
/// </summary>
public class MaxThreadTest
{
    /// <summary>
    /// Test chạy n thread tối đa bằng SemaphoreSlim
    /// </summary>
    [Fact]
    public void MaxThreadUsingSemaphoreSlim_TestRunConcurrent()
    {
        MaxThreadUsingSemaphoreSlim testObject = new MaxThreadUsingSemaphoreSlim();
        var exeption = Record.Exception(() => { testObject.RunTask(4, 3);});
        // dọn dẹp bộ nhớ
        testObject.Dispose();
        Assert.Null(exeption);
    }
}