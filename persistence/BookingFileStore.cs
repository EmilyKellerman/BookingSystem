using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace ConferenceBookingDomain{
public class BookingFileStore
{
    private readonly string _filepath;

    public BookingFileStore(string filepath)
    {
        _filepath = filepath;
    }

    public async Task SaveAsync(IEnumerable<Booking> bookings)
    {

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