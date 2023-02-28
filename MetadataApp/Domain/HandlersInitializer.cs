using System.Windows;
using MetadataApp.Domain.Interfaces;
using MetadataApp.ui.ViewModels;

namespace MetadataApp.Domain;

public class HandlersInitializer : IHandlersInitializer
{
    private readonly string[] Tags;

    public HandlersInitializer()
    {
        Tags = new[]
        {
            "About", "TermTable", "Group1", "Group2", "Group3", "AVTF", "FGO",
            "Quit", "Table", "GroupTable", "AcademicScholarship", "SocialScholarship",
            "IncreasedScholarship", "Secret", "WeekTable", "TermTable"
        };
    }

    public Handler[] Initialize()
    {
        Handler[] handlers = new Handler[Tags.Length];

        for (int i = 0; i < Tags.Length; i++)
            handlers[i] = new Handler(Tags[i], tag => MessageBox.Show(tag));

        return handlers;
    }
}