using TDProject.Core;
using TDProject.Model;

namespace TDProject.Test;

/// <summary>
/// test xem code reference có build được không
/// </summary>
public class TDSampleTest
{
    /// <summary>
    /// test xem các project reference đã chạy được chưa
    /// </summary>
    [Fact]
    public void CreateSampleModel()
    {
        TDSampleCore sample = new TDSampleCore();
        TDSampleModel modelBuild = sample.GetSampleModel();
        Assert.NotNull(modelBuild);
    }
}