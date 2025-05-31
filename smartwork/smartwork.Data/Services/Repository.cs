using smartwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace smartwork.Data.Services
{
    public class Repository
    {
        string _file;
        List<Erfassung> _contacts;
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
                this._rootElement = new XElement("erfassung");
            }


        }
    }
}
