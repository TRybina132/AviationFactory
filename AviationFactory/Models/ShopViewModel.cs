using AviationFactory.Entities;
using AviationFactory.Entities.Personnel;

namespace AviationFactory.Models;

public class ShopViewModel
{
    public Shop Shop { get; set; }
    public BaseEmployee? Head { get; set; }
}