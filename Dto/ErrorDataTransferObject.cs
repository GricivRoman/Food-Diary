
using System.Text.Json;

namespace FoodDiary.Dto
{
    public class ErrorDataTransferObject
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
