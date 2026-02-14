using PressureWashingQuoting.Models;

namespace PressureWashingQuoting.Services;

public interface IQuoteService
{
    QuoteResult CalculateQuote(QuoteRequest request);
    List<ChemicalOption> GetAvailableChemicals();
}

public class QuoteService : IQuoteService
{
    private const double BaseTripFee = 40.00; // GBP

    public QuoteResult CalculateQuote(QuoteRequest request)
    {
        double rate = GetSurfaceRate(request.SurfaceType);
        double areaCost = request.SquareFootage * rate;
        
        double chemicalRate = request.ChemicalOptions.Where(c => c.IsSelected).Sum(c => c.PricePerSqFt);
        double chemicalCost = request.SquareFootage * chemicalRate;

        return new QuoteResult
        {
            BaseTripFee = BaseTripFee,
            SurfaceRate = rate,
            AreaCost = areaCost,
            ChemicalCost = chemicalCost,
            TotalPrice = BaseTripFee + areaCost + chemicalCost
        };
    }

    public List<ChemicalOption> GetAvailableChemicals()
    {
        return new List<ChemicalOption>
        {
            new ChemicalOption { Name = "Standard Surface Cleaner", PricePerSqFt = 0.05 },
            new ChemicalOption { Name = "Sodium Hypochlorite (Soft Wash)", PricePerSqFt = 0.15 },
            new ChemicalOption { Name = "Heavy Duty Degreaser", PricePerSqFt = 0.10 },
            new ChemicalOption { Name = "Biocide Treatment (Long-lasting)", PricePerSqFt = 0.20 }
        };
    }

    private double GetSurfaceRate(SurfaceType surfaceType)
    {
        return surfaceType switch
        {
            SurfaceType.Concrete => 0.20,
            SurfaceType.Siding => 0.25,
            SurfaceType.Decking => 0.40,
            SurfaceType.Roof => 0.55,
            _ => 0.0
        };
    }
}
