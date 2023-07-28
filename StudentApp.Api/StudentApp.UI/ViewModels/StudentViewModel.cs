namespace StudentApp.UI.ViewModels
{
    public class StudentViewModel
    {
        public List<StudentViewModelItem> Students { get; set; }
    }

    public class StudentViewModelItem
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string GroupNo { get; set; }
        public decimal Point { get; set; }
    }
}
