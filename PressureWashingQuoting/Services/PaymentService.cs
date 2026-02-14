namespace PressureWashingQuoting.Services;

public interface IPaymentService
{
    Task<string> CreateCheckoutSessionAsync(double amount, string currency, string successUrl, string cancelUrl);
}

public class MockPaymentService : IPaymentService
{
    public async Task<string> CreateCheckoutSessionAsync(double amount, string currency, string successUrl, string cancelUrl)
    {
        await Task.Delay(500);
        // creative way to mock: return the success URL directly to simulate a successful payment redirect
        return successUrl; 
    }
}
