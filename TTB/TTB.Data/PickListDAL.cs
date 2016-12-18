using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using TTB.Repository;
using System.Data.SqlClient;
using System.Data;

namespace TTB.Data
{
    public class PickListDAL
    {
        // Constructor
        //
        public PickListDAL()
        {
            Init();
        }

        // Properties
        //
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public string SqlGet { get; set; }
        public string SqlUpdPickList { get; set; }
        public string SqlUpdInventory { get; set; }
        public string GlobalConnectionString { get; set; }

        // Initialize defaults
        public void Init()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
            SqlGet = "select * from Picklist";
            SqlUpdPickList = "update Picklist set location = @location where sku = @sku";
            SqlUpdInventory = "update Inventory set location = @location where sku = @sku and active=1";

            // Defined in Web.config
            GlobalConnectionString = ConfigurationManager.ConnectionStrings["TTBDB"].ConnectionString;
        }

        // Methods
        //
        public bool Validate(PickListModel entity)
        {
            //
            // TODO: put in the BLL class?
            //
            ValidationErrors.Clear();

            /*
            if (entity.ID <= 0)
            {
                ValidationErrors.Add(new KeyValuePair<string, string>("ID", "ID must be > 0"));
            }
            else if (entity.ID > 100)
            {
                ValidationErrors.Add(new KeyValuePair<string, string>("ID", "ID must be less than 100"));
            }
            */

            return (ValidationErrors.Count == 0);
        }

        public bool Update(PickListModel entity)
        {
            bool ret = false;
            ret = Validate(entity);

            if (ret)
            {
                // TODO: check number of rows updates = 1
                using (SqlConnection connection = new SqlConnection(GlobalConnectionString))
                {
                    // Update PickList table
                    SqlCommand cmdUpdPickList = new SqlCommand(SqlUpdPickList, connection);
                    cmdUpdPickList.Parameters.Add("@location", SqlDbType.VarChar).Value = entity.Location;
                    cmdUpdPickList.Parameters.Add("@sku", SqlDbType.VarChar).Value = entity.SKU;

                    // Update Inventory Table
                    SqlCommand cmdUpdInventory = new SqlCommand(SqlUpdInventory, connection);
                    cmdUpdInventory.Parameters.Add("@location", SqlDbType.VarChar).Value = entity.Location;
                    cmdUpdInventory.Parameters.Add("@sku", SqlDbType.VarChar).Value = entity.SKU;

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    Int32 rowsAffected; 

                    try
                    {
                        // Execute Update PickList table
                        rowsAffected = cmdUpdPickList.ExecuteNonQuery();
                        if (rowsAffected != 1)
                            throw new Exception("error: "+rowsAffected+" rows were updated in PickList table, instead of 1");

                        // Execute Update Inventory Table
                        rowsAffected = cmdUpdInventory.ExecuteNonQuery();
                        if (rowsAffected != 1)
                            throw new Exception("error: "+rowsAffected+" rows were updated in Inventory table, instead of 1");
                    }
                    catch (Exception ex)
                    {
                        // Log error?
                        throw ex;
                    }
                }
            }

            return ret;
        }

        public bool Insert(PickListModel entity)
        {
            bool ret = false;
            ret = Validate(entity);

            if (ret)
            {
                // TODO: insert to DB code goes here
            }

            return ret;
        }

        public bool Delete(PickListModel entity)
        {
            // TODO: create DELETE code here

            return true;
        }

        public PickListModel Get(String Title)
        {
            var list = new List<PickListModel>();
            var ret = new PickListModel();

            list = GetAllData();

            ret = list.Find(e => e.Title == Title);

            return ret;
        }

        //
        // Search - i.e. Get specific entity
        //
        public List<PickListModel> Get(PickListModel entity)
        {
            var ret = new List<PickListModel>();

            // TODO: Add real data access method here
            ret = GetAllData();

            // Search/Filter results
            if (!string.IsNullOrEmpty(entity.Title))
            {
                ret = ret.FindAll(e => e.Title.ToLower().Contains(entity.Title.ToLower()));
            }

            return ret;
        }

        //
        // Get All Data
        //
        private List<PickListModel> GetAllData()
        {
            string message = string.Empty;
            var PickList = new List<PickListModel>();

            using (SqlConnection connection = new SqlConnection(GlobalConnectionString))
            {
                SqlCommand cmdGetItems = new SqlCommand(SqlGet, connection);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlDataReader dr = cmdGetItems.ExecuteReader();

                try
                {
                    while (dr.Read())
                    {
                        // Can't we do this automagically somehow?
                        var lineItem = new PickListModel();

                        lineItem.SKU = Convert.ToString(dr["SKU"]);
                        lineItem.Location = Convert.ToString(dr["location"]);
                        lineItem.ImageURL = Convert.ToString(dr["image_url"]);
                        lineItem.Quantity = Convert.ToInt32(dr["quantity"]);
                        lineItem.Title = Convert.ToString(dr["title"]);
                        lineItem.Variation = Convert.ToString(dr["variation"]);
                        lineItem.DIFlag = Convert.ToString(dr["di_flag"]);

                        PickList.Add(lineItem);
                    }
                }
                catch (Exception ex)
                {
                    // Log error?
                    dr.Close();
                    throw ex;
                }
                finally
                {
                    dr.Close();
                }
            }

            return PickList;
        }


    }
}
