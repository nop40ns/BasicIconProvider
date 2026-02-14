using System.Windows.Media;

namespace BasicIconProviderSample
{
    public class SampleFileItem
    {
        public string Name { get; set; } = "";
        public required ImageSource? Icon { get; set; }
    }
}