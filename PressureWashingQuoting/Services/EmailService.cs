namespace PressureWashingQuoting.Services;

public interface IEmailService
{
    Task SendBookingConfirmationAsync(string toEmail, string customerName, DateTime appointmentTime, double amountPaid);
}

public class MockEmailService : IEmailService
{
    public async Task SendBookingConfirmationAsync(string toEmail, string customerName, DateTime appointmentTime, double amountPaid)
    {
        await Task.Delay(500);
        Console.WriteLine($"[Mock Email] To: {toEmail}, Subject: Booking Confirmed!");
        Console.WriteLine($"Body: Hi {customerName}, your appointment is set for {appointmentTime} and payment of {amountPaid:C} is received.");
    }
}
