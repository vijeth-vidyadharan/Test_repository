namespace EmployeeManagement.ViewModel
{
    public class EditViewModel:EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string? ExistingPhotoPath { get; set; }

    }
}
