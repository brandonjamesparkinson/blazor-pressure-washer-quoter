namespace PressureWashingQuoting.Services;

public class BookingSlot
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public interface IBookingService
{
    Task<List<BookingSlot>> GetAvailableSlotsAsync(DateTime date);
    Task<bool> BookSlotAsync(BookingSlot slot, string customerEmail);
}

public class MockBookingService : IBookingService
{
    public async Task<List<BookingSlot>> GetAvailableSlotsAsync(DateTime date)
    {
        // Simulate async delay
        await Task.Delay(500);

        var slots = new List<BookingSlot>();
        var startHour = 9; // 9 AM
        var endHour = 17; // 5 PM

        for (int i = startHour; i < endHour; i++)
        {
            // Randomly mark some slots as unavailable to test UI
            bool isAvailable = i != 13; // Lunch break at 1 PM is unavailable

            slots.Add(new BookingSlot
            {
                StartTime = date.Date.AddHours(i),
                EndTime = date.Date.AddHours(i + 1),
                IsAvailable = isAvailable
            });
        }

        return slots;
    }

    public async Task<bool> BookSlotAsync(BookingSlot slot, string customerEmail)
    {
        await Task.Delay(1000);
        return true; // Always succeed in mock
    }
}
