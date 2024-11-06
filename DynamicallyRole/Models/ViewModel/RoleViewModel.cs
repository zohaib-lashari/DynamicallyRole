namespace DynamicallyRole.Models.ViewModel
{
    public class RoleViewModel    {
        public string Id { get; set; }  // Represents the role ID (e.g., ":Account", ":Home")
        public string Name { get; set; }  // Represents the role name (e.g., "Account", "Home")
        public string DisplayName { get; set; }  // DisplayName is null in the provided data
        public string AreaName { get; set; }  // AreaName is null in the provided data
        public List<ControllerViewModel> Controllers { get; set; }  // List of controllers associated with this role
    }


   

}
