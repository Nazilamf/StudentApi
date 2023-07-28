﻿namespace StudentApp.UI.ViewModels
{
    public class GroupViewModel
    {
        public List<GroupViewModelItem> Groups { get; set; }
    }

    public class GroupViewModelItem
    {
        public int Id { get; set; }
        public string GroupNo { get; set; }
    }
}

