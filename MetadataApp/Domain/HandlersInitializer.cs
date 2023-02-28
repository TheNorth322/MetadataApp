using System.Collections.Generic;
using System.Windows;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.Domain;

public class HandlersInitializer
{
    private string[] Tags;

    public HandlersInitializer()
    {
        Tags = new string[] { "TermTable", "Group1", "Group2", "Group3", "AVTF", "FGO", 
            "About", "Quit", "Table", "GroupTable", "AcademicScholarship", 
            "SocialScholarship", "IncreasedScholarship", 
            "Secret", "WeekTable", "TermTable"};
    }
    
    public Handler[] Initialize()
    {
        Handler[] handlers = new Handler[Tags.Length];
        
        for (int i = 0; i < Tags.Length; i++)
            handlers[i] = new Handler(Tags[i], (tag) => MessageBox.Show(tag));
        
        return handlers;
    }
}