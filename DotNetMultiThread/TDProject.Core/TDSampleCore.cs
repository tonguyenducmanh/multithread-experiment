using TDProject.Model;

namespace TDProject.Core;

/// <summary>
/// File test sample
/// </summary>
public class TDSampleCore
{
    #region Constructor
    
    /// <summary>
    /// Hàm khởi tạo
    /// </summary>
    public TDSampleCore()
    {
        
    }

    #endregion

    #region Method

    /// <summary>
    /// Lấy ra sample model
    /// </summary>
    /// <returns></returns>
    public TDSampleModel GetSampleModel()
    {
        TDSampleModel sample = new TDSampleModel();
        sample.ModelId = Guid.NewGuid();
        sample.Name = "test";
        sample.Status = "active";
        return sample;
    }

    #endregion
}