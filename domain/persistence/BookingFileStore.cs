using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace BookingSystem
{
public class BookingFileStore : IBookingStore
{
    private readonly string _filepath;
    private readonly string _directoryPath;

    public BookingFileStore(string _directoryPath)
    {
        this._directoryPath = _directoryPath;
        _filepath = Path.Combine(_directoryPath, "history.json");
    }

    public async Task SaveAsync(Booking booking)
    {
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        var bookings = await LoadAllAsync();
        var bookingsList = bookings.ToList();
        bookingsList.Add(booking);
        string json = JsonSerializer.Serialize(bookingsList);
        await File.WriteAllTextAsync(_filepath, json);
    }

    public async Task<IReadOnlyList<Booking>> LoadAllAsync()
    {
        if (!File.Exists(_filepath))
        {
            return new List<Booking>();
        }
       
        string json = await File.ReadAllTextAsync(_filepath);
        return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
    }

}
}
