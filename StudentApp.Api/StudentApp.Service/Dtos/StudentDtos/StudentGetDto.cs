namespace StudentApp.Service.Dtos.StudentDtos
{
    public class StudentGetDto
    {
        public string FullName { get; set; }    
        public decimal Point { get; set; }  
        public StudentinGroupDto Group { get; set; }    
    }

    public class StudentinGroupDto
    { 
        public int Id { get; set; }
        public string GroupNo { get; set; }
    }
}
