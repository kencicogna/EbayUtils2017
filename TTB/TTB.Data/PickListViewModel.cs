using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTB.Common;
using TTB.Repository;

namespace TTB.Data
{
    public class PickListViewModel : ViewModelBase
    {
        // Constructor
        public PickListViewModel() : base()
        {
        }

        //
        // Properties
        //
        public PickListModel LineItem { get; set; }
        public List<PickListModel> Entries { get; set; }
        public PickListModel SearchEntity { get; set; }

        //
        // Methods
        //
        protected override void Init()
        {
            LineItem = new PickListModel();
            Entries = new List<PickListModel>();
            SearchEntity = new PickListModel();
            base.Init();
        }

        protected override void Edit()
        {
            var mgr = new PickListDAL();
            //PickList = mgr.Get(Convert.ToInt32(EventArgument));
            // Need an ID to edit
            LineItem = mgr.Get(EventArgument); // RowID?
            base.Edit();
        }

        protected override void Delete()
        {
            var mgr = new PickListDAL();
            LineItem = new PickListModel();
            //PickList.ID = Convert.ToInt32(EventArgument);
            LineItem.Title = EventArgument;

            mgr.Delete(LineItem);

            Get(); // may or may not want to get all the products again

            base.Delete();
        }

        protected override void Add()
        {
            IsValid = true;

            // Create new pbject and set default values
            LineItem = new PickListModel();
            LineItem.SKU = "";
            LineItem.Location = "";
            LineItem.ImageURL = "Images/missing.png";
            LineItem.Quantity = 0;
            LineItem.Title = "";
            LineItem.Variation = "";
            LineItem.DIFlag = "";

            base.Add();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new PickListModel();
            base.ResetSearch();
        }

        protected override void Save()
        {
            var mgr = new PickListDAL();

            // add/update DB
            if (Mode == "Add")
            {
                mgr.Insert(LineItem);
            }
            else
            {
                LineItem.SKU = EventArgument;
                LineItem.Location = EventArgLocation;
                mgr.Update(LineItem);
            }

            ValidationErrors = mgr.ValidationErrors;

            base.Save();
        }

        protected override void Get()
        {
            var mgr = new PickListDAL();
            Entries = mgr.Get(SearchEntity);

            base.Get();
        }

        public override void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                // just add a button to Index.cshtml where data-dt-action="special"
                case "special":
                    break;

                default:
                    break;

            }

            base.HandleRequest();
        }

    }
}
