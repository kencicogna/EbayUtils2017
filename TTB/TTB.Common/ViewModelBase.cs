using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TTB.Common
{
    public class ViewModelBase
    {
        // Constructor
        //
        public ViewModelBase()
        {
            Init();
        }

        // Properties
        //
        public bool IsValid { get; set; }
        public string Mode { get; set; }
        public string EventCommand { get; set; }
        public string EventArgument { get; set; }
        public string EventArgLocation { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool IsSearchAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsDetailAreaVisible { get; set; }


        // Methods
        //
        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
            ValidationErrors = new List<KeyValuePair<string, string>>();
            ListMode();
        }

        protected virtual void ListMode()
        {
            IsValid = true;
            //IsSearchAreaVisible = true;
            IsSearchAreaVisible = false;
            IsListAreaVisible = true;
            IsDetailAreaVisible = false;

            Mode = "List";
        }

        protected virtual void AddMode()
        {
            IsSearchAreaVisible = false;
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Add";
        }

        protected virtual void EditMode()
        {
            IsSearchAreaVisible = false;
            IsListAreaVisible = false;
            IsDetailAreaVisible = true;

            Mode = "Edit";
        }

        protected virtual void Get()
        {
        }

        protected virtual void ResetSearch()
        {
        }

        protected virtual void Add()
        {
            AddMode();
        }

        protected virtual void Edit()
        {
            EditMode();
        }

        protected virtual void Delete()
        {
            ListMode(); // might not want this if we are caching the result set
        }

        protected virtual void Save()
        {
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            // could be invalide because of the reasons we added from the mgr, or from the data annotations
            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "save":
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch(); // might want to keep search 
                    Delete();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                default:
                    break;
            }
        }

    }
}
