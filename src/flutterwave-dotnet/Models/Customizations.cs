namespace Flutterwave.Net
{
    public class Customizations
    {
        public Customizations(string title,
                              string description,
                              string logo)
        {
            Title = title;
            Description = description;
            Logo = logo;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }
}
