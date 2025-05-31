using smartwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace smartwork.Data.Services;

public class Repository : IRepository
{
    string _file;
    List<Project> _projects;
    XElement _rootElement;

    public Repository(string file)
    {
        this._file = file;

        if (File.Exists(file))
        {
            this._rootElement = XElement.Load(_file);
        }
        else
        {
            this._rootElement = new XElement("project");
        }


    }

    // Problem: Das Schlüsselwort "from" ist in LINQ-Abfragen reserviert und kann nicht als Variablenname verwendet werden.
    // Lösung: Variablennamen wie "from" und "to" umbenennen, z.B. in "fromTime" und "toTime".

    public List<Project> Get()
    {
        var projects = from project in this._rootElement.Descendants("project")
                       let date = DateTime.TryParse(project.Attribute("date")?.Value, out var d) ? d : DateTime.MinValue
                       let fromTime = TimeSpan.TryParse(project.Attribute("from")?.Value, out var f) ? f : TimeSpan.Zero
                       let toTime = TimeSpan.TryParse(project.Attribute("to")?.Value, out var t) ? t : TimeSpan.Zero
                       let description = project.Attribute("description")?.Value ?? ""
                       select new Project(date, fromTime, toTime, description);

        this._projects = projects.ToList();
        return this._projects;
    }

    public bool Save(Project project)
    {
        try 
        {
            var projectElement = new XElement("project");

            var dateAttribute = new XAttribute("date", project.Date.ToString("yyyy-MM-dd"));
            projectElement.Add(dateAttribute);

            var fromAttribute = new XAttribute("from", project.From.ToString(@"hh\:mm"));
            projectElement.Add(fromAttribute);

            var toAttribute = new XAttribute("to", project.To.ToString(@"hh\:mm"));
            projectElement.Add(toAttribute);

            var descriptionAttribute = new XAttribute("description", project.Description);
            projectElement.Add(descriptionAttribute);

            this._rootElement.Add(projectElement);
            this._rootElement.Save(this._file);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving project: {ex.Message}");
            return false;
        }
    }

}
