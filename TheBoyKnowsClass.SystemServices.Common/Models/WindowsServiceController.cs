using System;
using System.Collections.Generic;
using System.ServiceProcess;
using TheBoyKnowsClass.Common.Attributes;
using TheBoyKnowsClass.Common.Desktop.Enumerations;
using TheBoyKnowsClass.Common.Enumerations;
using TheBoyKnowsClass.SystemServices.Common.Enumerations;

namespace TheBoyKnowsClass.Services.Common.Models
{
    public class WindowsServiceController : ServiceController
    {
        public WindowsServiceController(string serviceName) : base(serviceName)
        {
            MachineName = Environment.MachineName;

            Refresh();
        }

        public string ServiceAssemblyPath { get; set; }

        public ServiceStartMode ServiceStartMode { get; set; }

        public bool InteractWithDesktop { get; set; }

        public ServiceAccount Account { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public SystemServiceStatus GetStatus()
        {
            try
            {
                ServiceControllerStatus status = Status;

                SystemServiceStatus systemServiceStatus;

                bool isInstalled = Enum.TryParse(status.ToString(), out systemServiceStatus);

                return isInstalled ? (SystemServiceStatus)status : SystemServiceStatus.NotInstalled;
            }
            catch (InvalidOperationException)
            {
                return SystemServiceStatus.NotInstalled;
            }
        }

        private void RefreshValues()
        {
            if (GetStatus() != SystemServiceStatus.NotInstalled)
            {
                foreach (var kvp in GetServiceProperties())
                {
                    TypeAttribute typeAttribute = kvp.Key.GetEnumAttribute<TypeAttribute>();

                    switch (kvp.Key)
                    {
                        case SystemServiceProperty.DesktopInteract:
                            InteractWithDesktop = (bool)Convert.ChangeType(kvp.Value, typeAttribute.Type);
                            break;
                        case SystemServiceProperty.DisplayName:
                            DisplayName = Convert.ChangeType(kvp.Value, typeAttribute.Type).ToString();
                            break;
                        case SystemServiceProperty.PathName:
                            ServiceAssemblyPath = Convert.ChangeType(kvp.Value, typeAttribute.Type).ToString();
                            break;
                        case SystemServiceProperty.StartMode:
                            ServiceStartMode = (ServiceStartMode)Convert.ChangeType(kvp.Value, typeAttribute.Type);
                            break;
                        case SystemServiceProperty.StartName:
                            UserName = Convert.ChangeType(kvp.Value, typeAttribute.Type).ToString();
                            break;
                    }
                }
            }
        }

        private Dictionary<SystemServiceProperty, object> GetServiceProperties()
        {
            if (GetStatus() == SystemServiceStatus.NotInstalled)
            {
                return new Dictionary<SystemServiceProperty,object>();
            }

            var serviceProperties = new Dictionary<SystemServiceProperty, object>();

            var service = new System.Management.ManagementObject(String.Format("WIN32_Service.Name='{0}'", ServiceName));

            foreach (var property in service.Properties)
            {
                SystemServiceProperty systemServiceProperty;

                bool isProperty = Enum.TryParse<SystemServiceProperty>(property.Name, out systemServiceProperty);

                if (isProperty)
                {
                    serviceProperties.Add(systemServiceProperty, property.Value);
                }
            }

            return serviceProperties;
        }

        private void SetServiceProperties(Dictionary<SystemServiceProperty, object> serviceProperties, bool restart)
        {
            if (GetStatus() == SystemServiceStatus.NotInstalled)
            {
                return;
            }

            var service = new System.Management.ManagementObject(String.Format("WIN32_Service.Name='{0}'", ServiceName));
            try
            {
                var paramList = new object[11];

                foreach (KeyValuePair<SystemServiceProperty, object> kvp in serviceProperties)
                {
                    SystemServiceProperty systemServiceProperty = kvp.Key;
                    object servicePropertyValue = kvp.Value;
                    TypeAttribute typeAttribute = systemServiceProperty.GetEnumAttribute<TypeAttribute>();
                    paramList[(int)systemServiceProperty] = Convert.ChangeType(servicePropertyValue, typeAttribute.Type);
                }

                var output = (int)service.InvokeMethod("Change", paramList);

                if (output != 0)
                {
                    throw new Exception(string.Format("FAILED with code {0}", output));
                }

                if (restart)
                {
                    Stop();
                    Start();
                }
            }
            finally
            {
                service.Dispose();
            } 
        }

        private void SetServiceProperties(SystemServiceProperty parameter, object value, bool restart)
        {
            if (GetStatus() == SystemServiceStatus.NotInstalled)
            {
                return;
            }

            var serviceProperties = new Dictionary<SystemServiceProperty, object>();
            serviceProperties.Add(parameter, value);

            SetServiceProperties(serviceProperties, restart);
        }

        public bool HasChanged
        {
            get
            {
                bool hasChanges = false;

                foreach (KeyValuePair<SystemServiceProperty, object> property in GetServiceProperties())
                {
                    TypeAttribute typeAttribute = property.Key.GetEnumAttribute<TypeAttribute>();

                    switch (property.Key)
                    {
                        case SystemServiceProperty.DesktopInteract:
                            hasChanges = hasChanges || InteractWithDesktop != (bool)Convert.ChangeType(property.Value, typeAttribute.Type);
                            break;
                        case SystemServiceProperty.DisplayName:
                            hasChanges = hasChanges || DisplayName != Convert.ChangeType(property.Value, typeAttribute.Type).ToString();
                            break;
                        case SystemServiceProperty.PathName:
                            hasChanges = hasChanges || ServiceAssemblyPath != Convert.ChangeType(property.Value, typeAttribute.Type).ToString();
                            break;
                        case SystemServiceProperty.StartMode:
                            hasChanges = hasChanges || ServiceStartMode != (ServiceStartMode)Convert.ChangeType(property.Value, typeAttribute.Type);
                            break;
                        case SystemServiceProperty.StartName:
                            hasChanges = hasChanges || UserName != Convert.ChangeType(property.Value, typeAttribute.Type).ToString();
                            break;
                        default:
                            break;
                    }
                }

                return hasChanges;
            }
        }

        public void ApplyChanges()
        {
            if (HasChanged)
            {
                

                var serviceProperties = new Dictionary<SystemServiceProperty, object>();

                foreach (KeyValuePair<SystemServiceProperty, object> property in GetServiceProperties())
                {
                    TypeAttribute typeAttribute = property.Key.GetEnumAttribute<TypeAttribute>();

                    switch (property.Key)
                    {
                        case SystemServiceProperty.DesktopInteract:
                            if (InteractWithDesktop != (bool)Convert.ChangeType(property.Value, typeAttribute.Type))
                            {
                            }
                            break;
                        case SystemServiceProperty.DisplayName:
                            if ( DisplayName != Convert.ChangeType(property.Value, typeAttribute.Type).ToString())
                            {
                            }
                            break;
                        case SystemServiceProperty.PathName:
                            if (ServiceAssemblyPath != Convert.ChangeType(property.Value, typeAttribute.Type).ToString())
                            {
                                serviceProperties.Add(SystemServiceProperty.PathName, ServiceAssemblyPath);
                            }
                            break;
                        case SystemServiceProperty.StartMode:
                            if (ServiceStartMode != (ServiceStartMode)Convert.ChangeType(property.Value, typeAttribute.Type))
                            {
                                serviceProperties.Add(SystemServiceProperty.StartMode, ServiceStartMode);
                            }
                            break;
                        case SystemServiceProperty.StartName:
                            if (UserName != Convert.ChangeType(property.Value, typeAttribute.Type).ToString())
                            {
                                serviceProperties.Add(SystemServiceProperty.StartName, ServiceStartMode);
                            }
                            break;
                        default:
                            break;
                    }
                }

                
                
                ;
            }
            
        }
    }
}
