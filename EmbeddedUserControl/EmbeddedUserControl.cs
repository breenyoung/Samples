using System;
using System.IO;
using System.Reflection;
using System.Web.UI;

namespace CodeGolem
{
    public abstract class EmbeddedUserControl : UserControl
    {
        private string _markupName;

        public EmbeddedUserControl(string markupName)
        {
            _markupName = markupName;
        }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        // loads markup from embedded resource
        string content = String.Empty;

        Stream stream = Assembly.GetAssembly(GetType()).GetManifestResourceStream(GetType(), _markupName);
        using (StreamReader reader = new StreamReader(stream))
        {
            content = reader.ReadToEnd();
        }
        Control userControl = Page.ParseControl(content);
        Controls.Add(userControl);
            
        // binds child controls and events
        bindControls(userControl);
    }
        
    private void bindControls(Control control)
    {
        Type type = GetType();
        foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            foreach (MarkupControlAttribute attribute in fieldInfo.GetCustomAttributes(typeof(MarkupControlAttribute), true)) 
            {
                string id = string.IsNullOrEmpty(attribute.ID) ? fieldInfo.Name : attribute.ID;

                Control childControl = control.FindControl(id);
                fieldInfo.SetValue(this, childControl);

                foreach (MarkupControlEventAttribute eventAttribute in fieldInfo.GetCustomAttributes(typeof(MarkupControlEventAttribute), true))
                {
                    string eventName = eventAttribute.EventName;
                    string eventHandler = eventAttribute.EventHandler;
                    EventInfo eventInfo = childControl.GetType().GetEvent(eventName);

                    Delegate eventDelegate = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, GetType().GetMethod(eventHandler, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
                    eventInfo.AddEventHandler(childControl, eventDelegate);
                }
            }
        }
    }
    }
}
