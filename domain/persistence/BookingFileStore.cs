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

    public async Task SaveAsync(IEnumerable<Booking> bookings)
    {
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        string json = JsonSerializer.Serialize(bookings);
        await File.WriteAllTextAsync(_filepath, json);
    }

    public async Task<List<Booking>> LoadAsync()
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