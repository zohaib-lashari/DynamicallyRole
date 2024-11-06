namespace DynamicallyRole.Models.ViewModel
{
    public class ControllerViewModel
    {
        
            public string Id { get; set; }  // Controller ID (e.g., ":Account", ":Home")
            public string Name {  get; set; }
            public List<ActionViewModel> Actions { get; set; }  // List of actions associated with this controller
        


    }
}
