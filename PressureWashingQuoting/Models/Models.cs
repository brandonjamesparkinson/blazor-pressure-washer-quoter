using System.ComponentModel.DataAnnotations;

namespace PressureWashingQuoting.Models;

public enum SurfaceType
{
    [Display(Name = "Concrete (£0.20/sqft)")]
    Concrete,
    [Display(Name = "Siding (£0.25/sqft)")]
    Siding,
    [Display(Name = "Decking (£0.40/sqft)")]
    Decking,
    [Display(Name = "Roof (£0.55/sqft)")]
    Roof
}

public class ChemicalOption
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public double PricePerSqFt { get; set; }
    public bool IsSelected { get; set; }

    public string DisplayText => $"{Name} (+{PricePerSqFt:C}/sqft)";
}

public class QuoteRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Surface Type is required")]
    public SurfaceType SurfaceType { get; set; }

    [Required(ErrorMessage = "Square Footage is required")]
    [Range(1, 100000, ErrorMessage = "Square footage must be between 1 and 100,000")]
    public double SquareFootage { get; set; }

    public List<ChemicalOption> ChemicalOptions { get; set; } = new();
}

public class QuoteResult
{
    public double BaseTripFee { get; set; }
    public double SurfaceRate { get; set; }
    public double AreaCost { get; set; }
    public double ChemicalCost { get; set; }
    public double TotalPrice { get; set; }
}
