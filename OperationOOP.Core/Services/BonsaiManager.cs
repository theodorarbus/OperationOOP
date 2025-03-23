using OperationOOP.Core.Models;

namespace OperationOOP.Core.Services;

public class BonsaiManager
{
    private readonly List<Bonsai> _bonsais;

    public BonsaiManager(List<Bonsai> bonsais)
    {
        _bonsais = bonsais;
    }

    public List<Bonsai> FilterByCareLevel(CareLevel level)
    {
        return _bonsais.Where(b => b.CareLevel == level).ToList();
    }

    public List<Bonsai> SortByLastPruned()
    {
        return _bonsais.OrderBy(b => b.LastPruned).ToList();
    }

    public List<Bonsai> SearchByName(string name)
    {
        return _bonsais
            .Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}