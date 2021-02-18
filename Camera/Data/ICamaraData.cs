using System.Collections.Generic;

namespace Data
{
    public interface ICamaraData
    {
        IEnumerable<CameraRow> GetData();
        IEnumerable<CameraRow> SearchName(string name);
    }
}