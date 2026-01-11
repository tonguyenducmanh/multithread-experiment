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
        TwoThreadConcurrentUsingList testObject = new TwoThreadConcurrentUsingList();
        var exeption = Record.Exception(() => { testObject.RunTask(4);});
        Assert.Null(exeption);
    }
    
    /// <summary>
    /// Test chạy 2 luồng song song bằng kiểu dữ liệu concurrent
    /// </summary>
    [Fact]
    public void TwoThreadConcurrentUsingConcurrent_TestRunConcurrent()
    {
        TwoThreadConcurrentUsingConcurrentQueue testObject = new TwoThreadConcurrentUsingConcurrentQueue();
        var exeption = Record.Exception(() => { testObject.RunTask(4);});
        Assert.Null(exeption);
    }
}