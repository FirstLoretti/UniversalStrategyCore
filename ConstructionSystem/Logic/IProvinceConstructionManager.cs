using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.ConstructionSystem.Logic;

public interface IProvinceConstructionManager
{
    public void OnTurnEnd(ProvinceTemplate province);
    public void AddConstructionOrder(ProvinceTemplate province, ConstructionOrder constructionOrder);
}