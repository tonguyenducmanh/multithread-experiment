// Test việc chạy 2 thread song song
// 1 thread luôn làm việc thêm dữ liệu vào biến lưu trữ global
// 1 thread luôn làm việc đọc dữ liệu ra và handle nghiệp vụ
using TDProject.Core.Business;

namespace TDProject.Test.Business;

public class TwoThreadConcurrentTest
{
    /// <summary>
    /// Test chạy 2 luồng song song bằng kiểu dữ liệu list
    /// </summary>
    [Fact]
    public void TwoThreadConcurrentUsingList_TestRunConcurrent()
    {
        TwoThreadUsingList testObject = new TwoThreadUsingList();
        var exeption = Record.Exception(() => { testObject.RunTask(4, 3);});
        Assert.Null(exeption);
    }
    
    /// <summary>
    /// Test chạy 2 luồng song song bằng kiểu dữ liệu concurrent
    /// </summary>
    [Fact]
    public void TwoThreadConcurrentUsingConcurrent_TestRunConcurrent()
    {
        TwoThreadUsingConcurrentQueue testObject = new TwoThreadUsingConcurrentQueue();
        var exeption = Record.Exception(() => { testObject.RunTask(4, 3);});
        Assert.Null(exeption);
    }
}