using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.Province;

public interface IProvinceTable
{
    public ProvinceTemplate GetProvince(ProvinceId id);
}