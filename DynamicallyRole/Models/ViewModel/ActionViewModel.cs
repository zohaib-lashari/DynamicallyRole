namespace DynamicallyRole.Models.ViewModel
{
    public class ActionViewModel
    {

        
            public string Id { get; set; }  // Action ID (e.g., ":Account:Reg", ":Home:Index")
            public string Name { get; set; }  // Action Name (e.g., "Reg", "Index")
            public string DisplayName { get; set; }  // DisplayName is null in the provided data
        

    }
}
