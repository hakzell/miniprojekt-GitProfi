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
    public bool Delete(Project p)
    {
        try
        {

            XElement? projectElement = _rootElement.Descendants("project")
          .FirstOrDefault(project =>
              (project.Attribute("description")?.Value ?? "") == p.Description &&
              (project.Attribute("from")?.Value ?? "") == p.From.ToString("o") &&  
              (project.Attribute("to")?.Value ?? "") == p.To.ToString("o") &&
              (project.Attribute("date")?.Value ?? "") == p.Date.ToString("o")
          );

            

            if (projectElement != null)
            {
                projectElement.Remove();
                _rootElement.Save(_file);                                             // xml wird gespeichert 
                return true;                                                          // löschen hat funktioniert 
            }

            return false;


        }
        catch (Exception e)                                                           // wenn ein fehler beim löschen auftritt 
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            return false;                                                             // löschen war nicht erfolgreich
        }



    }

}
