using Microsoft.AspNetCore.Mvc.Rendering;
using ProjeYonetimSistemi.UI.MVC.Entity;

public class ProjectViewModel
{
    public ProjectEntity Project { get; set; }
    public SelectList Teams { get; set; }
}