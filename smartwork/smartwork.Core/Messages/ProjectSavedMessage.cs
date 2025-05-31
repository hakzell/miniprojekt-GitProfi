using CommunityToolkit.Mvvm.Messaging.Messages;
using smartwork.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartwork.Core.Messages;

public class ProjectSavedMessage : ValueChangedMessage<Project>
{
    public ProjectSavedMessage(Project value) : base(value)
    {
    }
}
